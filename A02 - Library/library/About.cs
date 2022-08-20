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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void About_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;

            if (node == treeView1.Nodes[0].Nodes[0])
            {
                richTextBox1.Text = "On the main form there are 4 buttons: Delete, Analysis, About Application and Exit." +
                                    "\n\nBy clicking the 'Delete' button, the selected author is deleted from the table. " +
                                    "\n\nBy clicking on the 'Add' button, a new author is added to the table. " +
                                    "\n\nBy clicking on the 'Analysis' button, a new form is opened on which the analysis is performed. " +
                                    "\n\nBy clicking on the 'About the application' button opens a new form containing all the information related to the application. " +
                                    "\n\nBy clicking on the 'Exit' button, you exit the application. " +
                                    "\n\nIn order to load the author into the fields, click any row in the table.";
            }
            if (node == treeView1.Nodes[0].Nodes[1])
            {
                richTextBox1.Text = "The 'Analysis' form shows the number of times the selected author's works were rented during the given time period." +
                                    "\n\nThe time period is specified in relation to the current date, as well as the selected number of years (in the NumericUpDown control) back." +
                                    "\n\nThe table and graph are shown by clicking the 'View' button.";
            }
            if (node == treeView1.Nodes[0].Nodes[2])
            {
                richTextBox1.Text = "The 'About the application' form displays all the information about the application, such as: About the author, Instructions and Test examples.";
            }
            if (node == treeView1.Nodes[1].Nodes[0])
            {
                richTextBox1.Text = "If the delete button is clicked and an author is not selected from the table, the program will issue a notification.";
            }
            if (node == treeView1.Nodes[1].Nodes[1])
            {
                richTextBox1.Text = "If in the 'Analysis' form the button for displaying in a table and creating graphics is clicked and no author is selected from the comboBox beforehand, the program will issue a notification.";
            }
            if (node == treeView1.Nodes[2])
            {
                richTextBox1.Text = "Full name: Teodora Kanjevac" +
                                    "\nClass: IV-4" +
                                    "\nCourse: Information Technology" +
                                    "\nSchool: ETŠ Nikola Tesla" +
                                    "\nCity: Niš";
            }
        }
    }
}
