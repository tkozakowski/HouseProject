namespace HouseProject.Application.Core
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
    }
}
