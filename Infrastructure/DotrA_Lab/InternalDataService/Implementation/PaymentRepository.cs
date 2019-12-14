using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class PaymentRepository : Service<Payment>, IPaymentRepository
    {
        private readonly IGenericRepository<Payment> _PaymentRepository;

        public PaymentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._PaymentRepository = unitOfWork.Repository<Payment>();
        }

        public Payment GetPayment(long id)
        {
            return _PaymentRepository.Get(id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _PaymentRepository.GetAll();
        }

        public void AddPayment(Payment payment)
        {
            _PaymentRepository.Add(payment);
            _unitOfWork.SaveChanges();
        }

        public void UpdatePayment(Payment payment)
        {
            this._PaymentRepository.Update(payment);
            _unitOfWork.SaveChanges();
        }

        public void RemovePayment(Payment payment)
        {
            this._PaymentRepository.Remove(payment);
            _unitOfWork.SaveChanges();
        }
    }
}
