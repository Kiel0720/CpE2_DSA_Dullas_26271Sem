namespace CpE2_DSA_Dullas_26271Sem
{
    partial class Stack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbStack = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPop = new System.Windows.Forms.Button();
            this.btnPeek = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnContain = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.txtStackValue = new System.Windows.Forms.TextBox();
            this.lstStack = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbStack.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStack
            // 
            this.gbStack.Controls.Add(this.label1);
            this.gbStack.Controls.Add(this.btnClear);
            this.gbStack.Controls.Add(this.btnPop);
            this.gbStack.Controls.Add(this.btnPeek);
            this.gbStack.Controls.Add(this.btnCount);
            this.gbStack.Controls.Add(this.btnContain);
            this.gbStack.Controls.Add(this.btnPush);
            this.gbStack.Controls.Add(this.txtStackValue);
            this.gbStack.Controls.Add(this.lstStack);
            this.gbStack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStack.Location = new System.Drawing.Point(12, 12);
            this.gbStack.Name = "gbStack";
            this.gbStack.Size = new System.Drawing.Size(779, 426);
            this.gbStack.TabIndex = 0;
            this.gbStack.TabStop = false;
            this.gbStack.Text = "Stack";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(367, 172);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 33);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPop
            // 
            this.btnPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPop.Location = new System.Drawing.Point(274, 133);
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(87, 33);
            this.btnPop.TabIndex = 9;
            this.btnPop.Text = "Pop";
            this.btnPop.UseVisualStyleBackColor = true;
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
            // 
            // btnPeek
            // 
            this.btnPeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeek.Location = new System.Drawing.Point(367, 133);
            this.btnPeek.Name = "btnPeek";
            this.btnPeek.Size = new System.Drawing.Size(87, 33);
            this.btnPeek.TabIndex = 8;
            this.btnPeek.Text = "Peek";
            this.btnPeek.UseVisualStyleBackColor = true;
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount.Location = new System.Drawing.Point(274, 172);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(87, 33);
            this.btnCount.TabIndex = 7;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnContain
            // 
            this.btnContain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContain.Location = new System.Drawing.Point(367, 94);
            this.btnContain.Name = "btnContain";
            this.btnContain.Size = new System.Drawing.Size(87, 33);
            this.btnContain.TabIndex = 6;
            this.btnContain.Text = "Contains";
            this.btnContain.UseVisualStyleBackColor = true;
            this.btnContain.Click += new System.EventHandler(this.btnContain_Click);
            // 
            // btnPush
            // 
            this.btnPush.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPush.Location = new System.Drawing.Point(274, 94);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(87, 33);
            this.btnPush.TabIndex = 5;
            this.btnPush.Text = "Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // txtStackValue
            // 
            this.txtStackValue.Location = new System.Drawing.Point(367, 59);
            this.txtStackValue.Name = "txtStackValue";
            this.txtStackValue.Size = new System.Drawing.Size(134, 29);
            this.txtStackValue.TabIndex = 1;
            // 
            // lstStack
            // 
            this.lstStack.FormattingEnabled = true;
            this.lstStack.ItemHeight = 24;
            this.lstStack.Location = new System.Drawing.Point(6, 28);
            this.lstStack.Name = "lstStack";
            this.lstStack.Size = new System.Drawing.Size(244, 364);
            this.lstStack.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Insert Value";
            // 
            // Stack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 505);
            this.Controls.Add(this.gbStack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stack";
            this.Text = "Stack";
            this.Load += new System.EventHandler(this.Stack_Load);
            this.gbStack.ResumeLayout(false);
            this.gbStack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStack;
        private System.Windows.Forms.ListBox lstStack;
        private System.Windows.Forms.TextBox txtStackValue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPop;
        private System.Windows.Forms.Button btnPeek;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnContain;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Label label1;
    }
}