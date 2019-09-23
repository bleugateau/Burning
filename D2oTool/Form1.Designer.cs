namespace D2oTool
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.pathOfFile = new System.Windows.Forms.TextBox();
            this.dataList = new System.Windows.Forms.ListView();
            this.save = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(575, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // pathOfFile
            // 
            this.pathOfFile.Location = new System.Drawing.Point(160, 12);
            this.pathOfFile.Name = "pathOfFile";
            this.pathOfFile.Size = new System.Drawing.Size(387, 20);
            this.pathOfFile.TabIndex = 1;
            // 
            // dataList
            // 
            this.dataList.Location = new System.Drawing.Point(34, 67);
            this.dataList.Name = "dataList";
            this.dataList.Size = new System.Drawing.Size(739, 344);
            this.dataList.TabIndex = 2;
            this.dataList.UseCompatibleStateImageBehavior = false;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(352, 418);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save d2o";
            this.save.UseVisualStyleBackColor = true;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(657, 423);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 13);
            this.countLabel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.pathOfFile);
            this.Controls.Add(this.openFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        public System.Windows.Forms.TextBox pathOfFile;
        private System.Windows.Forms.Button save;
        public System.Windows.Forms.ListView dataList;
        private System.Windows.Forms.Label countLabel;
    }
}

