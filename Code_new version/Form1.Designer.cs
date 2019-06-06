namespace capture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbTips1 = new System.Windows.Forms.Label();
            this.lbTips2 = new System.Windows.Forms.Label();
            this.lbTips3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTips1
            // 
            this.lbTips1.AutoSize = true;
            this.lbTips1.Location = new System.Drawing.Point(18, 19);
            this.lbTips1.Name = "lbTips1";
            this.lbTips1.Size = new System.Drawing.Size(35, 13);
            this.lbTips1.TabIndex = 0;
            this.lbTips1.Text = "label1";
            // 
            // lbTips2
            // 
            this.lbTips2.AutoSize = true;
            this.lbTips2.Location = new System.Drawing.Point(18, 45);
            this.lbTips2.Name = "lbTips2";
            this.lbTips2.Size = new System.Drawing.Size(35, 13);
            this.lbTips2.TabIndex = 1;
            this.lbTips2.Text = "label2";
            // 
            // lbTips3
            // 
            this.lbTips3.AutoSize = true;
            this.lbTips3.Location = new System.Drawing.Point(18, 71);
            this.lbTips3.Name = "lbTips3";
            this.lbTips3.Size = new System.Drawing.Size(35, 13);
            this.lbTips3.TabIndex = 2;
            this.lbTips3.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbTips1);
            this.panel1.Controls.Add(this.lbTips3);
            this.panel1.Controls.Add(this.lbTips2);
            this.panel1.Location = new System.Drawing.Point(285, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 445);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTips1;
        private System.Windows.Forms.Label lbTips2;
        private System.Windows.Forms.Label lbTips3;
        private System.Windows.Forms.Panel panel1;
    }
}

