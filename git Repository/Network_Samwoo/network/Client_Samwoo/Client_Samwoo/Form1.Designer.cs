
namespace Client_Samwoo
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxView = new System.Windows.Forms.ListBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnMsg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxView
            // 
            this.lbxView.FormattingEnabled = true;
            this.lbxView.ItemHeight = 12;
            this.lbxView.Location = new System.Drawing.Point(14, 63);
            this.lbxView.Name = "lbxView";
            this.lbxView.Size = new System.Drawing.Size(339, 220);
            this.lbxView.TabIndex = 2;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(14, 317);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(339, 21);
            this.txtChat.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(388, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMsg
            // 
            this.btnMsg.Location = new System.Drawing.Point(388, 304);
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnMsg.Size = new System.Drawing.Size(99, 44);
            this.btnMsg.TabIndex = 5;
            this.btnMsg.Text = "SendMsg";
            this.btnMsg.UseVisualStyleBackColor = true;
            this.btnMsg.Click += new System.EventHandler(this.btnMsg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP주소";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(14, 24);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(339, 21);
            this.txtIP.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(388, 51);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 22);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 371);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMsg);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.lbxView);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbxView;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnExit;
    }
}

