namespace TaskMonitor
{
    partial class EndMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndMonitor));
            this.label_type = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label_monitorName = new System.Windows.Forms.Label();
            this.comboBox_monitorName = new System.Windows.Forms.ComboBox();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(13, 19);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(28, 13);
            this.label_type.TabIndex = 0;
            this.label_type.Text = "Tipo";
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "Servicio",
            "Proceso"});
            this.comboBox_type.Location = new System.Drawing.Point(65, 16);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(122, 21);
            this.comboBox_type.TabIndex = 1;
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // label_monitorName
            // 
            this.label_monitorName.AutoSize = true;
            this.label_monitorName.Location = new System.Drawing.Point(13, 56);
            this.label_monitorName.Name = "label_monitorName";
            this.label_monitorName.Size = new System.Drawing.Size(44, 13);
            this.label_monitorName.TabIndex = 2;
            this.label_monitorName.Text = "Nombre";
            // 
            // comboBox_monitorName
            // 
            this.comboBox_monitorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_monitorName.FormattingEnabled = true;
            this.comboBox_monitorName.Location = new System.Drawing.Point(65, 53);
            this.comboBox_monitorName.Name = "comboBox_monitorName";
            this.comboBox_monitorName.Size = new System.Drawing.Size(207, 21);
            this.comboBox_monitorName.TabIndex = 3;
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(40, 92);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(90, 28);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "Quitar";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(159, 92);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(90, 28);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // EndMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 132);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.comboBox_monitorName);
            this.Controls.Add(this.label_monitorName);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.label_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EndMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EndMonitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label label_monitorName;
        private System.Windows.Forms.ComboBox comboBox_monitorName;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_cancel;
    }
}