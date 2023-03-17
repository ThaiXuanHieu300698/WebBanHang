using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repositories;
using WebBanHang.Data.Repositoties;
using WebBanHang.Service;

namespace WebBanHang.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IDatabaseFactory, DatabaseFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrdersService, OrdersService>();
            container.RegisterType<IOrderDetailService, OrderDetailService>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<IOrderDetailRepository, OrderDetailRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}