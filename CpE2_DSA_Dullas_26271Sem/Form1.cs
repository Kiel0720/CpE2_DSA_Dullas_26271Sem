using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpE2_DSA_Dullas_26271Sem
{
    public partial class Form1 : Form
    {
        private class BtnAnim
        {
            public Color Back, BackTarget;
            public Color Fore, ForeTarget;
            public float Bar, BarTarget;
        }
        private readonly Dictionary<Button, BtnAnim> anims = new Dictionary<Button, BtnAnim>();
        private Timer animTimer;
        private Button animActive;
        private static readonly Color PressedBack = Color.FromArgb(80, 0, 0);
        public Form1()
        {
            InitializeComponent();
            Button[] menuButtons =
             {
                 btnArray,
                 btnLinkedlist,
                 btnStack,
                 btnQueue,
                 btnList,
                 btnMerge,
                 btnShell,
                 btnHeap
            };
            Button activeButton = null;
            foreach (Button btn in menuButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.UseVisualStyleBackColor = false;
                btn.BackColor = Color.FromArgb(45, 45, 45);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Height = 45;
                btn.MouseEnter += (s, e) => 
                {
                    if (btn != activeButton)
                    {
                        btn.BackColor = Color.FromArgb(128, 0, 0);
                        btn.ForeColor = Color.White;
                    }
                };
                btn.MouseLeave += (s, e) => 
                {
                    if (btn != activeButton)
                    {
                        btn.BackColor = Color.FromArgb(45, 45, 45);
                        btn.ForeColor = Color.White;
                    }
                };

                btn.Click += (s, e) =>
                {
                    if (activeButton != null)
                    {
                        activeButton.BackColor = Color.FromArgb(45, 45, 45);
                        activeButton.ForeColor = Color.White;
                    }
                    activeButton = btn;
                    activeButton.BackColor = Color.FromArgb(0, 133, 119);
                    activeButton.ForeColor = Color.Yellow;
                };
            }
            InitButonAnimations(menuButtons);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += Form1_resize;

            CenterLayout();
        }
        private void SyncTarget(Button btn)
        {
            BtnAnim a = anims[btn];
            bool changed = false;

            if (btn.BackColor != a.Back) { a.BackTarget = btn.BackColor; changed = true; }
            if (btn.ForeColor != a.Fore) { a.ForeTarget = btn.ForeColor; changed = true; }

            ApplyColors(btn, a);
            if (changed) animTimer.Start();
        }

        private void Form1_resize(object sender, EventArgs e)
        {
            CenterLayout();
        }
        private void CenterLayout()
        {
            splitContainer1.Location = new Point(
                (this.ClientSize.Width - splitContainer1.Width) / 2,
                (this.ClientSize.Height - splitContainer1.Height) / 2);
        }
        
        private void InitButonAnimations(Button[] buttons)
        {
            animTimer = new Timer { Interval = 15 };
            animTimer.Tick += AnimTimer_Tick;

            foreach (Button btn in buttons)
            {
                var a = new BtnAnim
                {
                    Back = btn.BackColor,
                    BackTarget = btn.BackColor,
                    Fore = btn.ForeColor,
                    ForeTarget = btn.ForeColor
                };
                anims[btn] = a;
                ApplyColors(btn, a);
                btn.MouseEnter += (s, e) => SyncTarget(btn);
                btn.MouseLeave += (s, e) => SyncTarget(btn);
                btn.MouseDown += (s, e) =>
                {
                    if (btn != animActive)
                    {
                        a.BackTarget = PressedBack;   
                        animTimer.Start();
                    }
                };

                btn.Click += (s, e) =>
                {
                    Button prev = animActive;
                    animActive = btn;

                    if (prev != null && prev != btn)
                    {
                        Capture(prev);                 
                        anims[prev].BarTarget = 0f;   
                    }
                    Capture(btn);                     
                    a.BarTarget = 1f;                  
                    animTimer.Start();
                };
                btn.Paint += (s, e) =>
                {
                    int w = (int)Math.Round(6 * a.Bar);
                    if (w > 0)
                        using (var br = new SolidBrush(Color.Yellow))
                            e.Graphics.FillRectangle(br, 0, 0, w, btn.Height);
                };
            }
        }
        
        private void Capture(Button btn)
        {
            BtnAnim a = anims[btn];
            bool changed = false;

            if (btn.BackColor != a.Back) { a.BackTarget = btn.BackColor; changed = true; }
            if (btn.ForeColor != a.Fore) { a.ForeTarget = btn.ForeColor; changed = true; }

            ApplyColors(btn, a);
            if (changed) animTimer.Start();
        }
        private void ApplyColors(Button btn, BtnAnim a)
        {
            btn.BackColor = a.Back;
            btn.ForeColor = a.Fore;
            btn.FlatAppearance.MouseOverBackColor = a.Back;
            btn.FlatAppearance.MouseDownBackColor = a.Back;
        }

        private static int StepChannel(int cur, int tgt)
        {
            if (cur == tgt) return cur;
            int delta = (int)Math.Round((tgt - cur) * 0.25);
            if (delta == 0) delta = tgt > cur ? 1 : -1;       
            return cur + delta;
        }

        private static Color StepColor(Color cur, Color tgt)
        {
            return Color.FromArgb(
                StepChannel(cur.R, tgt.R),
                StepChannel(cur.G, tgt.G),
                StepChannel(cur.B, tgt.B));
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            bool moving = false;

            foreach (var kv in anims)
            {
                Button btn = kv.Key;
                BtnAnim a = kv.Value;

                Color newBack = StepColor(a.Back, a.BackTarget);
                Color newFore = StepColor(a.Fore, a.ForeTarget);
                float newBar = a.Bar + (a.BarTarget - a.Bar) * 0.25f;
                if (Math.Abs(a.BarTarget - newBar) < 0.02f) newBar = a.BarTarget;

                if (newBack != a.Back || newFore != a.Fore || newBar != a.Bar)
                {
                    a.Back = newBack;
                    a.Fore = newFore;
                    a.Bar = newBar;
                    ApplyColors(btn, a);
                    btn.Invalidate();
                    moving = true;
                }
            }

            if (!moving) animTimer.Stop();
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
            formToShow.Dock = DockStyle.Fill;

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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnShell_Click(object sender, EventArgs e)
        {
            formShow(new Shell(), splitContainer2.Panel2);
        }

        private void btnHeap_Click(object sender, EventArgs e)
        {
            formShow(new Heap(), splitContainer2.Panel2);
        }
    }
}