namespace WinFormsTest
{
	partial class TestNextPrev
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
			mainFlowPanal = new Panel();
			AddUserControl = new Button();
			NextPrevPanal = new Panel();
			mainFlowPanal.SuspendLayout();
			SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Dock = DockStyle.Bottom;
			flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			flowLayoutPanel1.Location = new Point(0, 152);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(1632, 869);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// mainFlowPanal
			// 
			mainFlowPanal.Controls.Add(AddUserControl);
			mainFlowPanal.Controls.Add(NextPrevPanal);
			mainFlowPanal.Dock = DockStyle.Top;
			mainFlowPanal.Location = new Point(0, 0);
			mainFlowPanal.Name = "mainFlowPanal";
			mainFlowPanal.Size = new Size(1632, 150);
			mainFlowPanal.TabIndex = 1;
			// 
			// AddUserControl
			// 
			AddUserControl.Location = new Point(752, 48);
			AddUserControl.Name = "AddUserControl";
			AddUserControl.Size = new Size(203, 69);
			AddUserControl.TabIndex = 1;
			AddUserControl.Text = "Add";
			AddUserControl.UseVisualStyleBackColor = true;
			AddUserControl.Click += AddUserControl_Click;
			// 
			// NextPrevPanal
			// 
			NextPrevPanal.Location = new Point(1241, 48);
			NextPrevPanal.Name = "NextPrevPanal";
			NextPrevPanal.Size = new Size(200, 50);
			NextPrevPanal.TabIndex = 0;
			// 
			// TestNextPrev
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(mainFlowPanal);
			Controls.Add(flowLayoutPanel1);
			Name = "TestNextPrev";
			Size = new Size(1632, 1021);
			mainFlowPanal.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private FlowLayoutPanel flowLayoutPanel1;
		private Panel mainFlowPanal;
		private Button AddUserControl;
		private Panel NextPrevPanal;
	}
}
