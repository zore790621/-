using DotrA_Lab.ORM.UnitOfWorkPattern;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class Service<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
