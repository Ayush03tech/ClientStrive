using System;

namespace ClientStrive_API.Data;

public class APIResponse
{
    public string message { get; set; }
    public bool result { get; set; }
    public object? data { get; set; }

    public APIResponse(string message, bool result, object? data)
    {
        this.message = message;
        this.result = result;
        this.data = data;
    }

    public static APIResponse Success(object? data)
    {
        return new APIResponse("", true, data);
    }

    public static APIResponse Success(string message, object? data)
    {
        return new APIResponse(message, true, data);
    }

    public static APIResponse Failure(string message)
    {
        return new APIResponse(message, false, null);
    }
}
