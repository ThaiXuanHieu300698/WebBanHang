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
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }

        public Supplier GetById(int id)
        {
            return supplierRepository.GetById(id);
        }
    }
}
