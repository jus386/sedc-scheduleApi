namespace Sedc.ScheduleApi.TestWinClient
{
    partial class Form1
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
            this.gvCourses = new System.Windows.Forms.DataGridView();
            this.btnLoadCourses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCourses
            // 
            this.gvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCourses.Location = new System.Drawing.Point(12, 51);
            this.gvCourses.Name = "gvCourses";
            this.gvCourses.Size = new System.Drawing.Size(582, 323);
            this.gvCourses.TabIndex = 0;
            // 
            // btnLoadCourses
            // 
            this.btnLoadCourses.Location = new System.Drawing.Point(13, 22);
            this.btnLoadCourses.Name = "btnLoadCourses";
            this.btnLoadCourses.Size = new System.Drawing.Size(107, 23);
            this.btnLoadCourses.TabIndex = 1;
            this.btnLoadCourses.Text = "Load Courses";
            this.btnLoadCourses.UseVisualStyleBackColor = true;
            this.btnLoadCourses.Click += new System.EventHandler(this.btnLoadCourses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 386);
            this.Controls.Add(this.btnLoadCourses);
            this.Controls.Add(this.gvCourses);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCourses;
        private System.Windows.Forms.Button btnLoadCourses;
    }
}

