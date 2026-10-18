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
    public partial class Merge : Form
    {
        private int[] numbers = { };
        private int currentStep = 0;
        private List<SortStep> steps = new List<SortStep>();
        private Timer animationTimer = new Timer();
        private Timer slideTimer = new Timer();
        private float animationProgress = 0f;
        private int[] fromValues;
        private int[] toValues;

        private float[] startPositions;
        private float[] targetPositions;

        private const int BoxWidth = 60;
        private const int BoxGap = 10;
        private const int StartX = 20;
        private class SortStep
        {
            public int[] ArrayValues;
            public string Description;
            public int FirstIndex;
            public int SecondIndex;
            public string Action;
        }
        public Merge()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            pnlAnimation.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(pnlAnimation, true);
            slideTimer.Interval = 16;
            slideTimer.Tick += SlideTimer_Tick;
            animationTimer.Interval = 700;

            animationTimer.Tick += AnimationTimer_Tick;
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            animationProgress += 0.08f;

            if (animationProgress >= 1f)
            {
                animationProgress = 1f;
                numbers = (int[])toValues.Clone();
                slideTimer.Stop();
            }

            pnlAnimation.Invalidate();
        }
        private void StartSliding(int[] nextValues)
        {
            {
                slideTimer.Stop();

                fromValues = (int[])numbers.Clone();
                toValues = (int[])nextValues.Clone();

                startPositions = new float[fromValues.Length];
                targetPositions = new float[fromValues.Length];

                bool[] used = new bool[fromValues.Length];

                for (int i = 0; i < fromValues.Length; i++)
                    startPositions[i] = targetPositions[i] =
                        StartX + i * (BoxWidth + BoxGap);

                for (int i = 0; i < toValues.Length; i++)
                    for (int j = 0; j < fromValues.Length; j++)
                        if (!used[j] && fromValues[j] == toValues[i])
                        {
                            used[j] = true;
                            targetPositions[j] =
                                StartX + i * (BoxWidth + BoxGap);
                            break;
                        }

                animationProgress = 0f;
                slideTimer.Start();
            }
        }

        private void AddStep( int[] array,string action,int firstIndex,int secondIndex,string description)
        {
            steps.Add(new SortStep
            {
                ArrayValues = (int[])array.Clone(),
                Action = action,
                FirstIndex = firstIndex,
                SecondIndex = secondIndex,
                Description = description
            });
        }
        private void mergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                AddStep(array, "Divide", left, mid, $"Dividing: Left={left}, Mid={mid}, Right={right}");
                mergeSort(array, left, mid);
                mergeSort(array, mid + 1, right);
                merge(array, left, mid, right);
            }
        }
        private void merge(int[] array, int left, int middle, int right)
        {
            int[] temp = new int[right - left + 1];

            int i = left;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= right)
            {
                AddStep(
                    array, "Compare", i, j,
                    $"Compare {array[i]} and {array[j]}.");

                if (array[i] <= array[j])
                    temp[k++] = array[i++];
                else
                    temp[k++] = array[j++];
            }

            while (i <= middle)
                temp[k++] = array[i++];

            while (j <= right)
                temp[k++] = array[j++];

            for (int t = 0; t < temp.Length; t++)
            {
                array[left + t] = temp[t];

                AddStep(
                    array, "Merge", left + t, -1,
                    $"Place {array[left + t]} in position {left + t}.");
            }
        }
        private void GenerateSteps()
        {
            steps.Clear();
            currentStep = 0;
            int[] workingArray = (int[])numbers.Clone();

            AddStep(
                workingArray, "Start", -1, -1,
                "Starting Merge Sort.");

            mergeSort(workingArray, 0, workingArray.Length - 1);

            AddStep(
                workingArray, "Complete", -1, -1,
                "Sorted: " + string.Join(", ", workingArray));

            animationTimer.Stop();

            numbers = (int[])steps[0].ArrayValues.Clone();

            lblStatus.Text = steps[0].Description;
            pnlAnimation.Invalidate();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            ShowNextStep();
        }
        private void ShowNextStep()
        {
            if (currentStep >= steps.Count)
            {
                animationTimer.Stop();
                lblStatus.Text = "Sorting complete!";
                return;
            }

            SortStep step = steps[currentStep];

            lblStatus.Text = step.Description;

            currentStep++;

            StartSliding(step.ArrayValues);
        }


        private void pnlAnimation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(pnlAnimation.BackColor);

            int boxWidth = 60;
            int boxHeight = 50;
            int gap = 10;
            int startX = 20;
            int startY = 50;

            for (int i = 0; i < numbers.Length; i++)
            {
                float x = startX + i * (boxWidth + gap);
                int valueToDraw = numbers[i];

                if (slideTimer.Enabled &&
                    fromValues != null &&
                    toValues != null &&
                    startPositions != null &&
                    targetPositions != null &&
                    i < fromValues.Length)
                {
                    x = startPositions[i] +
                        (targetPositions[i] - startPositions[i])
                        * animationProgress;

                    valueToDraw = fromValues[i];
                }

                Brush blockBrush = Brushes.LightBlue;

                if (steps.Count > 0 && currentStep > 0)
                {
                    SortStep step = steps[currentStep - 1];

                    if (step.Action == "Compare" &&
                        (i == step.FirstIndex ||
                         i == step.SecondIndex))
                    {
                        blockBrush = Brushes.Orange;
                    }
                    else if (step.Action == "Merge" &&
                             i == step.FirstIndex)
                    {
                        blockBrush = Brushes.LightGreen;
                    }
                }

                // Draw box at its animated position
                Rectangle box = new Rectangle(
                    (int)Math.Round(x),
                    startY,
                    boxWidth,
                    boxHeight
                );

                g.FillRectangle(blockBrush, box);
                g.DrawRectangle(Pens.Black, box);

                // Center the number inside its moving box
                string text = valueToDraw.ToString();

                SizeF textSize = g.MeasureString(text, this.Font);

                float textX = x + (boxWidth - textSize.Width) / 2;
                float textY = startY + (boxHeight - textSize.Height) / 2;

                g.DrawString(
                    text,
                    this.Font,
                    Brushes.Black,
                    textX,
                    textY
                );
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtArray.Text.Trim();

                string[] parts = input.Split(new char[] { ',', ' ', '\t', '\n', '\r', ';' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                if (parts.Length == 0)
                {
                    MessageBox.Show("Please enter some numbers.");
                    return;
                }

                int[] inputNumbers = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts[i], out inputNumbers[i]))
                    {
                        MessageBox.Show(
                            "Invalid number: " + parts[i] +
                            "\nPlease enter whole numbers only."
                        );
                        return;
                    }
                }
                numbers = inputNumbers;
                GenerateSteps();
                pnlAnimation.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (currentStep < steps.Count)
            {
                animationTimer.Start();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            ShowNextStep();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();

            currentStep = 0;

            if (steps.Count > 0)
            {
                numbers = (int[])steps[0].ArrayValues.Clone();

                lblStatus.Text = steps[0].Description;

                pnlAnimation.Invalidate();
            }
        }
    }
}
