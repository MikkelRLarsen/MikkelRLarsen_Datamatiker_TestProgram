using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_3.TestClasses
{
	public interface IBankService
	{
		decimal GetBalance(int accountId);
	}
}
