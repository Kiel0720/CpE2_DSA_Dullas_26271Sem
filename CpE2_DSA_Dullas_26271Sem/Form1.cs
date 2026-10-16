using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpE2_DSA_Dullas_26271Sem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            frmArray frmArray = new frmArray();
            formShow(frmArray, this.splitContainer2.Panel2);
        }

        private void formShow(Form formToShow, Panel formtoShowParent)
        {
            formToShow.TopLevel = false;
            formToShow.WindowState = FormWindowState.Maximized;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Parent = formtoShowParent;
            formToShow.Visible = true;

            formtoShowParent.Controls.Clear();
            formtoShowParent.Controls.Add(formToShow);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLinkedlist_Click_1(object sender, EventArgs e)
        {
            Linkedlist linkedlist = new Linkedlist();
            formShow(linkedlist, this.splitContainer2.Panel2);
        }

        private void btnStack_Click(object sender, EventArgs e)
        {
            formShow(new Stack(), splitContainer2.Panel2);
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            formShow(new Queue(), splitContainer2.Panel2);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            formShow(new List(), splitContainer2.Panel2);
        }

            private void btnMerge_Click(object sender, EventArgs e)
            {
                formShow(new Merge(), splitContainer2.Panel2);
            }
    }
}
