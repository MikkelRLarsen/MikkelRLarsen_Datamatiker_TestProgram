using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest.NavigationMenu
{
	public partial class NavMenuForm : Form
	{
		public NavMenuForm()
		{
			InitializeComponent();
		}

		private bool mouseDown;
		private Point lastLocation;

		private void NavMenuForm_Load(object sender, EventArgs e)
		{

		}

		private void NavigationsPanel_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;

		}

		private void NavigationsPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}
		}

		private void NavigationsPanel_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}
	}
}
