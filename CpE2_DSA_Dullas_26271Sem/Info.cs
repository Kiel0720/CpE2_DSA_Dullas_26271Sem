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
    public partial class Info : Form
    {
        private class AlgoInfo
        {
            public string Name, Tagline, Description, DevBy, Year, HistoryText, ExampleNote;
            public string[] WorldUse, Steps, ExampleLines;
        }
        private static readonly Color Dark = Color.FromArgb(45, 45, 45);
        private static readonly Color Maroon = Color.FromArgb(128, 0, 0);
        private static readonly Color Teal = Color.FromArgb(0, 133, 119);
        private static readonly Color CardBack = Color.FromArgb(62, 66, 75);

        private readonly Dictionary<Button, AlgoInfo> data = new Dictionary<Button, AlgoInfo>();
        private Button active;
        private FlowLayoutPanel root;

        private Control Host { get { return splitContainer1.Panel2; } }

        public Info()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;   // gives the popup a close (X) button
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Text = "Sort Algorithm Information";
            LoadData();
            StyleButtons();
            BuildRoot();
            SelectAlgo(btnMergeInfo);
        }

        private void btnMergeInfo_Click(object sender, EventArgs e) { SelectAlgo(btnMergeInfo); }
        private void btnShellInfo_Click(object sender, EventArgs e) { SelectAlgo(btnShellInfo); }
        private void btnHeapInfo_Click(object sender, EventArgs e) { SelectAlgo(btnHeapInfo); }
        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void LoadData()
        {
            data[btnMergeInfo] = new AlgoInfo
            {
                Name = "MERGE SORT",
                Tagline = "Divide and conquer: split, sort, then merge back together.",
                Description = "Merge Sort is a comparison-based sorting algorithm that follows the divide-and-conquer strategy. It splits the list into smaller halves, sorts each half, and then merges the sorted halves back into one sorted list. It takes O(n log n) time in every case and is stable, but it needs O(n) extra memory.",
                DevBy = "John von Neumann",
                Year = "1945",
                HistoryText = "Merge Sort was invented by the mathematician John von Neumann in 1945 for early stored-program computers such as the EDVAC, which makes it one of the oldest sorting algorithms still in use. A detailed description and analysis of the bottom-up version appeared in a 1948 report by Goldstine and von Neumann.",
                WorldUse = new[]
                {
            "Python and Java: the built-in sort for lists and objects uses Timsort, a hybrid of merge sort and insertion sort.",
            "Big data and databases: sorting files that are too large for memory (external sorting) and the merge phase of systems like Hadoop MapReduce.",
            "Stable sorting: ordering records by several keys, such as sorting students by section and then by name, without losing the earlier order.",
            "Linked lists: it only needs sequential access, so it is a top choice for sorting linked lists.",
            "Parallel computing: the two halves can be sorted at the same time on different processors."
        },
                Steps = new[]
                {
            "Divide: split the array into a left half and a right half at the middle index.",
            "Recurse: keep dividing each half until every sub-array has only 1 element. One element is already sorted.",
            "Merge: compare the front elements of the two sorted halves and copy the smaller one into a temporary array.",
            "Copy any leftover elements, then write the merged result back. Keep merging upward until the whole array is sorted."
        },
                ExampleNote = "Brackets show the groups at each level.",
                ExampleLines = new[]
                {
            "Input     38 27 43 3 9 82 10",
            "Split 1   [38 27 43 3] [9 82 10]",
            "Split 2   [38 27] [43 3] [9 82] [10]",
            "Split 3   [38] [27] [43] [3] [9] [82] [10]",
            "Merge 1   [27 38] [3 43] [9 82] [10]",
            "Merge 2   [3 27 38 43] [9 10 82]",
            "Merge 3   [3 9 10 27 38 43 82]"
        }
            };

            data[btnShellInfo] = new AlgoInfo
            {
                Name = "SHELL SORT",
                Tagline = "An improved insertion sort that compares far-apart elements first.",
                Description = "Shell Sort is an in-place, comparison-based algorithm that generalizes insertion sort. Instead of comparing only neighbors, it first compares and moves elements that are far apart (separated by a gap), then keeps shrinking the gap until it is 1. This lets small values travel quickly toward the front, so the final insertion pass has very little work left.",
                DevBy = "Donald L. Shell",
                Year = "1959",
                HistoryText = "Shell Sort was published by the American computer scientist Donald L. Shell in 1959 in the Communications of the ACM, in a paper called A High-Speed Sorting Procedure. It was one of the first sorting algorithms to beat O(n\u00B2) in practice, and it started decades of research into better gap sequences, such as those by Knuth, Sedgewick and Ciura.",
                WorldUse = new[]
                {
            "Embedded systems and microcontrollers: it needs no extra memory and no recursion, so it fits tiny devices.",
            "Small C libraries: some compact qsort implementations for low-memory systems have used Shell sort.",
            "Medium-sized data: a simple way to get good speed on arrays of a few thousand items without complicated code.",
            "Teaching: a natural step up from insertion sort for learning how gap sequences improve performance."
        },
                Steps = new[]
                {
            "Choose a starting gap, commonly n / 2 (Shell's original sequence).",
            "Do an insertion sort on elements that are gap positions apart, so far-away items jump closer to their final place.",
            "Reduce the gap (for example, divide it by 2) and repeat the gapped insertion sort.",
            "When the gap reaches 1, run a normal insertion sort. The array is nearly sorted, so this last pass is quick."
        },
                ExampleNote = "Each row shows the whole array after that pass (n = 7, so the first gap is 7 / 2 = 3).",
                ExampleLines = new[]
                {
            "Input     38 27 43 3 9 82 10",
            "Gap = 3   3 9 43 10 27 82 38",
            "Gap = 1   3 9 10 27 38 43 82"
        }
            };

            data[btnHeapInfo] = new AlgoInfo
            {
                Name = "HEAP SORT",
                Tagline = "Uses a binary heap to repeatedly pull out the largest element.",
                Description = "Heap Sort is an in-place, comparison-based algorithm built on the binary heap data structure. It first arranges the array into a max-heap, where every parent is larger than its children, so the largest value sits at the root. It then repeatedly moves the root to the end of the array and repairs the heap, growing a sorted section from the back.",
                DevBy = "J. W. J. Williams",
                Year = "1964",
                HistoryText = "Heap Sort was introduced by J. W. J. Williams in 1964, who also invented the binary heap data structure for it. In the same year, Robert W. Floyd published an improved way to build the heap in linear time, which made it the efficient in-place sort we know today.",
                WorldUse = new[]
                {
            "Operating systems: the Linux kernel uses heap sort in its generic sort function because it is in-place and needs no recursion.",
            "Introsort: many implementations of C++ std::sort switch to heap sort when quicksort recursion gets too deep, guaranteeing O(n log n).",
            "Priority queues and schedulers: the heap idea behind it powers task schedulers, event simulations and Dijkstra's shortest-path algorithm.",
            "Real-time and safety-critical systems: guaranteed O(n log n) time with O(1) extra memory makes the running time predictable."
        },
                Steps = new[]
                {
            "Build a max-heap from the array by heapifying from the last parent down to the root. The children of index i are at 2i + 1 and 2i + 2.",
            "Swap the root (largest value) with the last element of the heap. That value is now in its final sorted position.",
            "Shrink the heap size by 1, then sift the new root down to restore the max-heap property.",
            "Repeat steps 2 and 3 until only one element is left. The array is now sorted in ascending order."
        },
                ExampleNote = "The | separates the heap (left) from the sorted part (right).",
                ExampleLines = new[]
                {
            "Input       38 27 43 3 9 82 10",
            "Build heap  82 27 43 3 9 38 10",
            "Extract 82  43 27 38 3 9 10 | 82",
            "Extract 43  38 27 10 3 9 | 43 82",
            "Extract 38  27 9 10 3 | 38 43 82",
            "Extract 27  10 9 3 | 27 38 43 82",
            "Extract 10  9 3 | 10 27 38 43 82",
            "Extract 9   3 | 9 10 27 38 43 82",
            "Sorted      3 9 10 27 38 43 82"
        }
            };
        }

        private static void Recolor(Button b, Color back, Color fore)
        {
            b.BackColor = back;
            b.ForeColor = fore;
            b.FlatAppearance.MouseOverBackColor = back;
            b.FlatAppearance.MouseDownBackColor = back;
        }

        private void StyleButtons()
        {
            Button[] btns = { btnMergeInfo, btnShellInfo, btnHeapInfo };
            Control group = btnMergeInfo.Parent;
            int y = 28;

            foreach (Button b in btns)
            {
                Button btn = b;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.UseVisualStyleBackColor = false;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                Recolor(btn, Dark, Color.White);

                btn.SetBounds(12, y, group.ClientSize.Width - 24, 45);
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                y += 45 + 10;

                btn.MouseEnter += (s, e) => { if (btn != active) Recolor(btn, Maroon, Color.White); };
                btn.MouseLeave += (s, e) => { if (btn != active) Recolor(btn, Dark, Color.White); };
                btn.Paint += (s, e) =>
                {
                    if (btn == active)
                        using (var br = new SolidBrush(Color.Yellow))
                            e.Graphics.FillRectangle(br, 0, 0, 6, btn.Height);
                };
            }
        }

        private void SelectAlgo(Button btn)
        {
            Button prev = active;
            active = btn;

            if (prev != null && prev != btn)
            {
                Recolor(prev, Dark, Color.White);
                prev.Invalidate();
            }
            Recolor(btn, Teal, Color.Yellow);
            btn.Invalidate();

            Render(data[btn]);
        }

        private void BuildRoot()
        {
            root = new FlowLayoutPanel();
            root.Dock = DockStyle.Fill;
            root.FlowDirection = FlowDirection.TopDown;
            root.WrapContents = false;
            root.AutoScroll = true;
            root.Padding = new Padding(16, 12, 16, 12);
            root.BackColor = Color.Transparent;
            Host.Controls.Add(root);

            Host.Resize += (s, e) =>
            {
                if (active != null) Render(data[active]);
            };
        }

        private Label MakeLabel(string text, Font font, Color fore, int width)
        {
            Label l = new Label();
            l.AutoSize = false;
            l.Text = text;
            l.Font = font;
            l.ForeColor = fore;
            l.BackColor = Color.Transparent;
            l.Width = width;
            l.Height = TextRenderer.MeasureText(text, font, new Size(width, 0), TextFormatFlags.WordBreak).Height + 4;
            l.Margin = new Padding(0, 0, 0, 6);
            return l;
        }
        private void AddSection(string title, int w)
        {
            Label l = MakeLabel(title, new Font("Segoe UI", 12, FontStyle.Bold), Color.Yellow, w);
            l.Margin = new Padding(0, 10, 0, 2);
            root.Controls.Add(l);

            Panel line = new Panel();
            line.BackColor = Maroon;
            line.Size = new Size(w, 3);
            line.Margin = new Padding(0, 0, 0, 10);
            root.Controls.Add(line);
        }
        private Panel MakeTextCard(string text, int w)
        {
            Panel p = new Panel();
            p.BackColor = CardBack;
            p.Margin = new Padding(0, 0, 0, 8);
            Label l = MakeLabel(text, new Font("Segoe UI", 11), Color.White, w - 32);
            l.Location = new Point(16, 12);
            p.Controls.Add(l);
            p.Size = new Size(w, l.Height + 24);
            return p;
        }

        private Panel MakeFactCard(string caption, string value, int cw, int x)
        {
            Panel card = new Panel();
            card.BackColor = CardBack;
            card.Size = new Size(cw, 82);
            card.Location = new Point(x, 0);

            Label val = new Label();
            val.Text = value;
            val.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            val.ForeColor = Color.Yellow;
            val.TextAlign = ContentAlignment.MiddleCenter;
            val.AutoSize = false;
            val.SetBounds(0, 12, cw, 34);

            Label cap = new Label();
            cap.Text = caption;
            cap.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            cap.ForeColor = Color.Gainsboro;
            cap.TextAlign = ContentAlignment.MiddleCenter;
            cap.AutoSize = false;
            cap.SetBounds(0, 50, cw, 24);

            Panel accent = new Panel();
            accent.BackColor = Teal;
            accent.Dock = DockStyle.Top;
            accent.Height = 4;

            card.Controls.Add(val);
            card.Controls.Add(cap);
            card.Controls.Add(accent);
            return card;
        }

        private Panel MakeBulletRow(string text, int w)
        {
            Panel p = new Panel();
            p.BackColor = CardBack;
            p.Margin = new Padding(0, 0, 0, 6);

            Label l = MakeLabel(text, new Font("Segoe UI", 11), Color.White, w - 36);
            l.Location = new Point(20, 10);

            Panel bar = new Panel();
            bar.BackColor = Teal;
            bar.Dock = DockStyle.Left;
            bar.Width = 6;

            p.Controls.Add(l);
            p.Controls.Add(bar);
            p.Size = new Size(w, l.Height + 20);
            return p;
        }

        private Panel MakeCodeCard(string[] lines, int w)
        {
            Panel p = new Panel();
            p.BackColor = Color.FromArgb(30, 33, 39);
            p.Margin = new Padding(0, 0, 0, 8);

            Label l = MakeLabel(string.Join(Environment.NewLine, lines),
                                new Font("Consolas", 11), Color.FromArgb(235, 235, 235), w - 32);
            l.Location = new Point(16, 12);
            p.Controls.Add(l);
            p.Size = new Size(w, l.Height + 24);
            return p;
        }

        private void Render(AlgoInfo a)
        {
            int w = Host.ClientSize.Width - root.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth;
            if (w < 300) return;

            root.SuspendLayout();
            while (root.Controls.Count > 0) root.Controls[0].Dispose();

            // Title + tagline
            root.Controls.Add(MakeLabel(a.Name, new Font("Segoe UI", 26, FontStyle.Bold), Color.Yellow, w));
            root.Controls.Add(MakeLabel(a.Tagline, new Font("Segoe UI", 12), Color.White, w));

            // 1. DESCRIPTION
            AddSection("DESCRIPTION", w);
            root.Controls.Add(MakeTextCard(a.Description, w));

            // 2. HISTORY
            AddSection("HISTORY", w);
            int half = (w - 8) / 2;
            Panel hrow = new Panel();
            hrow.Size = new Size(w, 82);
            hrow.Margin = new Padding(0, 0, 0, 8);
            hrow.Controls.Add(MakeFactCard("DEVELOPED BY", a.DevBy, half, 0));
            hrow.Controls.Add(MakeFactCard("YEAR DEVELOPED", a.Year, half, half + 8));
            root.Controls.Add(hrow);
            root.Controls.Add(MakeTextCard(a.HistoryText, w));

            // 3. USEFUL AROUND THE WORLD
            AddSection("HOW IT IS USED AROUND THE WORLD", w);
            foreach (string u in a.WorldUse)
                root.Controls.Add(MakeBulletRow(u, w));

            // 4. EXPLANATION
            AddSection("HOW THE ALGORITHM SORTS", w);
            for (int i = 0; i < a.Steps.Length; i++)
            {
                Panel step = new Panel();
                step.BackColor = CardBack;
                step.Margin = new Padding(0, 0, 0, 6);

                Label num = new Label();
                num.Text = (i + 1).ToString();
                num.BackColor = Teal;
                num.ForeColor = Color.Yellow;
                num.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                num.TextAlign = ContentAlignment.MiddleCenter;
                num.AutoSize = false;
                num.SetBounds(8, 8, 36, 36);

                Label txt = MakeLabel(a.Steps[i], new Font("Segoe UI", 11), Color.White, w - 64);
                txt.Location = new Point(56, 10);

                step.Size = new Size(w, Math.Max(52, txt.Height + 20));
                step.Controls.Add(num);
                step.Controls.Add(txt);
                root.Controls.Add(step);
            }

            // Worked example
            Label exTitle = MakeLabel("WORKED EXAMPLE", new Font("Segoe UI", 11, FontStyle.Bold),
                                      Color.FromArgb(80, 220, 170), w);
            exTitle.Margin = new Padding(0, 10, 0, 0);
            root.Controls.Add(exTitle);
            root.Controls.Add(MakeLabel(a.ExampleNote, new Font("Segoe UI", 10), Color.Gainsboro, w));
            root.Controls.Add(MakeCodeCard(a.ExampleLines, w));

            root.ResumeLayout();
            root.AutoScrollPosition = new Point(0, 0);
        }

        private void btnArray_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMergeInfo = new System.Windows.Forms.Button();
            this.btnShellInfo = new System.Windows.Forms.Button();
            this.btnHeapInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout(); 
            this.groupBox1.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint_1); 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint_1);
            this.groupBox2.Controls.Add(this.btnHeapInfo);
            this.groupBox2.Controls.Add(this.btnShellInfo);
            this.groupBox2.Controls.Add(this.btnMergeInfo);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            resources.ApplyResources(this.btnMergeInfo, "btnMergeInfo");
            this.btnMergeInfo.Name = "btnMergeInfo";
            this.btnMergeInfo.UseVisualStyleBackColor = true;
            this.btnMergeInfo.Click += new System.EventHandler(this.btnMergeInfo_Click);
            resources.ApplyResources(this.btnShellInfo, "btnShellInfo");
            this.btnShellInfo.Name = "btnShellInfo";
            this.btnShellInfo.UseVisualStyleBackColor = true;
            this.btnShellInfo.Click += new System.EventHandler(this.btnShellInfo_Click);
            resources.ApplyResources(this.btnHeapInfo, "btnHeapInfo");
            this.btnHeapInfo.Name = "btnHeapInfo";
            this.btnHeapInfo.UseVisualStyleBackColor = true;
            this.btnHeapInfo.Click += new System.EventHandler(this.btnHeapInfo_Click);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Info";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private Button btnHeapInfo;
        private Button btnShellInfo;
        private Button btnMergeInfo;
    }
}