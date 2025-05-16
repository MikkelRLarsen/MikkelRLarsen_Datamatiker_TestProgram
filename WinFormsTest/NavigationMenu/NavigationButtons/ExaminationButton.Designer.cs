namespace WinFormsTest.NavigationMenu.NavigationButtons
{
	partial class ExaminationButton
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			collapseTimer = new System.Windows.Forms.Timer(components);
			ExaminationLabel = new Label();
			panel1 = new Panel();
			FindLabel = new Label();
			OpretLabel = new Label();
			SuspendLayout();
			// 
			// collapseTimer
			// 
			collapseTimer.Interval = 15;
			collapseTimer.Tick += collapseTimer_Tick;
			// 
			// ExaminationLabel
			// 
			ExaminationLabel.AutoSize = true;
			ExaminationLabel.BackColor = SystemColors.MenuHighlight;
			ExaminationLabel.Font = new Font("Segoe UI", 19F);
			ExaminationLabel.ForeColor = SystemColors.ButtonFace;
			ExaminationLabel.Location = new Point(0, 0);
			ExaminationLabel.Margin = new Padding(0);
			ExaminationLabel.Name = "ExaminationLabel";
			ExaminationLabel.Padding = new Padding(12, 9, 12, 9);
			ExaminationLabel.Size = new Size(250, 69);
			ExaminationLabel.TabIndex = 0;
			ExaminationLabel.Text = "Examination";
			ExaminationLabel.TextAlign = ContentAlignment.MiddleCenter;
			ExaminationLabel.Click += ExaminationLabel_Click;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.Desktop;
			panel1.ForeColor = SystemColors.ButtonFace;
			panel1.Location = new Point(0, 70);
			panel1.Name = "panel1";
			panel1.Size = new Size(250, 2);
			panel1.TabIndex = 1;
			// 
			// FindLabel
			// 
			FindLabel.AutoSize = true;
			FindLabel.Font = new Font("Segoe UI", 19F);
			FindLabel.ForeColor = SystemColors.ButtonFace;
			FindLabel.Location = new Point(4, 75);
			FindLabel.Margin = new Padding(0);
			FindLabel.Name = "FindLabel";
			FindLabel.Padding = new Padding(140, 9, 12, 9);
			FindLabel.RightToLeft = RightToLeft.No;
			FindLabel.Size = new Size(246, 69);
			FindLabel.TabIndex = 2;
			FindLabel.Text = "Find";
			FindLabel.TextAlign = ContentAlignment.TopRight;
			FindLabel.Click += FindLabel_Click;
			// 
			// OpretLabel
			// 
			OpretLabel.AutoSize = true;
			OpretLabel.Font = new Font("Segoe UI", 19F);
			OpretLabel.ForeColor = SystemColors.ButtonFace;
			OpretLabel.Location = new Point(0, 140);
			OpretLabel.Margin = new Padding(0);
			OpretLabel.Name = "OpretLabel";
			OpretLabel.Padding = new Padding(120, 9, 12, 9);
			OpretLabel.Size = new Size(251, 69);
			OpretLabel.TabIndex = 3;
			OpretLabel.Text = "Opret";
			OpretLabel.TextAlign = ContentAlignment.MiddleRight;
			OpretLabel.Click += OpretLabel_Click;
			// 
			// ExaminationButton
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.MenuHighlight;
			Controls.Add(OpretLabel);
			Controls.Add(FindLabel);
			Controls.Add(panel1);
			Controls.Add(ExaminationLabel);
			Margin = new Padding(0);
			Name = "ExaminationButton";
			Size = new Size(250, 70);
			Click += ExaminationLabel_Click;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Timer collapseTimer;
		private Label ExaminationLabel;
		private Panel panel1;
		private Label FindLabel;
		private Label OpretLabel;
	}
}
