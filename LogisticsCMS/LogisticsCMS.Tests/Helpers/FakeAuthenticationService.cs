using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeAuthenticationService : IAuthenticationService
{
    public ClaimsPrincipal? SignedInPrincipal { get; private set; }
    public string? SignedInScheme { get; private set; }
    public bool SignOutCalled { get; private set; }
    public string? SignOutScheme { get; private set; }

    public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme) =>
        Task.FromResult(AuthenticateResult.NoResult());

    public Task ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties) =>
        Task.CompletedTask;

    public Task ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties) =>
        Task.CompletedTask;

    public Task SignInAsync(
        HttpContext context,
        string? scheme,
        ClaimsPrincipal principal,
        AuthenticationProperties? properties
    )
    {
        SignedInScheme = scheme;
        SignedInPrincipal = principal;
        return Task.CompletedTask;
    }

    public Task SignOutAsync(
        HttpContext context,
        string? scheme,
        AuthenticationProperties? properties
    )
    {
        SignOutCalled = true;
        SignOutScheme = scheme;
        return Task.CompletedTask;
    }
}
