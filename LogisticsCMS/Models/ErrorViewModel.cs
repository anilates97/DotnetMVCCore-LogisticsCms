namespace LogisticsCMS.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public int? StatusCode { get; set; }
    public string? Path { get; set; }
    public string UserMessage { get; set; } =
        "Beklenmeyen bir hata oluştu. Lütfen tekrar deneyin.";

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
