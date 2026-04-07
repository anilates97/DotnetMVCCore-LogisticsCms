using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeUrlHelper : IUrlHelper
{
    public ActionContext ActionContext { get; } = new();

    public string? Action(UrlActionContext actionContext) => throw new NotImplementedException();

    public string? Content(string? contentPath) => contentPath;

    public bool IsLocalUrl(string? url) =>
        !string.IsNullOrWhiteSpace(url) && url.StartsWith("/", StringComparison.Ordinal);

    public string? Link(string? routeName, object? values) => throw new NotImplementedException();

    public string? RouteUrl(UrlRouteContext routeContext) => throw new NotImplementedException();
}
