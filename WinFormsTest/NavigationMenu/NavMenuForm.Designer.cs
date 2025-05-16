namespace WinFormsTest.NavigationMenu
{
	partial class NavMenuForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			NavigationsPanel = new Panel();
			NavMenuMainPanel = new Panel();
			examinationButton1 = new NavigationButtons.ExaminationButton(NavMenuMainPanel);
			SuspendLayout();
			// 
			// NavigationsPanel
			// 
			NavigationsPanel.BackColor = SystemColors.MenuHighlight;
			NavigationsPanel.Location = new Point(242, 0);
			NavigationsPanel.Margin = new Padding(0);
			NavigationsPanel.Name = "NavigationsPanel";
			NavigationsPanel.Size = new Size(1681, 70);
			NavigationsPanel.TabIndex = 0;
			NavigationsPanel.MouseDown += NavigationsPanel_MouseDown;
			NavigationsPanel.MouseMove += NavigationsPanel_MouseMove;
			NavigationsPanel.MouseUp += NavigationsPanel_MouseUp;
			// 
			// NavMenuMainPanel
			// 
			NavMenuMainPanel.Dock = DockStyle.Bottom;
			NavMenuMainPanel.Location = new Point(0, 73);
			NavMenuMainPanel.Name = "NavMenuMainPanel";
			NavMenuMainPanel.Size = new Size(1914, 971);
			NavMenuMainPanel.TabIndex = 1;
			// 
			// examinationButton1
			// 
			examinationButton1.BackColor = SystemColors.MenuHighlight;
			examinationButton1.Location = new Point(0, 0);
			examinationButton1.Margin = new Padding(0);
			examinationButton1.Name = "examinationButton1";
			examinationButton1.Size = new Size(250, 70);
			examinationButton1.TabIndex = 0;
			// 
			// NavMenuForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1914, 1044);
			Controls.Add(examinationButton1);
			Controls.Add(NavMenuMainPanel);
			Controls.Add(NavigationsPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "NavMenuForm";
			Text = "NavMenuForm";
			Load += NavMenuForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private Panel NavigationsPanel;
		private NavigationButtons.ExaminationButton examinationButton1;
		private Panel NavMenuMainPanel;
	}
}