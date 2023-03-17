using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;

namespace WebBanHang.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private WebBanHangDbContext context;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected WebBanHangDbContext Context
        {
            get { return context ?? (context = databaseFactory.Init()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
