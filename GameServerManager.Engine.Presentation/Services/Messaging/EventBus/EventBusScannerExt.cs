using GameServerManager.Engine.Application.Messaging.Event;
using GameServerManager.Plugin.Core.Messaging.EventSystem;
using System.Reflection;

namespace GameServerManager.Engine.Presentation.Services.Messaging.EventBus;

public static class EventBusScannerExt
{
    private static Queue<(string, Type, bool)> ToRuntimeRegister { get; set; } = new();
    public static void ScanEventBusHandlers(this IServiceCollection services, Assembly[] assembly)
    {
        var handlerType = typeof(IEventBusHandler);

        var toRegister = assembly.SelectMany(p => p.GetTypes())
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                !t.IsGenericTypeDefinition &&
                handlerType.IsAssignableFrom(t))
            .Select(t =>
            {
                var attr = t.GetCustomAttribute<EventBusIdAttribute>(inherit: false);
                if (attr == default)
                    throw new InvalidOperationException($"Type {t.FullName} MUST implements {nameof(EventBusIdAttribute)}.");
                return (attr.EventId, t, attr.IsCrossCircuitReceiver);
            }).ToList();
        foreach (var item in toRegister)
        {
            services.AddScoped(item.t);
            ToRuntimeRegister.Enqueue(item);
        }
    }

    public static void RegisterScannedEventBusHandlers(this WebApplication app)
    {
        if (ToRuntimeRegister.Count <= 0) return;
        var registry = app.Services.GetRequiredService<IEventBusRegistry>();
        do
        {
            var item = ToRuntimeRegister.Dequeue();
            registry.Register(item.Item1, new() { HandlerType = item.Item2, IsCrossCircuitType = item.Item3 });
        } while (ToRuntimeRegister.Count > 0);
    }
}
