using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
	public partial class FormUsedToTestNexPrevMenu : Form
	{
		public FormUsedToTestNexPrevMenu()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			panel3.Controls.Add(new TestNextPrev());
		}
	}
}
