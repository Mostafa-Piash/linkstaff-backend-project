﻿namespace SocialNetwork.Domain.Common
{
    public class JwtConfiguration
    {
        public string Authority { get; set; }
        public string AccessToken { get; set; }
        public string Audience { get; set; }
        public long AccessTokenTimeout { get; set; }
        public string SecurityKey { get; set; }
    }
}
