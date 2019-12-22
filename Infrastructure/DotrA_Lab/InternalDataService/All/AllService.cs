using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class AllService : IAllService
    {
        private readonly DbContext _context;
        private Hashtable _repositories;

        private readonly IUnitOfWork _uof;
        private readonly ICategoryService _cs;
        private readonly IImageBaseService _img;
        private readonly IMemberRoleService _mrs;
        private readonly IMemberService _ms;
        private readonly IOrderService _os;
        private readonly IOrderDetailService _ods;
        private readonly IPaymentService _pays;
        private readonly IProductService _ps;
        private readonly IShipperService _ships;
        private readonly ISupplierService _sups;
        protected IUnitOfWork UOF => _uof;
        protected ICategoryService CS => _cs;
        protected IImageBaseService IMGS => _img;
        protected IMemberRoleService MRS => _mrs;
        protected IMemberService MS => _ms;
        protected IOrderService OS => _os;
        protected IOrderDetailService ODS => _ods;
        protected IPaymentService PAYS => _pays;
        protected IProductService PS => _ps;
        protected IShipperService SHIPS => _ships;
        protected ISupplierService SUPS => _sups;

        public AllService(
            IUnitOfWork uof, ICategoryService cs, IImageBaseService img, IMemberRoleService mrs, IMemberService ms, IOrderService os,
            IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups,
            DbContext context
            )
        {
            this._uof = uof ?? throw new ArgumentNullException();
            this._cs = cs ?? throw new ArgumentNullException();
            this._img = img ?? throw new ArgumentNullException();
            this._mrs = mrs ?? throw new ArgumentNullException();
            this._ms = ms ?? throw new ArgumentNullException();
            this._os = os ?? throw new ArgumentNullException();
            this._ods = ods ?? throw new ArgumentNullException();
            this._pays = pay ?? throw new ArgumentNullException();
            this._ps = ps ?? throw new ArgumentNullException();
            this._ships = ships ?? throw new ArgumentNullException();
            this._sups = sups ?? throw new ArgumentNullException();
            this._context = context ?? throw new ArgumentException();
        }

        IUnitOfWork IAllService.UOF() => this._uof;

        ICategoryService IAllService.CS() => this._cs;
        IImageBaseService IAllService.IMGS() => this._img;

        IMemberRoleService IAllService.MRS() => this._mrs;
        IMemberService IAllService.MS() => this._ms;

        IOrderService IAllService.OS() => this._os;

        IOrderDetailService IAllService.ODS() => this._ods;

        IPaymentService IAllService.PAYS() => this._pays;

        IProductService IAllService.PS() => this._ps;

        IShipperService IAllService.SHIPS() => this._ships;

        ISupplierService IAllService.SUPS() => this._sups;

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        public IService<T> Service<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IService<T>)_repositories[type];
        }
    }
}
