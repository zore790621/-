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
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<MemberRoloService>().As<IMemberRoloService>();
            builder.RegisterType<MemberService>().As<IMemberService>();
            builder.RegisterType<OrderDetailService>().As<IOrderDetailService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ShipperService>().As<IShipperService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();

            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IService<>));

            base.Load(builder);
        }
    }
}
