using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameServerManager.Core.Abstractions.Event;

public abstract class EventMessage : EventMessageNoData
{
    protected JsonObject? JsonObjectData { get; private set; }
    protected JsonValue? JsonValueData { get; private set; }
    protected JsonArray? JsonArrayData { get; private set; }
    protected object Data { get; }
    protected Type DataType { get; }
    protected EventMessage(string eventType, object data) : base(eventType)
    {
        Data = data;
        DataType = data.GetType();
        ProcessDataToJson();
    }

    protected EventMessage(string baseEventId, string eventType, object data) : base(eventType, baseEventId)
    {
        Data = data;
        DataType = data.GetType();
        ProcessDataToJson();
    }
    public override object? GetData()
    {
        if (JsonObjectData != default) return JsonArrayData; 
        if (JsonValueData != default) return JsonArrayData;
        if (JsonArrayData != default) return JsonArrayData;
        return null;
    }
    public override string GetEventId() => $"{EventBaseId}.{EventType}";

    protected void ProcessDataToJson()
    {
        bool isArray = IsAnyCollection(DataType);
        bool isPrimitive = IsPrimitiveLike(DataType);
        if (isArray) 
            JsonArrayData = JsonSerializer.SerializeToNode(Data)!.AsArray();
        else if(isPrimitive)
            JsonValueData = JsonSerializer.SerializeToNode(Data)!.AsValue();
        else
            JsonObjectData = JsonSerializer.SerializeToNode(Data)!.AsObject();
    }
    private static bool IsAnyCollection(Type type)
    {
        if (type == typeof(string))
            return false;

        if (type.IsArray)
            return true;

        if (type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(List<>))
            return true;

        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            return true;

        return false;
    }
    private static bool IsPrimitiveLike(Type type)
    {
        type = Nullable.GetUnderlyingType(type) ?? type;

        if (type.IsPrimitive) return true;                 
        if (type.IsEnum) return true;                      
        if (type == typeof(string)) return true;           
        if (type == typeof(decimal)) return true;          
        if (type == typeof(DateTime)) return true;         
        if (type == typeof(DateTimeOffset)) return true;   
        if (type == typeof(Guid)) return true;             

        return false;
    }

}
