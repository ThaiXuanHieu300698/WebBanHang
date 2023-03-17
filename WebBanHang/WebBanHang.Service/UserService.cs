using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repositories;

namespace WebBanHang.Service
{
    public interface IUserService
    {
        User GetUser(string username, string passwordHash);
        User GetById(int id);
        void Update(User user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetUser(string username, string passwordHash)
        {
            return userRepository.GetUser(username, passwordHash);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
            unitOfWork.Commit();
        }
    }
}
