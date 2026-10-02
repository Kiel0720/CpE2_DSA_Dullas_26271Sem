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
    public partial class List : Form
    {

        List<string> myList = new List<string>();

        public List()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string value = txtList.Text;

            if (value == "")
            {
                MessageBox.Show("Enter a value.");
                return;
            }

            if (txtRemoveAtIndexOf.Text == "")
            {
                myList.Add(value);
            }
            else
            {
                int index;

                if (!int.TryParse(txtRemoveAtIndexOf.Text, out index))
                {
                    MessageBox.Show("Enter a valid index.");
                    return;
                }

                if (index < 0 || index > myList.Count)
                {
                    MessageBox.Show("Invalid index.");
                    return;
                }

                myList.Insert(index, value);
            }
            DisplayAll();
            txtList.Clear();
            txtRemoveAtIndexOf.Clear();
            txtList.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string value = txtList.Text;
            int index;

            if (!int.TryParse(txtRemoveAtIndexOf.Text, out index))
            {
                MessageBox.Show("Enter a Value to the index box.");
                return;
            }

            if (index < 0 || index > myList.Count)
            {
                MessageBox.Show("Aw Invalid index. Try Again.");
                return;
            }
            myList.Insert(index, value);
            DisplayAll();
            txtList.Clear();
            txtRemoveAtIndexOf.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtList.Text))
                {
                    MessageBox.Show("Enter a Value");
                    return;
                }
                if (myList.Remove(txtList.Text))
                {
                    DisplayAll();
                    txtList.Clear();
                }
                else
                {
                    MessageBox.Show("Value not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
        }
        private void DisplayAll()
        {
            lstbList.Items.Clear();
            foreach (string item in myList)
            {
                lstbList.Items.Add(item);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            myList.Clear(); 
            DisplayAll();
        }

        private void btnRemoveAt_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRemoveAtIndexOf.Text, out int index))
            {
                MessageBox.Show("Please enter a valid index value.");
                return;
            }
            txtRemoveAtIndexOf.Clear();
            txtRemoveAtIndexOf.Focus();

            if (index < 0 || index >= myList.Count)
            {
                MessageBox.Show("Index value is outside the List.");
                return;
            }
            txtRemoveAtIndexOf.Focus();
            txtRemoveAtIndexOf.SelectAll();
            myList.RemoveAt(index);
            DisplayAll();
        }

        private void btnIndexOf_Click(object sender, EventArgs e)
        {
            string value = txtRemoveAtIndexOf.Text;

            int index = myList.IndexOf(value);

            if (index == -1)
            {
                MessageBox.Show(value + " was not found.");
            }
            else
            {
                MessageBox.Show(
                    value + " is at index " + index
                );
            }
            txtRemoveAtIndexOf.Clear();
            txtRemoveAtIndexOf.Focus();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Number of items: " + myList.Count
            );
        }

        private void btnContains_Click(object sender, EventArgs e)
        {
            string value = txtRemoveAtIndexOf.Text;

            if (myList.Contains(value))
            {
                MessageBox.Show(
                    "The "  +   value + " is in the List."
                );
            }
            else
            {
                MessageBox.Show(
                    "The "   +   value + " is not in the List."
                );
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            myList.Sort();
            DisplayAll();
        }

        private void txtList_TextChanged(object sender, EventArgs e)
        {

        }
    }
}