using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpE2_DSA_Dullas_26271Sem
{
    public partial class frmArray : Form
    {
        string[] studentName = { "Barsenat", "IshowShawn", "CJ SUNDO", "Ben10" };
        public frmArray()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                lstArray.Items.Clear();
                lstArray.Items.Add(studentName[Convert.ToInt32(txtIndex.Text)]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtIndex.Clear();
                txtIndex.Focus();

            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            DisplayAll();
        }
        private void DisplayAll()
        {
            lstArray.Items.Clear();
            foreach (string studName in studentName)
            {
                lstArray.Items.Add(studName);
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int A = studentName.Length + 1;
                Array.Resize(ref studentName, A);
                studentName[A - 1] = txtValue.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtValue.Clear();
                txtValue.Focus();
            }
            finally
            {
                MessageBox.Show("New value inserted!");
                DisplayAll();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstArray.Items.Clear();
            txtValue.Clear();
            txtIndex.Clear();
        }

        private void lstArray_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
