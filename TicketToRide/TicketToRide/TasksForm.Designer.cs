namespace TicketToRide
{
    partial class TasksForm
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
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTextFrom = new System.Windows.Forms.Label();
            this.labelTextTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelTextPoints = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelTextComp = new System.Windows.Forms.Label();
            this.labelComp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 253);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(69, 26);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Předchozí";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(87, 253);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(69, 26);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Další";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(233, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Zavřít";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelTextFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTextTo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFrom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTextPoints, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPoints, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTextComp, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelComp, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 235);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelTextFrom
            // 
            this.labelTextFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTextFrom.AutoSize = true;
            this.labelTextFrom.Location = new System.Drawing.Point(100, 22);
            this.labelTextFrom.Name = "labelTextFrom";
            this.labelTextFrom.Size = new System.Drawing.Size(42, 13);
            this.labelTextFrom.TabIndex = 0;
            this.labelTextFrom.Text = "Odkud:";
            // 
            // labelTextTo
            // 
            this.labelTextTo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTextTo.AutoSize = true;
            this.labelTextTo.Location = new System.Drawing.Point(111, 80);
            this.labelTextTo.Name = "labelTextTo";
            this.labelTextTo.Size = new System.Drawing.Size(31, 13);
            this.labelTextTo.TabIndex = 1;
            this.labelTextTo.Text = "Kam:";
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(148, 22);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(139, 13);
            this.labelFrom.TabIndex = 2;
            this.labelFrom.Text = "Riga";
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(148, 80);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(139, 13);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "London";
            // 
            // labelTextPoints
            // 
            this.labelTextPoints.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTextPoints.AutoSize = true;
            this.labelTextPoints.Location = new System.Drawing.Point(77, 138);
            this.labelTextPoints.Name = "labelTextPoints";
            this.labelTextPoints.Size = new System.Drawing.Size(65, 13);
            this.labelTextPoints.TabIndex = 4;
            this.labelTextPoints.Text = "Počet bodů:";
            // 
            // labelPoints
            // 
            this.labelPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(148, 138);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(139, 13);
            this.labelPoints.TabIndex = 5;
            this.labelPoints.Text = "6";
            // 
            // labelTextComp
            // 
            this.labelTextComp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTextComp.AutoSize = true;
            this.labelTextComp.Location = new System.Drawing.Point(93, 198);
            this.labelTextComp.Name = "labelTextComp";
            this.labelTextComp.Size = new System.Drawing.Size(49, 13);
            this.labelTextComp.TabIndex = 6;
            this.labelTextComp.Text = "Splněno:";
            // 
            // labelComp
            // 
            this.labelComp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelComp.AutoSize = true;
            this.labelComp.Location = new System.Drawing.Point(148, 198);
            this.labelComp.Name = "labelComp";
            this.labelComp.Size = new System.Drawing.Size(139, 13);
            this.labelComp.TabIndex = 7;
            this.labelComp.Text = "NE";
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 291);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TasksForm";
            this.Text = "Ticket to Ride - Tvoje úkoly";
            this.Load += new System.EventHandler(this.TasksForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTextFrom;
        private System.Windows.Forms.Label labelTextTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelTextPoints;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelTextComp;
        private System.Windows.Forms.Label labelComp;
    }
}