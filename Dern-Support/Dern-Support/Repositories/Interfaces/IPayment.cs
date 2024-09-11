using Dern_Support.Model.DTO;

namespace Dern_Support.Repositories.Interfaces
{
    public interface IPayment
    {
        Task<PaymentDto> CreatePayment(PaymentDto paymentDto);
        Task<List<PaymentDto>> GetAllPayments();
        Task<PaymentDto> GetPaymentById(int paymentId);
        Task<PaymentDto> UpdatePayment(int id, PaymentDto paymentDto);
        Task DeletePayment(int id);
    }
}
