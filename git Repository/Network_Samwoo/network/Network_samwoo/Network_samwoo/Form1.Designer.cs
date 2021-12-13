
namespace Network_samwoo
{
    partial class Server
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
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxView
            // 
            this.lbxView.FormattingEnabled = true;
            this.lbxView.ItemHeight = 12;
            this.lbxView.Location = new System.Drawing.Point(16, 35);
            this.lbxView.Name = "lbxView";
            this.lbxView.Size = new System.Drawing.Size(309, 280);
            this.lbxView.TabIndex = 0;
            this.lbxView.UseTabStops = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(346, 54);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "연결하기";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(346, 83);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "끝내기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 328);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbxView);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxView;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExit;
    }
}

