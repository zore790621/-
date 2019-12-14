using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        Payment GetPayment(long id);
        IEnumerable<Payment> GetPayments();
        void RemovePayment(Payment payment);
        void UpdatePayment(Payment payment);
    }
}
