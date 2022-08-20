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
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Analytics form = new Analytics();
            form.ShowDialog();
        }

        public void RefreshListView()
        {
            listView1.Items.Clear();
            DataTable dt = Author.Load();
            foreach (DataRow row in dt.Rows)
            {
                string[] data = new string[5];

                data[0] = row[0].ToString();
                data[1] = row[1].ToString();
                data[2] = row[2].ToString();
                data[3] = row[3].ToString();
                data[4] = row[4].ToString();

                ListViewItem item = new ListViewItem(data);
                listView1.Items.Add(item);
            }
        }

        private void Forma_Load(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string id = listView1.SelectedItems[0].Text;
                DataTable dt = Author.LoadFields(id);

                txtID.Text = dt.Rows[0][0].ToString();
                txtFName.Text = dt.Rows[0][1].ToString();
                txtLName.Text = dt.Rows[0][2].ToString();
                masktxtDoB.Text = dt.Rows[0][3].ToString();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string id = txtID.Text;
            DataTable dt = Author.LoadFields(id);

            try
            {
                if (dt.Rows.Count == 0)
                {
                    txtFName.Text = "";
                    txtLName.Text = "";
                    masktxtDoB.Text = "";
                }
                else
                {
                    txtFName.Text = dt.Rows[0][1].ToString();
                    txtLName.Text = dt.Rows[0][2].ToString();
                    masktxtDoB.Text = dt.Rows[0][3].ToString();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)  return;
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose any author from the table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string id = txtID.Text;

                int.Parse(id);
                bool b;
                b = Author.Delete(id);
                if (b)
                {
                    MessageBox.Show("Author deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshListView();
                    txtID.Text = string.Empty;
                    txtFName.Text = string.Empty;
                    txtLName.Text = string.Empty;
                    masktxtDoB.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Author not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFName.Text == string.Empty || txtLName.Text == string.Empty || !masktxtDoB.MaskCompleted)
                {
                    MessageBox.Show("You have not entered all the information. Please enter all information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string id = txtID.Text;
                    string fname = txtFName.Text;
                    string lname = txtLName.Text;
                    DateTime dob = Convert.ToDateTime(masktxtDoB.Text);

                    int.Parse(id);
                    bool b;
                    b = Author.Add(id, fname, lname, dob);
                    if (b)
                    {
                        MessageBox.Show("Author added successfully.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshListView();
                        txtID.Text = string.Empty;
                        txtFName.Text = string.Empty;
                        txtLName.Text = string.Empty;
                        masktxtDoB.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Author not added. (Perhaps the author with the ID you entered already exists?)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have not entered an adequate format for the ID or date. Please re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
