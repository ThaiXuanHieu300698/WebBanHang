using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repositoties;

namespace WebBanHang.Service
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetByUserId(int userId);
        void AssignRole(int userId, int roleId);
        void Save();
    }

    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            this.userRoleRepository = userRoleRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserRole> GetByUserId(int userId)
        {
            return userRoleRepository.GetByUserId(userId);
        }

        public void AssignRole(int userId, int roleId)
        {
            userRoleRepository.AssignRole(userId, roleId);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
