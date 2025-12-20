using Blazored.LocalStorage;
using CoreMap;
using GameServerManager.Core.Shared.Providers.Presentation;
using GameServerManager.Core.Shared.Webmin.Presentation;
using MedihatR;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using StatePulse.Net;
using SwizzleV;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameServerManager.Core;

public static class RegisterServicesExt
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, Type[] assemblies)
    {
        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });
        services.AddStatePulseServices(o =>
        {
            o.ScanAssemblies = assemblies;
        });
        services.AddMedihaterServices(cfg =>
        {
            cfg.AssembliesScan = assemblies;
        });
        services.AddCoreMap(o =>
        {
            o.Scope = CoreMap.Enums.ServiceScope.Scoped;

        }, assemblies);
        services.AddSwizzleV();
        services.AddBlazoredLocalStorage();
        services.AddWebminPresentation();
        services.AddProviderPresentation();
        return services;
    }
}
