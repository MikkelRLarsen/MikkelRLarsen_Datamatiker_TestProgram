using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SOLID.SOLID_Opgaver
{
	internal class Opgave4_InterfaceSegregation
	{
		private class Before
		{
			private interface IMachine
			{
				void Print();
				void Scan();
				void Fax();
			}

			class BasicPrinter : IMachine
			{
				public void Print() => Console.WriteLine("Printing...");
				public void Scan() => throw new NotImplementedException();
				public void Fax() => throw new NotImplementedException();
			}
		}


		private class After
		{
			private interface IPrint
			{
				void Print();
			}
			private interface IScan
			{
				void Scan();
			}
			private interface IFax
			{
				void Fax();
			}

			private class BasicPrinter : IPrint
			{
				public void Print() => Console.WriteLine("Printing...");
			}
		}
	}
}
