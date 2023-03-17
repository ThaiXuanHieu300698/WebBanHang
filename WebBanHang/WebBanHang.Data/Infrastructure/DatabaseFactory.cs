using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;

namespace WebBanHang.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        WebBanHangDbContext context;

        public WebBanHangDbContext Init()
        {
            return context ?? (context = new WebBanHangDbContext());
        }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
