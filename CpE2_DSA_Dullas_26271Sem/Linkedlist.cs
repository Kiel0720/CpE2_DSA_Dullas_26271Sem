using System;
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
    public partial class Linkedlist : Form
    {
        int[] myint = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        LinkedList<int> Llist = new LinkedList<int>();
        LinkedListNode<int> current;
        public Linkedlist()
        {
            InitializeComponent();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            DisplayAll();
        }
        private void DisplayAll()
        {
            lstLinkedlist.Items.Clear();
            foreach (int value in Llist)
            {
                lstLinkedlist.Items.Add(value);
            }
        }
        private void Linkedlist_Load(object sender, EventArgs e)
        {
            LoadArrayToLinkedList();
        }
        private void LoadArrayToLinkedList()
        {
            Llist.Clear();
            foreach (int myint in myint)
            {
                Llist.AddLast(myint);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbAddNew.Text)
                {
                    case "AddFirst":
                        Llist.AddFirst(Convert.ToInt32(txtValue.Text));
                        break;
                    case "AddLast":
                        Llist.AddLast(Convert.ToInt32(txtValue.Text));
                        break;
                    default:
                        MessageBox.Show("Please select an option to insert.");
                        break;
                }
                DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            txtValue.Clear();
            txtValue.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbRemove.Text)
                {
                    case "RemoveFirst":
                        Llist.RemoveFirst();
                        break;
                    case "RemoveLast":
                        Llist.RemoveLast();
                        break;
                    default:
                        MessageBox.Show("Please select an option to remove.");
                        break;
                }
                DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnInsertBeforeAfter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCurrent.Text, out int currentValue))
                {
                    MessageBox.Show("Please enter a valid number for the current node.");
                    txtCurrent.Focus();
                    return;
                }

                if (!int.TryParse(txtValue2.Text, out int newValue))
                {
                    MessageBox.Show("Please enter a valid number for the new value.");
                    txtValue2.Focus();
                    return;
                }

                current = Llist.Find(currentValue);

                if (current == null)
                {
                    MessageBox.Show("The current value was not found in the list.");
                    return;
                }

                switch (cmbAddBeforeAfter.Text)
                {
                    case "AddBefore":
                        Llist.AddBefore(current, newValue);
                        break;
                    case "AddAfter":
                        Llist.AddAfter(current, newValue);
                        break;
                    default:
                        MessageBox.Show("Please select an option to insert.");
                        return;
                }

                DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtValue2.Clear();
            txtValue2.Focus();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Count: " + Llist.Count.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstLinkedlist.Items.Clear();
            Llist.Clear();
            txtValue.Clear();
            txtValue2.Clear();
            txtFind.Clear();
            txtCurrent.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadArrayToLinkedList();
            DisplayAll();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                LinkedListNode<int> Found = Llist.Find(Convert.ToInt32(txtFind.Text));
                if (Found != null)
                {
                    MessageBox.Show("Value Found: " + Found.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Value Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            txtFind.Clear();
            txtFind.Focus();
        }
    }
}
