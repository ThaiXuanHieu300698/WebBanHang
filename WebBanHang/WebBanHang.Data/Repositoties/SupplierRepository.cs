using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;

namespace WebBanHang.Data.Repositoties
{
    public interface ISupplierRepository : IRepository<Supplier>
    {

    }

    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
