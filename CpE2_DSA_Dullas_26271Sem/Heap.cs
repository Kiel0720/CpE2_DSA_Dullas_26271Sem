using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CpE2_DSA_Dullas_26271Sem
{
    public partial class Heap : Form
    {
        const int Idle = 0, Active = 1, Compare = 2, Swapped = 3, Done = 4;
        const int BoxH = 50, Gap = 10, Margin = 20, RowStep = 30, MaxItems = 15;
        const string Example = "38, 27, 43, 3, 9, 82, 10";
        static readonly Color[] Colors =
        {
            Color.FromArgb(138, 158, 176), Color.FromArgb(173, 216, 230), Color.FromArgb(255, 183, 77),
            Color.FromArgb(144, 238, 144), Color.FromArgb(102, 205, 130)
        };
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(IntPtr h, int msg, IntPtr w, string l);
        class Step { public int[] Order, Marks; public string Text; }
        string AlgoName = "Heap Sort", Info = "Build a max-heap, then keep moving the largest item to the end.";
        string[] values = new string[0];
        int[] ids;
        readonly Button btnClear = new Button { Text = "Clear" };
        readonly Timer timer = new Timer { Interval = 15 };
        readonly Stopwatch clock = Stopwatch.StartNew();
        readonly List<Step> steps = new List<Step>();
        readonly Font font = new Font("Segoe UI", 12F, FontStyle.Bold);
        readonly Font smallFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        readonly Font hintFont = new Font("Segoe UI", 10.5F);
        Button[] buttons;
        Label title;
        float[] sx, sy, tx, ty;
        Color[] sc, tc;
        bool numeric, sliding, playing;
        int shown;
        float progress = 1f, slideMs;
        long slideStart;
        public Heap() { InitializeComponent(); Setup(); }
        void Setup()
        {
            DoubleBuffered = true;
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            typeof(Control).GetProperty("DoubleBuffered", flags)?.SetValue(pnlAnimation, true, null);
            txtArray.Font = new Font("Segoe UI", 16F);
            txtArray.BorderStyle = BorderStyle.FixedSingle;
            txtArray.TextChanged += (s, e) => UpdateButtons();
            txtArray.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; OnGenerate(s, e); }
            };
            string cue = "Type numbers, words or letters, e.g.  " + Example;
            Shown += (s, e) => SendMessage(txtArray.Handle, 0x1501, (IntPtr)1, cue);
            btnGenerate.Click += OnGenerate;
            btnStart.Click += OnStart;
            btnPause.Click += (s, e) => { playing = false; UpdateButtons(); };
            btnNext.Click += (s, e) => { playing = false; StepForward(); UpdateButtons(); };
            btnReset.Click += (s, e) =>
            {
                if (steps.Count > 0) { playing = false; GoTo(0); UpdateButtons(); }
            };
            btnClear.Click += OnClear;
            pnlAnimation.Parent.Controls.Add(btnClear);
            buttons = new[] { btnGenerate, btnStart, btnPause, btnNext, btnReset, btnClear };
            string[] hex = { "#800000", "#2EA043", "#E6911E", "#2D7DD2", "#6E6E78", "#AA283C" };
            for (int i = 0; i < buttons.Length; i++) StyleButton(buttons[i], ColorTranslator.FromHtml(hex[i]));
            title = new Label { Text = AlgoName.Replace(" Sort", "").ToUpper() + " ALGORITHM" };
            pnlAnimation.Parent.Controls.Add(title);
            title.Paint += PaintTitle;
            LayoutControls();
            pnlAnimation.Paint += PaintPanel;
            pnlAnimation.LocationChanged += (s, e) => LayoutControls();
            pnlAnimation.SizeChanged += (s, e) => { LayoutControls(); pnlAnimation.Invalidate(); };
            timer.Tick += Timer_Tick;
            UpdateButtons();
        }

        void Sort()
        {
            int n = ids.Length;
            for (int i = n / 2 - 1; i >= 0; i--) SiftDown(n, i, "Build heap");
            Add("Max-heap built: the largest item is at the front.", HeapMarks(n));
            for (int end = n - 1; end > 0; end--)
            {
                Swap(0, end);
                Add($"Move the largest ({values[ids[end]]}) to position {end}.",
                    HeapMarks(end + 1, 0, end, Swapped));
                SiftDown(end, 0, "Fix heap");
            }
        }

        int[] HeapMarks(int n, int a = 0, int b = 0, int mark = Active)
        {
            int[] m = Marks(Active);
            for (int s = n; s < m.Length; s++) m[s] = Done;
            if (mark != Active) m[a] = m[b] = mark;
            return m;
        }
        void SiftDown(int n, int i, string why)
        {
            while (true)
            {
                int big = i, left = 2 * i + 1, right = left + 1;
                if (left < n) big = Test(n, big, left);
                if (right < n) big = Test(n, big, right);
                if (big == i) return;
                string a = values[ids[i]], b = values[ids[big]];
                Swap(i, big);
                Add($"{why}: swap {a} with {b}.", HeapMarks(n, i, big, Swapped));
                i = big;
            }
        }

        int Test(int n, int big, int child)
        {
            Add($"Compare {values[ids[big]]} and {values[ids[child]]}.", HeapMarks(n, big, child, Compare));
            return Cmp(ids[child], ids[big]) > 0 ? child : big;
        }
        int[] Marks(int fill = Active)
        {
            int[] m = new int[ids.Length];
            for (int i = 0; i < m.Length; i++) m[i] = fill;
            return m;
        }
        void Add(string text, int[] marks) =>
            steps.Add(new Step { Text = text, Marks = marks, Order = (int[])ids.Clone() });
        void Swap(int i, int j) { int t = ids[i]; ids[i] = ids[j]; ids[j] = t; }
        int Cmp(int idA, int idB) => numeric
            ? int.Parse(values[idA]).CompareTo(int.Parse(values[idB]))
            : string.Compare(values[idA], values[idB], StringComparison.OrdinalIgnoreCase);
        void BuildSteps()
        {
            steps.Clear();
            ids = Enumerable.Range(0, values.Length).ToArray();
            Add($"Starting {AlgoName}.", Marks());
            Sort();
            Add("Sorting complete!", Marks(Done));
        }
        void LayoutControls()
        {
            Rectangle p = pnlAnimation.Bounds;
            txtArray.SetBounds(p.Left, p.Top - 60 - txtArray.Height, p.Width, txtArray.Height);
            title.SetBounds(p.Left, txtArray.Top - 54, p.Width, 44);
            int w = (p.Width - 10 * (buttons.Length - 1)) / buttons.Length;
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].SetBounds(p.Left + i * (w + 10), p.Top - 52, w, 40);
        }
        void PaintTitle(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(title.Parent.BackColor);
            var r = new RectangleF(0, 0, title.Width - 1, title.Height - 1);
            string text = string.Join("\u2009", title.Text.ToCharArray());
            Color gold = Color.FromArgb(255, 204, 0);
            using (var path = RoundRect(r, 12))
            using (var back = new LinearGradientBrush(r, Color.FromArgb(150, 0, 0), Color.FromArgb(70, 0, 0), 0f))
            using (var accent = new SolidBrush(gold))
            using (var shade = new SolidBrush(Color.FromArgb(140, 0, 0, 0)))
            using (var f = new Font("Impact", 20F))
            using (var fmt = Centered())
            {
                g.FillPath(back, path);
                g.FillRectangle(accent, 14, 10, 5, title.Height - 21);
                g.FillRectangle(accent, title.Width - 19, 10, 5, title.Height - 21);
                g.DrawString(text, f, shade, new RectangleF(2, 2, r.Width, r.Height), fmt);
                g.DrawString(text, f, accent, r, fmt);
            }
        }

        void StyleButton(Button b, Color accent)
        {
            Color bg = b.Parent.BackColor;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.UseVisualStyleBackColor = false;
            b.BackColor = bg;
            b.Cursor = Cursors.Hand;
            b.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            void Redraw(object s, EventArgs e) => b.Invalidate();
            b.MouseEnter += Redraw;
            b.MouseLeave += Redraw;
            b.MouseDown += Redraw;
            b.MouseUp += Redraw;
            b.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(bg);
                bool hover = b.ClientRectangle.Contains(b.PointToClient(Cursor.Position));
                Color c = !b.Enabled ? Color.FromArgb(175, 175, 180)
                        : hover && MouseButtons == MouseButtons.Left ? ControlPaint.Dark(accent, 0.1f)
                        : hover ? ControlPaint.Light(accent, 0.25f) : accent;
                var r = new RectangleF(1, 1, b.Width - 3, b.Height - 3);
                using (var path = RoundRect(r, 10))
                using (var fill = new SolidBrush(c))
                using (var fmt = Centered())
                {
                    g.FillPath(fill, path);
                    g.DrawString(b.Text, b.Font, b.Enabled ? Brushes.White : Brushes.Gainsboro, r, fmt);
                }
            };
        }

        void UpdateButtons()
        {
            bool has = steps.Count > 0;
            btnStart.Enabled = has && !playing;
            btnPause.Enabled = playing;
            btnNext.Enabled = has && shown < steps.Count - 1;
            btnReset.Enabled = has;
            btnClear.Enabled = has || txtArray.TextLength > 0;
        }
        static float L(float a, float b, float k) => a + (b - a) * k;
        static Color Mix(Color a, Color b, float k) =>
            Color.FromArgb((int)L(a.R, b.R, k), (int)L(a.G, b.G, k), (int)L(a.B, b.B, k));
        float Ease => progress < .5f
            ? 4 * progress * progress * progress
            : 1 - (float)Math.Pow(-2 * progress + 2, 3) / 2;
        void SetTargets(Step s)
        {
            for (int slot = 0; slot < s.Order.Length; slot++)
            {
                int id = s.Order[slot], m = s.Marks[slot];
                tx[id] = slot;
                ty[id] = m == Compare ? -1 : m == Idle ? 1 : 0;
                tc[id] = Colors[m];
            }
        }

        void StartSliding(Step s)
        {
            float k = Ease;
            for (int id = 0; id < values.Length; id++)
            {
                sx[id] = L(sx[id], tx[id], k);
                sy[id] = L(sy[id], ty[id], k);
                sc[id] = Mix(sc[id], tc[id], k);
            }
            SetTargets(s);
            bool moves = Enumerable.Range(0, values.Length).Any(i => Math.Abs(tx[i] - sx[i]) > 0.01f);
            slideMs = moves ? 450 : 250;
            progress = 0f;
            slideStart = clock.ElapsedMilliseconds;
            sliding = true;
            timer.Start();
        }

        void GoTo(int index)
        {
            shown = index;
            lblStatus.Text = steps[shown].Text;
            StartSliding(steps[shown]);
        }
        bool StepForward()
        {
            if (shown >= steps.Count - 1) return false;
            GoTo(shown + 1);
            return true;
        }
        void SnapToTargets()
        {
            Array.Copy(tx, sx, tx.Length);
            Array.Copy(ty, sy, ty.Length);
            Array.Copy(tc, sc, tc.Length);
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (sliding)
            {
                progress = (clock.ElapsedMilliseconds - slideStart) / slideMs;
                if (progress >= 1f) { progress = 1f; sliding = false; SnapToTargets(); }
            }
            else if (playing && !StepForward()) playing = false;
            if (!sliding && !playing) { timer.Stop(); UpdateButtons(); }
            pnlAnimation.Invalidate();
        }

        static StringFormat Centered() => new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
        };
        static GraphicsPath RoundRect(RectangleF r, float rad)
        {
            float d = rad * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        string Hint =>
            $"{Info}\n\n1.  Type up to {MaxItems} numbers, words or letters\n" +
            $"      e.g.  {Example}\n\n2.  Press Generate, then Start or Next\n\n" +
            "Tip: leave the box empty to load the example";
        void PaintPanel(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(pnlAnimation.BackColor);
            using (var fmt = Centered())
            {
                if (steps.Count == 0)
                {
                    g.DrawString(Hint, hintFont, Brushes.Gainsboro, pnlAnimation.ClientRectangle, fmt);
                    return;
                }
                int n = values.Length;
                float boxW = (pnlAnimation.Width - 2f * Margin - (n - 1) * Gap) / n;
                boxW = Math.Max(28f, Math.Min(64f, boxW));
                float cy = (pnlAnimation.Height - BoxH) / 2f, k = Ease;
                Font f = values.Max(v => v.Length) > 4 ? smallFont : font;
                using (var border = new Pen(Color.FromArgb(40, 40, 40), 1.5f))
                    foreach (int id in Enumerable.Range(0, n).OrderBy(i => Math.Abs(tx[i] - sx[i])))
                    {
                        float x = Margin + L(sx[id], tx[id], k) * (boxW + Gap);
                        float y = cy + L(sy[id], ty[id], k) * RowStep;
                        var rect = new RectangleF(x, y, boxW, BoxH);
                        using (var path = RoundRect(rect, 6))
                        using (var shadow = RoundRect(new RectangleF(x + 2, y + 3, boxW, BoxH), 6))
                        using (var fill = new SolidBrush(Mix(sc[id], tc[id], k)))
                        using (var shade = new SolidBrush(Color.FromArgb(55, 0, 0, 0)))
                        {
                            g.FillPath(shade, shadow);
                            g.FillPath(fill, path);
                            g.DrawPath(border, path);
                        }
                        g.DrawString(values[id], f, Brushes.Black, rect, fmt);
                    }
                g.DrawString($"Step {shown + 1} / {steps.Count}", Font, Brushes.Gainsboro, 8, 6);
            }
        }

        string[] Split()
        {
            string t = txtArray.Text;
            bool commas = t.Contains(",") || t.Contains(";");
            char[] sep = commas ? new[] { ',', ';' } : new[] { ' ', '\t', '\n', '\r' };
            return t.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim()).Where(p => p.Length > 0).ToArray();
        }
        void Stop() { timer.Stop(); playing = sliding = false; }
        void OnGenerate(object sender, EventArgs e)
        {
            Stop();
            string[] parts = Split();
            if (parts.Length == 0) { txtArray.Text = Example; parts = Split(); }
            if (parts.Length > MaxItems)
            {
                MessageBox.Show($"Please enter up to {MaxItems} items.\n\nExample:  {Example}");
                UpdateButtons();
                return;
            }
            values = parts;
            numeric = parts.All(p => int.TryParse(p, out _));
            int n = parts.Length;
            sx = new float[n]; sy = new float[n]; tx = new float[n]; ty = new float[n];
            sc = new Color[n]; tc = new Color[n];
            BuildSteps();
            shown = 0;
            progress = 1f;
            SetTargets(steps[0]);
            SnapToTargets();
            lblStatus.Text = steps[0].Text;
            UpdateButtons();
            pnlAnimation.Invalidate();
        }

        void OnStart(object sender, EventArgs e)
        {
            if (steps.Count == 0) return;
            if (shown >= steps.Count - 1) GoTo(0);
            playing = true;
            timer.Start();
            UpdateButtons();
        }
        void OnClear(object sender, EventArgs e)
        {
            Stop();
            steps.Clear();
            values = new string[0];
            shown = 0; progress = 1f;
            txtArray.Clear();
            lblStatus.Text = "";
            UpdateButtons();
            pnlAnimation.Invalidate();
            txtArray.Focus();
        }
    }
}