using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;

namespace WebBanHang.Data.Repositoties
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IEnumerable<UserRole> GetByUserId(int userId);
        void AssignRole(int userId, int roleId);
    }
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public void AssignRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetByUserId(int userId)
        {
            return Context.UserRoles.Where(ur => ur.UserId == userId).ToList();
        }
    }
}
