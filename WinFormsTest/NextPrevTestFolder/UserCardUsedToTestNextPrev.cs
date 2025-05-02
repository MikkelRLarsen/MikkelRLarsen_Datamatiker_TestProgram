using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest.Forms
{
	public partial class UserCardUsedToTestNextPrev : UserControl
	{
		public UserCardUsedToTestNextPrev(int number)
		{
			InitializeComponent();
			numberDisplay.Text = number.ToString();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
