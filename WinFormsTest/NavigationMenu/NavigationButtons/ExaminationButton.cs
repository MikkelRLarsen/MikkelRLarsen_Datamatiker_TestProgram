using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest.NavigationMenu.NavigationButtons
{
	public partial class ExaminationButton : UserControl
	{
		bool expand = false;
		public Panel? NavMenuMainPanel { get; set; }

		public ExaminationButton()
		{
			InitializeComponent();
		}

		private void OpretLabel_Click(object sender, EventArgs e)
		{
			if (NavMenuMainPanel == null) return;

			NavMenuMainPanel.Controls.Clear();
			NavMenuMainPanel.Controls.Add(new TestNextPrev());
		}

		private void FindLabel_Click(object sender, EventArgs e)
		{

		}

		private void ExaminationLabel_Click(object sender, EventArgs e)
		{
			collapseTimer.Start();
		}

		private void collapseTimer_Tick(object sender, EventArgs e)
		{
			if (expand == false)
			{
				if (this.BackColor != Color.MidnightBlue)
				{
					this.BackColor = Color.MidnightBlue;
					ExaminationLabel.BackColor = this.BackColor;
				}

				this.Height += 14;
				if (this.Height >= 210)
				{
					collapseTimer.Stop();
					expand = true;
				}
			}
			else
			{
				if (this.BackColor != SystemColors.MenuHighlight)
				{
					this.BackColor = SystemColors.MenuHighlight;
					ExaminationLabel.BackColor = this.BackColor;
				}

				this.Height -= 14;
				if (this.Height <= 70)
				{
					collapseTimer.Stop();
					expand = false;
				}
			}
		}
	}
}
