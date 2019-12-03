namespace TextProcessing
{
    partial class StartWindow
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
            this.buttonChooseFileTxt = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelErrorChooseFile = new System.Windows.Forms.Label();
            this.buttonSortSentences = new System.Windows.Forms.Button();
            this.buttonConcordance = new System.Windows.Forms.Button();
            this.buttonSaveText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChooseFileTxt
            // 
            this.buttonChooseFileTxt.Location = new System.Drawing.Point(625, 34);
            this.buttonChooseFileTxt.Name = "buttonChooseFileTxt";
            this.buttonChooseFileTxt.Size = new System.Drawing.Size(123, 40);
            this.buttonChooseFileTxt.TabIndex = 1;
            this.buttonChooseFileTxt.Text = "Choose file .txt";
            this.buttonChooseFileTxt.UseVisualStyleBackColor = true;
            this.buttonChooseFileTxt.Click += new System.EventHandler(this.buttonChooseFileTxt_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(12, 9);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(43, 20);
            this.labelText.TabIndex = 2;
            this.labelText.Text = "Text";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"Text|*.txt|All|*.*\"";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 34);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(571, 295);
            this.textBox.TabIndex = 3;
            // 
            // labelErrorChooseFile
            // 
            this.labelErrorChooseFile.AutoSize = true;
            this.labelErrorChooseFile.BackColor = System.Drawing.Color.Transparent;
            this.labelErrorChooseFile.ForeColor = System.Drawing.Color.Red;
            this.labelErrorChooseFile.Location = new System.Drawing.Point(621, 77);
            this.labelErrorChooseFile.Name = "labelErrorChooseFile";
            this.labelErrorChooseFile.Size = new System.Drawing.Size(136, 20);
            this.labelErrorChooseFile.TabIndex = 4;
            this.labelErrorChooseFile.Text = "Wrong file format";
            // 
            // buttonSortSentences
            // 
            this.buttonSortSentences.Location = new System.Drawing.Point(625, 185);
            this.buttonSortSentences.Name = "buttonSortSentences";
            this.buttonSortSentences.Size = new System.Drawing.Size(123, 52);
            this.buttonSortSentences.TabIndex = 5;
            this.buttonSortSentences.Text = "Sort sentences by words count";
            this.buttonSortSentences.UseVisualStyleBackColor = true;
            this.buttonSortSentences.Click += new System.EventHandler(this.buttonSortSentences_Click);
            // 
            // buttonConcordance
            // 
            this.buttonConcordance.Location = new System.Drawing.Point(625, 268);
            this.buttonConcordance.Name = "buttonConcordance";
            this.buttonConcordance.Size = new System.Drawing.Size(123, 40);
            this.buttonConcordance.TabIndex = 6;
            this.buttonConcordance.Text = "Concordance";
            this.buttonConcordance.UseVisualStyleBackColor = true;
            this.buttonConcordance.Click += new System.EventHandler(this.buttonConcordance_Click);
            // 
            // buttonSaveText
            // 
            this.buttonSaveText.Location = new System.Drawing.Point(625, 139);
            this.buttonSaveText.Name = "buttonSaveText";
            this.buttonSaveText.Size = new System.Drawing.Size(123, 40);
            this.buttonSaveText.TabIndex = 7;
            this.buttonSaveText.Text = "Save text";
            this.buttonSaveText.UseVisualStyleBackColor = true;
            this.buttonSaveText.Click += new System.EventHandler(this.buttonSaveText_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(776, 341);
            this.Controls.Add(this.buttonSaveText);
            this.Controls.Add(this.buttonConcordance);
            this.Controls.Add(this.buttonSortSentences);
            this.Controls.Add(this.labelErrorChooseFile);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.buttonChooseFileTxt);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StartWindow";
            this.Text = "Text processing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonChooseFileTxt;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelErrorChooseFile;
        private System.Windows.Forms.Button buttonSortSentences;
        private System.Windows.Forms.Button buttonConcordance;
        private System.Windows.Forms.Button buttonSaveText;
    }
}

