using Autofac;
using DotrA_Lab.ORM.Context;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Data.Entity;

namespace DotrA_Lab.IOC.AutofacModule
{
    public class OrmModule : Module
    {
        public OrmModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DotrADbContext()).As<DbContext>();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            base.Load(builder);
        }
    }
}
