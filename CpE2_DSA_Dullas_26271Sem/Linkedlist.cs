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
                txtValue.Focus();
            }
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
            current = Llist.Find(Convert.ToInt32(txtCurrent.Text));
            try
            {
                switch (cmbAddBeforeAfter.Text)
                {
                    case "AddBefore":
                        Llist.AddBefore(current, Convert.ToInt32(txtValue2.Text));
                        break;
                    case "AddAfter":
                        Llist.AddAfter(current, Convert.ToInt32(txtValue2.Text));
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
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Count: " + Llist.Count.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstLinkedlist.Items.Clear();
            txtValue.Clear();
            txtCurrent.Clear();
            txtValue2.Clear();
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
        }
    }
}
