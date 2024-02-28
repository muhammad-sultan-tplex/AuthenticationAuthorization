using Microsoft.Identity.Client;

namespace AuthenticationAuthorization.Repository
{
    public interface IUserRepository
    {
        public string Name { get; set; }
    }

    public class UserRepository: IUserRepository
    {
        public string UserName = "sultan";
        public string Name
        {
            get { return Name; }

            set { Name = UserName; }
        }
    }
}
