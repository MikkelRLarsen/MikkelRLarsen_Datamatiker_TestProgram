using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTest
{
	internal class Personer
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public Personer(int iD, string name)
		{
			ID = iD;
			Name = name;
		}
	}
}
