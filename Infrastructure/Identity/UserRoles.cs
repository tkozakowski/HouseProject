namespace Infrastructure.Identity
{
    /// <summary>
    /// UserRO: read only,
    /// USer: read and write
    /// </summary>
    public static class UserRoles
    {
        public const string User = "User";
        public const string UserRO = "UserRO";
        public const string UserOrUserRO = User + "," + UserRO;
    }
}
