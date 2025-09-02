using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SOLID.SOLID_Opgaver
{
	internal class Opgave3_Lindskov
	{
		private class Before
		{
			private class Bird
			{
				public virtual void Fly()
				{
					Console.WriteLine("Flying...");
				}
			}

			private class Sparrow : Bird
			{
				public override void Fly()
				{
					Console.WriteLine("Sparrow is flying...");
				}
			}

			private class Penguin : Bird
			{
				public override void Fly()
				{
					throw new NotImplementedException("Penguins cannot fly!");
				}
			}
		}


		private class After
		{
			private class Bird
			{
				public double Weight { get; set; }
			}

			private interface IFly
			{
				void Fly();
			}
			private class Sparrow : Bird, IFly
			{
				public void Fly()
				{
					Console.WriteLine("Sparrow is flying...");
				}
			}

			private class Penguin : Bird
			{
			}
		}
	}
}
