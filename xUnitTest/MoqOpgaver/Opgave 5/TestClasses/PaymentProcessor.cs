using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_5.TestClasses
{
	public class PaymentProcessor
	{
		private readonly IPaymentService _paymentService;

		public PaymentProcessor(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		public virtual string TrackPayment(int paymentId)
		{
			return _paymentService.GetPaymentStatus(paymentId);
		}
	}

}
