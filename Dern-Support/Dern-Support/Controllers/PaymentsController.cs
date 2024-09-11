using Dern_Support.Model.DTO;
using Dern_Support.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _paymentService;

        public PaymentController(IPayment paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentId)
            {
                return BadRequest();
            }

            var updatedPayment = await _paymentService.UpdatePayment(id, paymentDto);
            if (updatedPayment == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> PostPayment(PaymentDto paymentDto)
        {
            var createdPayment = await _paymentService.CreatePayment(paymentDto);
            return CreatedAtAction("GetPayment", new { id = createdPayment.PaymentId }, createdPayment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePayment(id);
            return NoContent();
        }
    }
}
