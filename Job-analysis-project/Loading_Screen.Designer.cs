namespace Job_analysis_project
{

    partial class Loading_Screen
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
            this.pnlLoadingBar = new System.Windows.Forms.Panel();
            this.lbLoading = new System.Windows.Forms.Label();
            this.picRocket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRocket)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoadingBar
            // 
            this.pnlLoadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.pnlLoadingBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlLoadingBar.Location = new System.Drawing.Point(50, 321);
            this.pnlLoadingBar.Name = "pnlLoadingBar";
            this.pnlLoadingBar.Size = new System.Drawing.Size(0, 5);
            this.pnlLoadingBar.TabIndex = 2;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.ForeColor = System.Drawing.Color.White;
            this.lbLoading.Location = new System.Drawing.Point(346, 345);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(96, 20);
            this.lbLoading.TabIndex = 0;
            this.lbLoading.Text = "Loading ...";
            // 
            // picRocket
            // 
            this.picRocket.BackgroundImage = global::Job_analysis_project.Properties.Resources.rocket_size_48;
            this.picRocket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picRocket.ErrorImage = null;
            this.picRocket.Location = new System.Drawing.Point(350, 202);
            this.picRocket.Name = "picRocket";
            this.picRocket.Size = new System.Drawing.Size(100, 100);
            this.picRocket.TabIndex = 0;
            this.picRocket.TabStop = false;
            // 
            // Loading_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.pnlLoadingBar);
            this.Controls.Add(this.picRocket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRocket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRocket;
        private System.Windows.Forms.Panel pnlLoadingBar;
        private System.Windows.Forms.Label lbLoading;
    }
}