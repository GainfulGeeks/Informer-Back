using System.Text.Json.Serialization;

namespace Informer.Infrastructure.Models
{
    public class LoginResult
    {
     
        public string UserName { get; set; } = string.Empty;

        public string OriginalUserName { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;
    }
}
