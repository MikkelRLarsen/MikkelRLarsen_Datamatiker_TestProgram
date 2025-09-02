using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTest.MoqOpgaver.Opgave_3.TestClasses
{
	public class AccountManager
	{
		private readonly IBankService _bankService;
		public AccountManager(IBankService bankService)
		{
			_bankService = bankService;
		}

		public bool CanWithdraw(int accountId, decimal amount)
		{
			var balance = _bankService.GetBalance(accountId);

			if (balance < amount)
				throw new InvalidOperationException("Insufficient funds");

			return true;
		}
	}
}
