using System;

namespace XboxWebApi.Authentication
{
    public static class WindowsLiveConstants
    {
        public const string ClientId = "0000000048093EE3";
        public const string Scope = "Xboxlive.signin Xboxlive.offline_access";
        public const string AuthorizeUrl = "https://login.live.com/oauth20_authorize.srf";
        public const string RefreshTokenUrl = "https://login.live.com/oauth20_token.srf";
        public const string RedirectUrl = "https://login.live.com/oauth20_desktop.srf";
        public const string ResponseType = "token";
    }
}