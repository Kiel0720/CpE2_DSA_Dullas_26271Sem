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
    public partial class Stack : Form
    {
        Stack<string> myStack = new Stack<string>();
        public Stack()
        {
            InitializeComponent();
        }

        private void Stack_Load(object sender, EventArgs e)
        {

        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStackValue.Text == "")
                {
                    MessageBox.Show("Please enter a value to push.");
                }
                else
                {
                    myStack.Push(txtStackValue.Text);
                    DisplayAll();
                    txtStackValue.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtStackValue.Focus();
        }

        private void DisplayAll()
        {
            lstStack.Items.Clear();
            foreach (string mystack in myStack)
            {
                lstStack.Items.Add(mystack);   
            }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                myStack.Pop();
                txtStackValue.Clear();
                DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtStackValue.Focus();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            try
            {
                myStack.Peek();
                MessageBox.Show("The top value is: " + myStack.Peek());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The number of Values in the stack is: " + myStack.Count());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstStack.Items.Clear();
            myStack.Clear();
        }

        private void btnContain_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = myStack.Contains(txtStackValue.Text);

                if (found)
                {
                    MessageBox.Show("The value " + txtStackValue.Text + " is in the stack.");
                }
                else
                {
                    MessageBox.Show("The value is not in the stack.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtStackValue.Clear();
            txtStackValue.Focus();
        }
    }
}
