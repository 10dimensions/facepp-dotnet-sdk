namespace FMS
{
    partial class CreateOrUpdateFaceSetForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_UserData = new System.Windows.Forms.TextBox();
            this.textBox_FaceTokens = new System.Windows.Forms.TextBox();
            this.textBox_Tags = new System.Windows.Forms.TextBox();
            this.textBox_OuterId = new System.Windows.Forms.TextBox();
            this.textBox_DisplayName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DisplayName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_UserData);
            this.groupBox1.Controls.Add(this.textBox_FaceTokens);
            this.groupBox1.Controls.Add(this.textBox_Tags);
            this.groupBox1.Controls.Add(this.textBox_OuterId);
            this.groupBox1.Controls.Add(this.textBox_DisplayName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FaceSet";
            // 
            // textBox_UserData
            // 
            this.textBox_UserData.Location = new System.Drawing.Point(136, 149);
            this.textBox_UserData.Name = "textBox_UserData";
            this.textBox_UserData.Size = new System.Drawing.Size(380, 22);
            this.textBox_UserData.TabIndex = 12;
            // 
            // textBox_FaceTokens
            // 
            this.textBox_FaceTokens.Location = new System.Drawing.Point(136, 119);
            this.textBox_FaceTokens.Name = "textBox_FaceTokens";
            this.textBox_FaceTokens.Size = new System.Drawing.Size(380, 22);
            this.textBox_FaceTokens.TabIndex = 11;
            // 
            // textBox_Tags
            // 
            this.textBox_Tags.Location = new System.Drawing.Point(136, 89);
            this.textBox_Tags.Name = "textBox_Tags";
            this.textBox_Tags.Size = new System.Drawing.Size(380, 22);
            this.textBox_Tags.TabIndex = 10;
            // 
            // textBox_OuterId
            // 
            this.textBox_OuterId.Location = new System.Drawing.Point(136, 59);
            this.textBox_OuterId.Name = "textBox_OuterId";
            this.textBox_OuterId.Size = new System.Drawing.Size(380, 22);
            this.textBox_OuterId.TabIndex = 9;
            // 
            // textBox_DisplayName
            // 
            this.textBox_DisplayName.Location = new System.Drawing.Point(136, 29);
            this.textBox_DisplayName.Name = "textBox_DisplayName";
            this.textBox_DisplayName.Size = new System.Drawing.Size(380, 22);
            this.textBox_DisplayName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "UserData";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "FaceTokens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tags";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "OuterId";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateOrUpdateFaceSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CreateOrUpdateFaceSetForm";
            this.Text = "FaceSet管理";
            this.Shown += new System.EventHandler(this.CreateOrUpdateFaceSetForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_UserData;
        private System.Windows.Forms.TextBox textBox_FaceTokens;
        private System.Windows.Forms.TextBox textBox_Tags;
        private System.Windows.Forms.TextBox textBox_OuterId;
        private System.Windows.Forms.TextBox textBox_DisplayName;
        private System.Windows.Forms.Button button1;
    }
}