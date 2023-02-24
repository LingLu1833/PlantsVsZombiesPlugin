namespace PlantsVsZombiesPlugin
{
    partial class Form_Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_ReadMemory = new System.Windows.Forms.Button();
            this.Button_WriteMemory = new System.Windows.Forms.Button();
            this.TextBox_Number = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_ReadMemory
            // 
            this.Button_ReadMemory.Location = new System.Drawing.Point(12, 12);
            this.Button_ReadMemory.Name = "Button_ReadMemory";
            this.Button_ReadMemory.Size = new System.Drawing.Size(100, 50);
            this.Button_ReadMemory.TabIndex = 1;
            this.Button_ReadMemory.Text = "读取阳光";
            this.Button_ReadMemory.UseVisualStyleBackColor = true;
            this.Button_ReadMemory.Click += new System.EventHandler(this.Button_ReadMemory_Click);
            // 
            // Button_WriteMemory
            // 
            this.Button_WriteMemory.Location = new System.Drawing.Point(12, 91);
            this.Button_WriteMemory.Name = "Button_WriteMemory";
            this.Button_WriteMemory.Size = new System.Drawing.Size(100, 50);
            this.Button_WriteMemory.TabIndex = 2;
            this.Button_WriteMemory.Text = "修改阳光";
            this.Button_WriteMemory.UseVisualStyleBackColor = true;
            this.Button_WriteMemory.Click += new System.EventHandler(this.Button_WriteMemory_Click);
            // 
            // TextBox_Number
            // 
            this.TextBox_Number.Location = new System.Drawing.Point(118, 106);
            this.TextBox_Number.Name = "TextBox_Number";
            this.TextBox_Number.Size = new System.Drawing.Size(50, 25);
            this.TextBox_Number.TabIndex = 3;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.TextBox_Number);
            this.Controls.Add(this.Button_WriteMemory);
            this.Controls.Add(this.Button_ReadMemory);
            this.Name = "Form_Main";
            this.Text = "PlantsVsZombies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button_ReadMemory;
        private System.Windows.Forms.Button Button_WriteMemory;
        private System.Windows.Forms.TextBox TextBox_Number;
    }
}

