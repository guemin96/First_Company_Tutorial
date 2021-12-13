
namespace Network_project
{
    partial class Form1
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxView
            // 
            this.lbxView.FormattingEnabled = true;
            this.lbxView.ItemHeight = 12;
            this.lbxView.Location = new System.Drawing.Point(12, 63);
            this.lbxView.Name = "lbxView";
            this.lbxView.Size = new System.Drawing.Size(326, 280);
            this.lbxView.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(357, 63);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(89, 46);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "연결하기";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(12, 362);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(325, 21);
            this.txtChat.TabIndex = 2;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(357, 360);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 3;
            this.btnInput.Text = "입력하기";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(357, 115);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "끝내기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 426);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbxView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ListBox lbxView;
        public System.Windows.Forms.TextBox txtChat;
    }
}

