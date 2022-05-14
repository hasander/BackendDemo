using System.ComponentModel.DataAnnotations;

namespace BackendDemo.SharedLibrary.DTOs;

public class AppResponse
{
    public AppResponse()
    {
    }

    public AppResponse(string message, ResponseStatus status = ResponseStatus.SUCCESS)
    {
        Status = status;
        Message = message;
    }

    public AppResponse(dynamic data, ResponseStatus status = ResponseStatus.SUCCESS)
    {
        Status = status;
        Data = data;
    }

    public ResponseStatus Status { get; set; } = ResponseStatus.SUCCESS;
    public string? Message { get; set; }
    public string? Redirect { get; set; }
    public dynamic? Data { get; set; }
}

public class AppResponse<T>
{
    public AppResponse(ResponseStatus status = ResponseStatus.SUCCESS)
    {
        Status = status;
    }

    public AppResponse(string message, ResponseStatus status = ResponseStatus.SUCCESS)
    {
        Status = status;
        Message = message;
    }

    public AppResponse(T data, ResponseStatus status = ResponseStatus.SUCCESS)
    {
        Status = status;
        Data = data;
    }

    public ResponseStatus Status { get; set; } = ResponseStatus.SUCCESS;
    public string? Message { get; set; }
    public string? Redirect { get; set; }
    public T? Data { get; set; }
}

public enum ResponseStatus
{
    [Display(Name = "Hata Meydana Geldi")]
    ERROR = 500,

    [Display(Name = "Basarili")]
    SUCCESS = 200,

    [Display(Name = "Yetkiler Yetersiz")]
    UNAUTHORIZED = 401,
}
