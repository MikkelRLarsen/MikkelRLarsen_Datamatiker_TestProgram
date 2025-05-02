namespace WinFormsTest
{
	partial class PrevNextMenu
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
			labelCurrentMaxPage = new Label();
			NextArrow = new PictureBox();
			PrevArrow = new PictureBox();
			((System.ComponentModel.ISupportInitialize)NextArrow).BeginInit();
			((System.ComponentModel.ISupportInitialize)PrevArrow).BeginInit();
			SuspendLayout();
			// 
			// labelCurrentMaxPage
			// 
			labelCurrentMaxPage.AutoSize = true;
			labelCurrentMaxPage.Location = new Point(69, 12);
			labelCurrentMaxPage.Name = "labelCurrentMaxPage";
			labelCurrentMaxPage.Size = new Size(49, 25);
			labelCurrentMaxPage.TabIndex = 2;
			labelCurrentMaxPage.Text = "1 / 1";
			// 
			// NextArrow
			// 
			NextArrow.Dock = DockStyle.Right;
			NextArrow.Image = Properties.Resources.arrow;
			NextArrow.Location = new Point(150, 0);
			NextArrow.Name = "NextArrow";
			NextArrow.Size = new Size(50, 50);
			NextArrow.SizeMode = PictureBoxSizeMode.StretchImage;
			NextArrow.TabIndex = 3;
			NextArrow.TabStop = false;
			NextArrow.Click += NextArrow_Click;
			// 
			// PrevArrow
			// 
			PrevArrow.Dock = DockStyle.Left;
			PrevArrow.Image = Properties.Resources.arrow__2_;
			PrevArrow.Location = new Point(0, 0);
			PrevArrow.Name = "PrevArrow";
			PrevArrow.Size = new Size(50, 50);
			PrevArrow.SizeMode = PictureBoxSizeMode.StretchImage;
			PrevArrow.TabIndex = 4;
			PrevArrow.TabStop = false;
			PrevArrow.Click += PrevArrow_Click;
			// 
			// PrevNextMenu
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveBorder;
			Controls.Add(PrevArrow);
			Controls.Add(NextArrow);
			Controls.Add(labelCurrentMaxPage);
			Name = "PrevNextMenu";
			Size = new Size(200, 50);
			((System.ComponentModel.ISupportInitialize)NextArrow).EndInit();
			((System.ComponentModel.ISupportInitialize)PrevArrow).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label labelCurrentMaxPage;
		private PictureBox NextArrow;
		private PictureBox PrevArrow;
	}
}
