using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IAllService
    {
        IUnitOfWork UOF();
        ICategoryService CS();
        IImageBaseService IMGS();
        IMemberRoleService MRS();
        IMemberService MS();
        IOrderService OS();
        IOrderDetailService ODS();
        IPaymentService PAYS();
        IProductService PS();
        IShipperService SHIPS();
        ISupplierService SUPS();

        IGenericRepository<T> Repository<T>() where T : class;

        IService<T> Service<T>() where T : class;
    }
}
