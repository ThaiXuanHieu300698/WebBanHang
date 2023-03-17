using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;

namespace WebBanHang.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        WebBanHangDbContext Init();
    }
}
