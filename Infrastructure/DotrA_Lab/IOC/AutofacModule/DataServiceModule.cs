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
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            //builder.RegisterType<MemberRoloRepository>().As<IMemberRoloRepository>();
            //builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            //builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
            //builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            //builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            //builder.RegisterType<ProductRepository>().As<IProductRepository>();
            //builder.RegisterType<ShipperRepository>().As<IShipperRepository>();
            //builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();

            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IService<>));

            base.Load(builder);
        }
    }
}
