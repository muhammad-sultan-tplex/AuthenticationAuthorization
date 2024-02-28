using AuthenticationAuthorization.Models;

namespace AuthenticationAuthorization.Repository
{
    public interface IRoleRepository
    {
        public Task<List<RoleModel>> GetRoles();
    }

    public class RoleRepository: IRoleRepository
    {
        public readonly ICRUDRepository<RoleModel> _roleRepository;

        public RoleRepository(ICRUDRepository<RoleModel> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleModel>> GetRoles()
        {
            return await _roleRepository.Get();
        }
    }
}
