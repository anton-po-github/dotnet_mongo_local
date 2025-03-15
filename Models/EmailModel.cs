public class EmailModel
{
    public string? From { get; set; } = "myworkinggemail@gmail.com";
    public string? ToEmail { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}