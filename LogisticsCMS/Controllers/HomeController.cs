using System.Diagnostics;
using LogisticsCMS.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("Home/Error")]
    [Route("Home/Error/{statusCode:int?}")]
    public IActionResult Error(int? statusCode = null)
    {
        var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var statusCodeFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
        var resolvedStatusCode = statusCode ?? HttpContext.Response.StatusCode;

        if (exceptionFeature?.Error != null)
        {
            _logger.LogError(
                exceptionFeature.Error,
                "Unhandled exception while processing request for {Path}. TraceId: {TraceId}",
                exceptionFeature.Path,
                HttpContext.TraceIdentifier
            );
        }
        else if (resolvedStatusCode >= 400)
        {
            _logger.LogWarning(
                "Request completed with status code {StatusCode} for {Path}. TraceId: {TraceId}",
                resolvedStatusCode,
                statusCodeFeature?.OriginalPath ?? HttpContext.Request.Path.Value,
                HttpContext.TraceIdentifier
            );
        }

        Response.StatusCode = resolvedStatusCode >= 400 ? resolvedStatusCode : 500;

        return View(
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = Response.StatusCode,
                Path = exceptionFeature?.Path ?? statusCodeFeature?.OriginalPath,
                UserMessage = GetUserMessage(Response.StatusCode),
            }
        );
    }

    private static string GetUserMessage(int? statusCode) =>
        statusCode switch
        {
            404 => "Aradığınız sayfa bulunamadı.",
            403 => "Bu sayfaya erişim yetkiniz bulunmuyor.",
            400 => "Gönderilen istek işlenemedi.",
            _ => "Beklenmeyen bir hata oluştu. Lütfen biraz sonra tekrar deneyin.",
        };
}
