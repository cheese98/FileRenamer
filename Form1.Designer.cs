namespace FileRenamer
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
            this.applyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.removeSpaceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(541, 301);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 44);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "적용";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(541, 12);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "제거";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(85, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(440, 336);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // removeSpaceButton
            // 
            this.removeSpaceButton.Location = new System.Drawing.Point(541, 41);
            this.removeSpaceButton.Name = "removeSpaceButton";
            this.removeSpaceButton.Size = new System.Drawing.Size(75, 23);
            this.removeSpaceButton.TabIndex = 4;
            this.removeSpaceButton.Text = "공백 제거";
            this.removeSpaceButton.UseVisualStyleBackColor = true;
            this.removeSpaceButton.Click += new System.EventHandler(this.removeSpaceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 357);
            this.Controls.Add(this.removeSpaceButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.applyButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button removeSpaceButton;
    }
}

