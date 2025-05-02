namespace WinFormsTest.CreateCustomer
{
	partial class CreateCustomerMain
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
			flowLayoutPanel1 = new FlowLayoutPanel();
			panel1 = new Panel();
			SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.BackColor = SystemColors.HotTrack;
			flowLayoutPanel1.Dock = DockStyle.Bottom;
			flowLayoutPanel1.Location = new Point(0, 140);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(1000, 400);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaptionText;
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(1000, 140);
			panel1.TabIndex = 1;
			// 
			// CreateCustomerMain
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(panel1);
			Controls.Add(flowLayoutPanel1);
			Name = "CreateCustomerMain";
			Size = new Size(1000, 540);
			ResumeLayout(false);
		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
		private Panel panel1;
	}
}
