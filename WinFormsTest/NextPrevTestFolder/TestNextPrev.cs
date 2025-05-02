using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Forms;

namespace WinFormsTest
{
	public partial class TestNextPrev : UserControl
	{

		private List<UserCardUsedToTestNextPrev> komponents = new List<UserCardUsedToTestNextPrev>();
		private PrevNextMenu menu;

		private int nextNumber = 0;

		public TestNextPrev()
		{
			InitializeComponent();
			menu = new PrevNextMenu(4, flowLayoutPanel1, komponents.Cast<UserControl>().ToList());

			NextPrevPanal.Controls.Add(menu);
		}

		private void AddUserControl_Click(object sender, EventArgs e)
		{
			var kompnonent = new UserCardUsedToTestNextPrev(SetAndGetNextNumber());
			menu.AddUserControlToPanal(kompnonent);
		}

		private int SetAndGetNextNumber()
		{
			nextNumber++;
			return nextNumber;
		}
	}
}
