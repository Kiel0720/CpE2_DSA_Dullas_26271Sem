namespace CpE2_DSA_Dullas_26271Sem
{
    partial class List
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
            this.gpList = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.lstbList = new System.Windows.Forms.ListBox();
            this.gpbInsertAddRemove = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gpbRemoveAtIndexOf = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoveAtIndexOf = new System.Windows.Forms.TextBox();
            this.btnIndexOf = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.btnRemoveAt = new System.Windows.Forms.Button();
            this.gpList.SuspendLayout();
            this.gpbInsertAddRemove.SuspendLayout();
            this.gpbRemoveAtIndexOf.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpList
            // 
            this.gpList.Controls.Add(this.btnClear);
            this.gpList.Controls.Add(this.btnSort);
            this.gpList.Controls.Add(this.btnCount);
            this.gpList.Controls.Add(this.lstbList);
            this.gpList.Controls.Add(this.gpbInsertAddRemove);
            this.gpList.Controls.Add(this.gpbRemoveAtIndexOf);
            this.gpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpList.Location = new System.Drawing.Point(12, 12);
            this.gpList.Name = "gpList";
            this.gpList.Size = new System.Drawing.Size(1028, 470);
            this.gpList.TabIndex = 0;
            this.gpList.TabStop = false;
            this.gpList.Text = "List";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(343, 28);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(555, 28);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(100, 32);
            this.btnSort.TabIndex = 10;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(449, 28);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(100, 32);
            this.btnCount.TabIndex = 8;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // lstbList
            // 
            this.lstbList.FormattingEnabled = true;
            this.lstbList.ItemHeight = 24;
            this.lstbList.Location = new System.Drawing.Point(97, 28);
            this.lstbList.Name = "lstbList";
            this.lstbList.Size = new System.Drawing.Size(240, 340);
            this.lstbList.TabIndex = 0;
            // 
            // gpbInsertAddRemove
            // 
            this.gpbInsertAddRemove.Controls.Add(this.label1);
            this.gpbInsertAddRemove.Controls.Add(this.txtList);
            this.gpbInsertAddRemove.Controls.Add(this.btnAdd);
            this.gpbInsertAddRemove.Controls.Add(this.btnInsert);
            this.gpbInsertAddRemove.Controls.Add(this.btnRemove);
            this.gpbInsertAddRemove.Location = new System.Drawing.Point(343, 86);
            this.gpbInsertAddRemove.Name = "gpbInsertAddRemove";
            this.gpbInsertAddRemove.Size = new System.Drawing.Size(251, 166);
            this.gpbInsertAddRemove.TabIndex = 13;
            this.gpbInsertAddRemove.TabStop = false;
            this.gpbInsertAddRemove.Text = "Insert/Add/Remove";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Value";
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(102, 38);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(143, 29);
            this.txtList.TabIndex = 2;
            this.txtList.TextChanged += new System.EventHandler(this.txtList_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(145, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(39, 73);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 32);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(145, 111);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 32);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gpbRemoveAtIndexOf
            // 
            this.gpbRemoveAtIndexOf.Controls.Add(this.label2);
            this.gpbRemoveAtIndexOf.Controls.Add(this.txtRemoveAtIndexOf);
            this.gpbRemoveAtIndexOf.Controls.Add(this.btnIndexOf);
            this.gpbRemoveAtIndexOf.Controls.Add(this.btnContains);
            this.gpbRemoveAtIndexOf.Controls.Add(this.btnRemoveAt);
            this.gpbRemoveAtIndexOf.Location = new System.Drawing.Point(614, 91);
            this.gpbRemoveAtIndexOf.Name = "gpbRemoveAtIndexOf";
            this.gpbRemoveAtIndexOf.Size = new System.Drawing.Size(269, 161);
            this.gpbRemoveAtIndexOf.TabIndex = 14;
            this.gpbRemoveAtIndexOf.TabStop = false;
            this.gpbRemoveAtIndexOf.Text = "RemoveAt/IndexOF/Contains";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Index";
            // 
            // txtRemoveAtIndexOf
            // 
            this.txtRemoveAtIndexOf.Location = new System.Drawing.Point(104, 33);
            this.txtRemoveAtIndexOf.Name = "txtRemoveAtIndexOf";
            this.txtRemoveAtIndexOf.Size = new System.Drawing.Size(159, 29);
            this.txtRemoveAtIndexOf.TabIndex = 12;
            // 
            // btnIndexOf
            // 
            this.btnIndexOf.Location = new System.Drawing.Point(148, 106);
            this.btnIndexOf.Name = "btnIndexOf";
            this.btnIndexOf.Size = new System.Drawing.Size(115, 32);
            this.btnIndexOf.TabIndex = 4;
            this.btnIndexOf.Text = "Index Of";
            this.btnIndexOf.UseVisualStyleBackColor = true;
            this.btnIndexOf.Click += new System.EventHandler(this.btnIndexOf_Click);
            // 
            // btnContains
            // 
            this.btnContains.Location = new System.Drawing.Point(42, 68);
            this.btnContains.Name = "btnContains";
            this.btnContains.Size = new System.Drawing.Size(100, 32);
            this.btnContains.TabIndex = 9;
            this.btnContains.Text = "Contains";
            this.btnContains.UseVisualStyleBackColor = true;
            this.btnContains.Click += new System.EventHandler(this.btnContains_Click);
            // 
            // btnRemoveAt
            // 
            this.btnRemoveAt.Location = new System.Drawing.Point(148, 68);
            this.btnRemoveAt.Name = "btnRemoveAt";
            this.btnRemoveAt.Size = new System.Drawing.Size(115, 32);
            this.btnRemoveAt.TabIndex = 6;
            this.btnRemoveAt.Text = "Remove At";
            this.btnRemoveAt.UseVisualStyleBackColor = true;
            this.btnRemoveAt.Click += new System.EventHandler(this.btnRemoveAt_Click);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1052, 494);
            this.Controls.Add(this.gpList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "List";
            this.Text = "List";
            this.gpList.ResumeLayout(false);
            this.gpbInsertAddRemove.ResumeLayout(false);
            this.gpbInsertAddRemove.PerformLayout();
            this.gpbRemoveAtIndexOf.ResumeLayout(false);
            this.gpbRemoveAtIndexOf.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpList;
        private System.Windows.Forms.ListBox lstbList;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Button btnContains;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnRemoveAt;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnIndexOf;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRemoveAtIndexOf;
        private System.Windows.Forms.GroupBox gpbInsertAddRemove;
        private System.Windows.Forms.GroupBox gpbRemoveAtIndexOf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}