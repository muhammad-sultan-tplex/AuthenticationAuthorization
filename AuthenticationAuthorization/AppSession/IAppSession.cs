namespace AuthenticationAuthorization.AppSession
{
    public interface IAppSession
    {
        public string Email { get; }
        public string RoleName { get; }
    }
}
