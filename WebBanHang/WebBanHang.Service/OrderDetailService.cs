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
    public interface IOrderDetailService
    {
        void Add(OrderDetail orderDetail);
        OrderDetail GetById(int id);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(OrderDetail orderDetail)
        {
            orderDetailRepository.Add(orderDetail);
        }

        public OrderDetail GetById(int id)
        {
            return orderDetailRepository.GetById(id);
        }
    }
}
