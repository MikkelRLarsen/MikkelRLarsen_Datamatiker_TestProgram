namespace WinFormsTest.Forms
{
	partial class BigBoy
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
			button2 = new Button();
			listLength = new TextBox();
			currentPageDisplay = new TextBox();
			NextButton = new Button();
			button1 = new Button();
			mainPanal = new FlowLayoutPanel();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(listLength);
			panel1.Controls.Add(currentPageDisplay);
			panel1.Controls.Add(NextButton);
			panel1.Controls.Add(button1);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Margin = new Padding(1, 2, 1, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(769, 59);
			panel1.TabIndex = 0;
			// 
			// button2
			// 
			button2.Location = new Point(586, 12);
			button2.Margin = new Padding(1, 2, 1, 2);
			button2.Name = "button2";
			button2.Size = new Size(61, 37);
			button2.TabIndex = 5;
			button2.Text = "Prev";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// listLength
			// 
			listLength.Location = new Point(379, 17);
			listLength.Margin = new Padding(1, 2, 1, 2);
			listLength.Name = "listLength";
			listLength.Size = new Size(35, 31);
			listLength.TabIndex = 4;
			// 
			// currentPageDisplay
			// 
			currentPageDisplay.Location = new Point(651, 15);
			currentPageDisplay.Margin = new Padding(1, 2, 1, 2);
			currentPageDisplay.Name = "currentPageDisplay";
			currentPageDisplay.Size = new Size(35, 31);
			currentPageDisplay.TabIndex = 3;
			currentPageDisplay.Text = "1";
			// 
			// NextButton
			// 
			NextButton.Location = new Point(691, 12);
			NextButton.Margin = new Padding(1, 2, 1, 2);
			NextButton.Name = "NextButton";
			NextButton.Size = new Size(61, 37);
			NextButton.TabIndex = 2;
			NextButton.Text = "Next";
			NextButton.UseVisualStyleBackColor = true;
			NextButton.Click += NextButton_Click;
			// 
			// button1
			// 
			button1.Location = new Point(416, 15);
			button1.Margin = new Padding(1, 2, 1, 2);
			button1.Name = "button1";
			button1.Size = new Size(114, 37);
			button1.TabIndex = 1;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// mainPanal
			// 
			mainPanal.AutoScroll = true;
			mainPanal.Dock = DockStyle.Fill;
			mainPanal.Location = new Point(0, 59);
			mainPanal.Margin = new Padding(1, 2, 1, 2);
			mainPanal.Name = "mainPanal";
			mainPanal.Size = new Size(769, 363);
			mainPanal.TabIndex = 1;
			// 
			// BigBoy
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(mainPanal);
			Controls.Add(panel1);
			Margin = new Padding(1, 2, 1, 2);
			Name = "BigBoy";
			Size = new Size(769, 422);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private FlowLayoutPanel mainPanal;
		private Button button1;
		private Button NextButton;
		private TextBox currentPageDisplay;
		private TextBox listLength;
		private Button button2;
	}
}
