using SpotifyApp.Api.Contracts.Auth;

namespace SpotifyApp.Shared.Configurations;

public sealed class OidcConfiguration : IOidcConfiguration
{
    public string ClientId => "";
    public string RedirectUri => "http://127.0.0.1:7890";
    public string Scope  => "user-read-private user-read-email user-library-read user-top-read user-follow-read";
}