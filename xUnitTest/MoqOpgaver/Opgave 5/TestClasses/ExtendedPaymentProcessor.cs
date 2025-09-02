using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_5.TestClasses
{
	public class ExtendedPaymentProcessor : PaymentProcessor
	{
		public ExtendedPaymentProcessor(IPaymentService paymentService)
			: base(paymentService)
		{
		}

		public override string TrackPayment(int paymentId)
		{
			// base.TrackPayment can only return "Pending", "Processing" or "Completed"
			return base.TrackPayment(paymentId) == "Completed" ? "Completed" : "Not Completed Yet";
		}
	}
}
