namespace WarThunderParody.DAL.Interfaces;

public interface IRolesRepository : IBaseRepository<Role>
{
    public Task<Role?> GetByName(string name);

    public Task<List<Role>> GetAllRoles();

    public Task<List<Role>> GetRolesByUserId(int id);
}