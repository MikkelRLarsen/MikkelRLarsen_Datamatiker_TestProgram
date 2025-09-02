using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_5.TestClasses
{
	public interface IPaymentService
	{
		string GetPaymentStatus(int paymentId);
	}
}
