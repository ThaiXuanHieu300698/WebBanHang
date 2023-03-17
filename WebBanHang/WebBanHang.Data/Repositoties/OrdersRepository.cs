using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;

namespace WebBanHang.Data.Repositoties
{
    public interface IOrdersRepository : IRepository<Order>
    {
        int Insert(Order order);
    }

    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public int Insert(Order order)
        {
            try
            {
                Context.Orders.Add(order);
                Context.SaveChanges();
                return order.OrderId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
