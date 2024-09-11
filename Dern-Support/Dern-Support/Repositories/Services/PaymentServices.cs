using Dern_Support.Data;
using Dern_Support.Model;
using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support.Repositories.Services
{
    public class PaymentServices : IPayment
    {
        private readonly DernSupportDbContext _context;

        public PaymentServices(DernSupportDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> CreatePayment(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                Amount = paymentDto.Amount,
                PaymentDate = paymentDto.PaymentDate,
                PaymentMethod = paymentDto.PaymentMethod,
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            paymentDto.PaymentId = payment.PaymentId;
            return paymentDto;
        }

        public async Task DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PaymentDto>> GetAllPayments()
        {
            return await _context.Payments
                .Select(p => new PaymentDto
                {
                    PaymentId = p.PaymentId,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                })
                .ToListAsync();
        }

        public async Task<PaymentDto> GetPaymentById(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);

            if (payment == null)
                return null;

            return new PaymentDto
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
            };
        }

        public async Task<PaymentDto> UpdatePayment(int id, PaymentDto paymentDto)
        {
            var existingPayment = await _context.Payments.FindAsync(id);
            if (existingPayment != null)
            {
                existingPayment.Amount = paymentDto.Amount;
                existingPayment.PaymentDate = paymentDto.PaymentDate;
                existingPayment.PaymentMethod = paymentDto.PaymentMethod;

                await _context.SaveChangesAsync();

                return paymentDto;
            }
            return null;
        }
    }
}
