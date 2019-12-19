using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IImageBaseService : IService<ImageBase>
    {
    }
    public class ImageBaseService
        : GenericService<ImageBase>, IImageBaseService
    {
        public ImageBaseService(IUnitOfWork db)
            : base(db) { }
    }
}
