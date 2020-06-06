using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Modules.User.Models
{
    public class AccessTokenResponse
    {
        public int Id { get; set; }
        public int UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiredAt { get; set; }
        public DateTime RefreshTokenExpiredAt { get; set; }
    }
}
