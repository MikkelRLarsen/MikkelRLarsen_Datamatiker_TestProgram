namespace WinFormsTest
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panel1 = new Panel();
			button4 = new Button();
			panel2 = new Panel();
			button3 = new Button();
			button2 = new Button();
			button1 = new Button();
			Form1MainPanel = new Panel();
			dateTimePicker1 = new DateTimePicker();
			dropdownmenu = new ComboBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			Form1MainPanel.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveBorder;
			panel1.Controls.Add(button4);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Margin = new Padding(1, 1, 1, 1);
			panel1.Name = "panel1";
			panel1.Size = new Size(700, 28);
			panel1.TabIndex = 0;
			// 
			// button4
			// 
			button4.Location = new Point(608, 5);
			button4.Margin = new Padding(1, 1, 1, 1);
			button4.Name = "button4";
			button4.Size = new Size(21, 22);
			button4.TabIndex = 0;
			button4.Text = "button4";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// panel2
			// 
			panel2.Controls.Add(button3);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button1);
			panel2.Dock = DockStyle.Left;
			panel2.Location = new Point(0, 28);
			panel2.Margin = new Padding(1, 1, 1, 1);
			panel2.Name = "panel2";
			panel2.Size = new Size(108, 272);
			panel2.TabIndex = 1;
			// 
			// button3
			// 
			button3.Location = new Point(18, 172);
			button3.Margin = new Padding(1, 1, 1, 1);
			button3.Name = "button3";
			button3.Size = new Size(80, 22);
			button3.TabIndex = 2;
			button3.Text = "button3";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button2
			// 
			button2.Location = new Point(18, 116);
			button2.Margin = new Padding(1, 1, 1, 1);
			button2.Name = "button2";
			button2.Size = new Size(80, 22);
			button2.TabIndex = 1;
			button2.Text = "button2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Location = new Point(18, 48);
			button1.Margin = new Padding(1, 1, 1, 1);
			button1.Name = "button1";
			button1.Size = new Size(80, 22);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Form1MainPanel
			// 
			Form1MainPanel.Controls.Add(dateTimePicker1);
			Form1MainPanel.Controls.Add(dropdownmenu);
			Form1MainPanel.Dock = DockStyle.Fill;
			Form1MainPanel.Location = new Point(108, 28);
			Form1MainPanel.Margin = new Padding(1, 1, 1, 1);
			Form1MainPanel.Name = "Form1MainPanel";
			Form1MainPanel.Size = new Size(592, 272);
			Form1MainPanel.TabIndex = 2;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(232, 140);
			dateTimePicker1.Margin = new Padding(2, 2, 2, 2);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(211, 23);
			dateTimePicker1.TabIndex = 1;
			dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
			// 
			// dropdownmenu
			// 
			dropdownmenu.DropDownStyle = ComboBoxStyle.DropDownList;
			dropdownmenu.FormattingEnabled = true;
			dropdownmenu.Location = new Point(173, 61);
			dropdownmenu.Margin = new Padding(2, 2, 2, 2);
			dropdownmenu.Name = "dropdownmenu";
			dropdownmenu.Size = new Size(129, 23);
			dropdownmenu.TabIndex = 0;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(700, 300);
			Controls.Add(Form1MainPanel);
			Controls.Add(panel2);
			Controls.Add(panel1);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(1, 1, 1, 1);
			MaximizeBox = false;
			Name = "Form1";
			Text = "Form1";
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			Form1MainPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Panel panel2;
		private Button button1;
		private Button button2;
		internal Panel Form1MainPanel;
		private Button button3;
		private Button button4;
		private ComboBox dropdownmenu;
		private DateTimePicker dateTimePicker1;
	}
}
