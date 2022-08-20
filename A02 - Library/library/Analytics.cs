using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analiza_Load(object sender, EventArgs e)
        {
            cbxAuthor.DataSource = Author.LoadComboBox();
            cbxAuthor.ValueMember = "ID";
            cbxAuthor.DisplayMember = "FullName";
            cbxAuthor.SelectedIndex = -1;
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            if (cbxAuthor.SelectedIndex !=-1)
            {
                int id = (int)cbxAuthor.SelectedValue;
                int period = (int)numGod.Value;
                DataTable dt = Statistics.Chart(period, id);

                dataGridView1.DataSource = dt;
                chart1.DataSource = dt;

                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chart1.Series[0].XValueMember = "Year";
                chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chart1.Series[0].YValueMembers = "Number";
            }
            else
            {
                MessageBox.Show("Choose an author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
