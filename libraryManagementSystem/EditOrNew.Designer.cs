namespace libraryManagementSystem
{
    partial class editOrNew
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
            this.txtBoxEdtTitle = new System.Windows.Forms.TextBox();
            this.txtBoxEdtAuth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSbmit = new System.Windows.Forms.Button();
            this.labelEdit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxCopies = new System.Windows.Forms.TextBox();
            this.txtBoxNames = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxEdtTitle
            // 
            this.txtBoxEdtTitle.Location = new System.Drawing.Point(106, 27);
            this.txtBoxEdtTitle.Name = "txtBoxEdtTitle";
            this.txtBoxEdtTitle.Size = new System.Drawing.Size(241, 26);
            this.txtBoxEdtTitle.TabIndex = 0;
            // 
            // txtBoxEdtAuth
            // 
            this.txtBoxEdtAuth.Location = new System.Drawing.Point(106, 71);
            this.txtBoxEdtAuth.Name = "txtBoxEdtAuth";
            this.txtBoxEdtAuth.Size = new System.Drawing.Size(241, 26);
            this.txtBoxEdtAuth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author:";
            // 
            // buttonSbmit
            // 
            this.buttonSbmit.Location = new System.Drawing.Point(425, 54);
            this.buttonSbmit.Name = "buttonSbmit";
            this.buttonSbmit.Size = new System.Drawing.Size(100, 43);
            this.buttonSbmit.TabIndex = 4;
            this.buttonSbmit.Text = "Submit";
            this.buttonSbmit.UseVisualStyleBackColor = true;
            this.buttonSbmit.Click += new System.EventHandler(this.buttonSbmit_Click);
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEdit.Location = new System.Drawing.Point(225, 4);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(41, 20);
            this.labelEdit.TabIndex = 5;
            this.labelEdit.Text = "Edit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Copies:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Names:";
            // 
            // txtBoxCopies
            // 
            this.txtBoxCopies.Location = new System.Drawing.Point(106, 161);
            this.txtBoxCopies.Name = "txtBoxCopies";
            this.txtBoxCopies.Size = new System.Drawing.Size(45, 26);
            this.txtBoxCopies.TabIndex = 7;
            // 
            // txtBoxNames
            // 
            this.txtBoxNames.Location = new System.Drawing.Point(106, 117);
            this.txtBoxNames.Name = "txtBoxNames";
            this.txtBoxNames.Size = new System.Drawing.Size(241, 26);
            this.txtBoxNames.TabIndex = 6;
            // 
            // editOrNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 196);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxCopies);
            this.Controls.Add(this.txtBoxNames);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.buttonSbmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxEdtAuth);
            this.Controls.Add(this.txtBoxEdtTitle);
            this.Name = "editOrNew";
            this.Text = "Edit Or enter new book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxEdtTitle;
        private System.Windows.Forms.TextBox txtBoxEdtAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSbmit;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxCopies;
        private System.Windows.Forms.TextBox txtBoxNames;
    }
}