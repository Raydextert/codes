namespace Crawlbilibili
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.videolbl = new System.Windows.Forms.Label();
            this.urltxt = new System.Windows.Forms.TextBox();
            this.crawlingImg = new System.Windows.Forms.Button();
            this.IDlistGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.IDlistGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // videolbl
            // 
            this.videolbl.AutoSize = true;
            this.videolbl.Location = new System.Drawing.Point(12, 47);
            this.videolbl.Name = "videolbl";
            this.videolbl.Size = new System.Drawing.Size(219, 15);
            this.videolbl.TabIndex = 0;
            this.videolbl.Text = "请输入视频的ID号(逗号分隔)：";
            // 
            // urltxt
            // 
            this.urltxt.Location = new System.Drawing.Point(223, 37);
            this.urltxt.Name = "urltxt";
            this.urltxt.Size = new System.Drawing.Size(261, 25);
            this.urltxt.TabIndex = 1;
            // 
            // crawlingImg
            // 
            this.crawlingImg.Location = new System.Drawing.Point(508, 30);
            this.crawlingImg.Name = "crawlingImg";
            this.crawlingImg.Size = new System.Drawing.Size(87, 34);
            this.crawlingImg.TabIndex = 2;
            this.crawlingImg.Text = "开始下载";
            this.crawlingImg.UseVisualStyleBackColor = true;
            this.crawlingImg.Click += new System.EventHandler(this.crawlingImg_Click);
            // 
            // IDlistGrid
            // 
            this.IDlistGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.IDlistGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IDlistGrid.Location = new System.Drawing.Point(12, 85);
            this.IDlistGrid.Name = "IDlistGrid";
            this.IDlistGrid.RowTemplate.Height = 27;
            this.IDlistGrid.Size = new System.Drawing.Size(592, 150);
            this.IDlistGrid.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 240);
            this.Controls.Add(this.IDlistGrid);
            this.Controls.Add(this.crawlingImg);
            this.Controls.Add(this.urltxt);
            this.Controls.Add(this.videolbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "爬取图片";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDlistGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label videolbl;
        private System.Windows.Forms.TextBox urltxt;
        private System.Windows.Forms.Button crawlingImg;
        private System.Windows.Forms.DataGridView IDlistGrid;

    }
}

