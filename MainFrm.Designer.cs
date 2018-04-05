namespace MSProxy
{
    partial class MSProxyForm
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
            System.Windows.Forms.Label m_labServer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSProxyForm));
            System.Windows.Forms.Label m_labLofinPort;
            System.Windows.Forms.StatusStrip m_statusStrip;
            System.Windows.Forms.StatusStrip m_statusStripMore;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label m_labChannelPort;
            System.Windows.Forms.Label m_labShopPort;
            this.m_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_StatusLabelMore = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_BtnPath = new System.Windows.Forms.Button();
            this.m_BtnCheck = new System.Windows.Forms.Button();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnStart = new System.Windows.Forms.Button();
            this.m_TboxLoginPort = new System.Windows.Forms.TextBox();
            this.m_TboxIP = new System.Windows.Forms.TextBox();
            this.m_PanExtend = new System.Windows.Forms.Panel();
            this.m_TboxShopPort = new System.Windows.Forms.TextBox();
            this.m_TboxChannelPort = new System.Windows.Forms.TextBox();
            this.m_BtnAbout = new System.Windows.Forms.Button();
            m_labServer = new System.Windows.Forms.Label();
            m_labLofinPort = new System.Windows.Forms.Label();
            m_statusStrip = new System.Windows.Forms.StatusStrip();
            m_statusStripMore = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            m_labChannelPort = new System.Windows.Forms.Label();
            m_labShopPort = new System.Windows.Forms.Label();
            m_statusStrip.SuspendLayout();
            m_statusStripMore.SuspendLayout();
            panel1.SuspendLayout();
            this.m_PanExtend.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labServer
            // 
            resources.ApplyResources(m_labServer, "m_labServer");
            m_labServer.Name = "m_labServer";
            // 
            // m_labLofinPort
            // 
            resources.ApplyResources(m_labLofinPort, "m_labLofinPort");
            m_labLofinPort.Name = "m_labLofinPort";
            // 
            // m_statusStrip
            // 
            m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_StatusLabel});
            resources.ApplyResources(m_statusStrip, "m_statusStrip");
            m_statusStrip.Name = "m_statusStrip";
            // 
            // m_StatusLabel
            // 
            this.m_StatusLabel.Name = "m_StatusLabel";
            resources.ApplyResources(this.m_StatusLabel, "m_StatusLabel");
            // 
            // m_statusStripMore
            // 
            m_statusStripMore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_StatusLabelMore});
            resources.ApplyResources(m_statusStripMore, "m_statusStripMore");
            m_statusStripMore.Name = "m_statusStripMore";
            m_statusStripMore.SizingGrip = false;
            m_statusStripMore.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.m_statusStripMore_ItemClicked);
            // 
            // m_StatusLabelMore
            // 
            this.m_StatusLabelMore.Name = "m_StatusLabelMore";
            resources.ApplyResources(this.m_StatusLabelMore, "m_StatusLabelMore");
            this.m_StatusLabelMore.Spring = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(this.m_BtnAbout);
            panel1.Controls.Add(this.m_BtnPath);
            panel1.Controls.Add(this.m_BtnCheck);
            panel1.Controls.Add(this.m_btnStop);
            panel1.Controls.Add(this.m_btnStart);
            panel1.Controls.Add(this.m_TboxLoginPort);
            panel1.Controls.Add(m_labLofinPort);
            panel1.Controls.Add(this.m_TboxIP);
            panel1.Controls.Add(m_labServer);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // m_BtnPath
            // 
            resources.ApplyResources(this.m_BtnPath, "m_BtnPath");
            this.m_BtnPath.Name = "m_BtnPath";
            this.m_BtnPath.UseVisualStyleBackColor = true;
            this.m_BtnPath.Click += new System.EventHandler(this.m_BtnPath_Click);
            // 
            // m_BtnCheck
            // 
            resources.ApplyResources(this.m_BtnCheck, "m_BtnCheck");
            this.m_BtnCheck.Name = "m_BtnCheck";
            this.m_BtnCheck.UseVisualStyleBackColor = true;
            this.m_BtnCheck.Click += new System.EventHandler(this.m_BtnCheck_Click);
            // 
            // m_btnStop
            // 
            resources.ApplyResources(this.m_btnStop, "m_btnStop");
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnStart
            // 
            resources.ApplyResources(this.m_btnStart, "m_btnStart");
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.UseVisualStyleBackColor = true;
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
            // 
            // m_TboxLoginPort
            // 
            resources.ApplyResources(this.m_TboxLoginPort, "m_TboxLoginPort");
            this.m_TboxLoginPort.Name = "m_TboxLoginPort";
            // 
            // m_TboxIP
            // 
            resources.ApplyResources(this.m_TboxIP, "m_TboxIP");
            this.m_TboxIP.Name = "m_TboxIP";
            // 
            // m_labChannelPort
            // 
            resources.ApplyResources(m_labChannelPort, "m_labChannelPort");
            m_labChannelPort.Name = "m_labChannelPort";
            // 
            // m_labShopPort
            // 
            resources.ApplyResources(m_labShopPort, "m_labShopPort");
            m_labShopPort.Name = "m_labShopPort";
            // 
            // m_PanExtend
            // 
            this.m_PanExtend.Controls.Add(this.m_TboxShopPort);
            this.m_PanExtend.Controls.Add(m_labShopPort);
            this.m_PanExtend.Controls.Add(this.m_TboxChannelPort);
            this.m_PanExtend.Controls.Add(m_labChannelPort);
            resources.ApplyResources(this.m_PanExtend, "m_PanExtend");
            this.m_PanExtend.Name = "m_PanExtend";
            // 
            // m_TboxShopPort
            // 
            resources.ApplyResources(this.m_TboxShopPort, "m_TboxShopPort");
            this.m_TboxShopPort.Name = "m_TboxShopPort";
            // 
            // m_TboxChannelPort
            // 
            resources.ApplyResources(this.m_TboxChannelPort, "m_TboxChannelPort");
            this.m_TboxChannelPort.Name = "m_TboxChannelPort";
            // 
            // m_BtnAbout
            // 
            resources.ApplyResources(this.m_BtnAbout, "m_BtnAbout");
            this.m_BtnAbout.Name = "m_BtnAbout";
            this.m_BtnAbout.UseVisualStyleBackColor = true;
            this.m_BtnAbout.Click += new System.EventHandler(this.m_BtnAbout_Click);
            // 
            // MSProxyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_PanExtend);
            this.Controls.Add(panel1);
            this.Controls.Add(m_statusStripMore);
            this.Controls.Add(m_statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MSProxyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSProxyForm_FormClosing);
            this.Load += new System.EventHandler(this.MSProxyForm_Load);
            m_statusStrip.ResumeLayout(false);
            m_statusStrip.PerformLayout();
            m_statusStripMore.ResumeLayout(false);
            m_statusStripMore.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.m_PanExtend.ResumeLayout(false);
            this.m_PanExtend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_TboxIP;
        private System.Windows.Forms.TextBox m_TboxLoginPort;
        private System.Windows.Forms.ToolStripStatusLabel m_StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel m_StatusLabelMore;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnStart;
        private System.Windows.Forms.TextBox m_TboxShopPort;
        private System.Windows.Forms.TextBox m_TboxChannelPort;
        private System.Windows.Forms.Panel m_PanExtend;
        private System.Windows.Forms.Button m_BtnCheck;
        private System.Windows.Forms.Button m_BtnPath;
        private System.Windows.Forms.Button m_BtnAbout;
    }
}

