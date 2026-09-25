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
    public partial class Queue : Form
    {
        Queue<string> myQueue = new Queue<string>();
        public Queue()
        {
            InitializeComponent();
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQueueValue.Text == "")
                {
                    MessageBox.Show("Please enter a value to enqueue.");
                } 
                else 
                { 
                    myQueue.Enqueue(txtQueueValue.Text);
                    DisplayAll();
                    txtQueueValue.Clear(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtQueueValue.Focus();
        }
        private void DisplayAll()
        {
            lstQueue.Items.Clear();
            foreach (string myqueue in myQueue)
            {
                lstQueue.Items.Add(myqueue);
            }
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            try
            {
                myQueue.Dequeue();
                txtQueueValue.Clear();
                DisplayAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtQueueValue.Focus();
        }

        private void btnContain_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = myQueue.Contains(txtQueueValue.Text);

                if (found)
                {
                    MessageBox.Show("The value " + txtQueueValue.Text + " is in the queue.");
                }
                else
                {
                    MessageBox.Show("The value " + txtQueueValue.Text + " is not in the queue.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtQueueValue.Clear() ;
            txtQueueValue.Focus();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            try
            {
                myQueue.Peek();
                MessageBox.Show("The top value is: " + myQueue.Peek());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstQueue.Items.Clear();
            myQueue.Clear();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The queue contains " + myQueue.Count + " items.");
        }

        private void lstQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
