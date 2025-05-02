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
	public partial class PrevNextMenu : UserControl
	{
		private int _pageSize;
		private FlowLayoutPanel _flowLayoutPanel;
		private List<UserControl> _allUserControls;
		private int _currentPage = 0;

		public PrevNextMenu(int pageSize, FlowLayoutPanel flowLayoutPanal, List<UserControl> allUserControls)
		{
			InitializeComponent();
			_pageSize = pageSize;
			_flowLayoutPanel = flowLayoutPanal;
			_allUserControls = allUserControls;
		}
		private void ShowPage()
		{
			_flowLayoutPanel.Controls.Clear();

			int start = _currentPage * _pageSize;
			int end = Math.Min(start + _pageSize, _allUserControls.Count);

			for (int i = start; i < end; i++)
			{
				if (_allUserControls[i] != null)
					_flowLayoutPanel.Controls.Add(_allUserControls[i]);
			}

			UpdateCurrentPageDisplay();
			UpdateNavigationButtons();
		}

		private void UpdateNavigationButtons()
		{
			PrevArrow.Enabled = _currentPage > 0;
			NextArrow.Enabled = (_currentPage + 1) * _pageSize < _allUserControls.Count;
		}
		private void UpdateCurrentPageDisplay()
		{
			int totalPages = (int)Math.Ceiling((double)_allUserControls.Count / _pageSize);
			labelCurrentMaxPage.Text = $"{_currentPage + 1}/{Math.Max(totalPages, 1)}";

		}

		private void PrevArrow_Click(object sender, EventArgs e)
		{
			if (_currentPage > 0)
			{
				_currentPage--;
				ShowPage();
			}
		}

		private void NextArrow_Click(object sender, EventArgs e)
		{
			if ((_currentPage + 1) * _pageSize < _allUserControls.Count)
			{
				_currentPage++;
				ShowPage();
			}
		}

		public void AddUserControlToPanal(UserControl userControl)
		{
			_allUserControls.Add(userControl);
			ShowPage();
		}

		public void ChangePageSize(int pageSize)
		{
			_pageSize = pageSize;
			ShowPage();
		}
	}
}
