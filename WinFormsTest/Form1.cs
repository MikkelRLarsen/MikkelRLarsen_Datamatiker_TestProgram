using WinFormsTest.CreateCustomer;
using WinFormsTest.Forms;

namespace WinFormsTest
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
			Personer[] personer = { new Personer(1, "Mikkel L"), new Personer(2, "Sarah") };
			List<Personer> list = new List<Personer>();
			list.Add(new Personer(1, "Mikkel L"));
			list.Add(new Personer(2, "Sarah"));

			List<string> strings = new List<string>();
			strings.Add("Dyrelæge");
			strings.Add("Receptionist");

			string[] stringArr = { "Dyrelæge", "Receptionist" };


			dropdownmenu.DataSource = stringArr;
			//dropdownmenu.DisplayMember = "Name";

			var selectedMember = dropdownmenu.SelectedItem;



			dateTimePicker1.MinDate = DateTime.Now;
			dateTimePicker1.MaxDate = DateTime.Now.AddDays(365);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadForm(new BigBoy());
		}

		public void LoadForm(UserControl Form)
		{
			if (Form1MainPanel.Controls.Count > 0) Form1MainPanel.Controls.Clear();

			Form1MainPanel.Controls.Add(Form);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadForm(new BigBoy());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form1MainPanel.Controls.Clear();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			LoadForm(new CreateCustomerMain());
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			var value = dateTimePicker1.Value;
		}
	}
}
