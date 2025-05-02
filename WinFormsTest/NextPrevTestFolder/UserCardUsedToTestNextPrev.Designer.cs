namespace WinFormsTest.Forms
{
	partial class UserCardUsedToTestNextPrev
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
			panel1 = new Panel();
			numberDisplay = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaption;
			panel1.Controls.Add(numberDisplay);
			panel1.Location = new Point(0, 0);
			panel1.Margin = new Padding(2, 2, 2, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(88, 78);
			panel1.TabIndex = 1;
			// 
			// numberDisplay
			// 
			numberDisplay.AutoSize = true;
			numberDisplay.Location = new Point(15, 26);
			numberDisplay.Name = "numberDisplay";
			numberDisplay.Size = new Size(0, 25);
			numberDisplay.TabIndex = 0;
			// 
			// Komponent1Test
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.HotTrack;
			Controls.Add(panel1);
			Margin = new Padding(0, 0, 0, 2);
			Name = "Komponent1Test";
			Size = new Size(769, 80);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Panel panel1;
		private Label numberDisplay;
	}
}
