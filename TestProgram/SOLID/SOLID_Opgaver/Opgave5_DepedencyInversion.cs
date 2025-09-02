using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SOLID.SOLID_Opgaver
{
	internal class Opgave5_DepedencyInversion
	{
		private class Before
		{
			class LightBulb
			{
				public void TurnOn() => Console.WriteLine("LightBulb On");
				public void TurnOff() => Console.WriteLine("LightBulb Off");
			}

			class Switch
			{
				private LightBulb bulb = new LightBulb();
				public void Operate(bool on)
				{
					if (on) bulb.TurnOn();
					else bulb.TurnOff();
				}
			}
		}

		private class After
		{
			private interface ILightBulb
			{
				void TurnOn();
				void TurnOff();
			}
			private class LightBulb : ILightBulb 
			{
				public void TurnOn() => Console.WriteLine("LightBulb On");
				public void TurnOff() => Console.WriteLine("LightBulb Off");
			}

			class Switch
			{
				private ILightBulb bulb;

				public Switch(ILightBulb bulb)
				{
					this.bulb = bulb;
				}

				public void Operate(bool on)
				{
					if (on) bulb.TurnOn();
					else bulb.TurnOff();
				}
			}
		}
	}
}
