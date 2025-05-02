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
	public partial class BigBoy : UserControl
	{
		private List<UserCardUsedToTestNextPrev> komponent1s = new List<UserCardUsedToTestNextPrev>();
		private int pageSize;
		private int currentPage = 0;
		private int nextNumber = 0;

		public BigBoy()
		{
			InitializeComponent();
			pageSize = 4;
			ShowPage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var newKompnent = new UserCardUsedToTestNextPrev(SetAndGetNextNumber());
			komponent1s.Add(newKompnent);
			listLength.Text = komponent1s.Count.ToString();

			// Hop automatisk til sidste side
			currentPage = (komponent1s.Count - 1) / pageSize;
			ShowPage();
		}

		private int SetAndGetNextNumber()
		{
			nextNumber++;
			return nextNumber;
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			if ((currentPage + 1) * pageSize < komponent1s.Count)
			{
				currentPage++;
				ShowPage();
			}
		}

		private void ShowPage()
		{
			mainPanal.Controls.Clear();

			int start = currentPage * pageSize;
			int end = Math.Min(start + pageSize, komponent1s.Count);

			for (int i = start; i < end; i++)
			{
				if (komponent1s[i] != null)
					mainPanal.Controls.Add(komponent1s[i]);
			}

			UpdateCurrentPageDisplay();
			UpdateNavigationButtons();
		}

		private void UpdateNavigationButtons()
		{
			button2.Enabled = currentPage > 0;
			NextButton.Enabled = (currentPage + 1) * pageSize < komponent1s.Count;
		}

		private void UpdateCurrentPageDisplay()
		{
			currentPageDisplay.Text = (currentPage + 1).ToString();

			//int totalPages = (int)Math.Ceiling((double)komponent1s.Count / pageSize);
			//currentPageDisplay.Text = $"Side {currentPage + 1} af {Math.Max(totalPages, 1)}";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (currentPage > 0)
			{
				currentPage--;
				ShowPage();
			}
		}
	}
}
