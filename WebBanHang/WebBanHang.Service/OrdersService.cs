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
    public interface IOrdersService
    {
        void Add(Order orders);
        Order GetById(int id);
        int Insert(Order order);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrdersService(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            this.ordersRepository = ordersRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Order orders)
        {
            ordersRepository.Add(orders);
            unitOfWork.Commit();
        }

        public Order GetById(int id)
        {
            return ordersRepository.GetById(id);
        }

        public int Insert(Order order)
        {
            return ordersRepository.Insert(order);
        }
    }
}
