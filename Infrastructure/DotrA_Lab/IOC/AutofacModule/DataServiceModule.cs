using Autofac;
using DotrA_Lab.InternalDataService.Implementation;

namespace DotrA_Lab.IOC.AutofacModule
{
    public class DataServiceModule : Module
    {
        public DataServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminRepository>().As<IAdminRepository>();
            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>();
            builder.RegisterType<MembersRepository>().As<IMembersRepository>();
            builder.RegisterType<OrderDetailsRepository>().As<IOrderDetailsRepository>();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            builder.RegisterType<ProductsRepository>().As<IProductsRepository>();
            builder.RegisterType<ShippersRepository>().As<IShippersRepository>();
            builder.RegisterType<SuppliersRepository>().As<ISuppliersRepository>();

            base.Load(builder);
        }
    }
}
