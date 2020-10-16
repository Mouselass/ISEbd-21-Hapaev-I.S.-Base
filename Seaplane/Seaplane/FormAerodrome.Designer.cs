namespace Seaplane
{
    partial class FormAerodrome
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
            this.pictureBoxAerodrome = new System.Windows.Forms.PictureBox();
            this.buttonLandPlane = new System.Windows.Forms.Button();
            this.buttonLandWaterplane = new System.Windows.Forms.Button();
            this.groupBoxTakePlane = new System.Windows.Forms.GroupBox();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.buttonTake = new System.Windows.Forms.Button();
            this.labelPlace = new System.Windows.Forms.Label();
            this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
            this.labelAerodrome = new System.Windows.Forms.Label();
            this.buttonAddAerodrome = new System.Windows.Forms.Button();
            this.listBoxAerodrome = new System.Windows.Forms.ListBox();
            this.buttonDeleteAerodrome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAerodrome)).BeginInit();
            this.groupBoxTakePlane.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxAerodrome
            // 
            this.pictureBoxAerodrome.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxAerodrome.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxAerodrome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAerodrome.Name = "pictureBoxAerodrome";
            this.pictureBoxAerodrome.Size = new System.Drawing.Size(757, 534);
            this.pictureBoxAerodrome.TabIndex = 0;
            this.pictureBoxAerodrome.TabStop = false;
            // 
            // buttonLandPlane
            // 
            this.buttonLandPlane.Location = new System.Drawing.Point(763, 246);
            this.buttonLandPlane.Name = "buttonLandPlane";
            this.buttonLandPlane.Size = new System.Drawing.Size(134, 35);
            this.buttonLandPlane.TabIndex = 1;
            this.buttonLandPlane.Text = "Посадить самолет";
            this.buttonLandPlane.UseVisualStyleBackColor = true;
            this.buttonLandPlane.Click += new System.EventHandler(this.buttonLandPlane_Click);
            // 
            // buttonLandWaterplane
            // 
            this.buttonLandWaterplane.Location = new System.Drawing.Point(764, 287);
            this.buttonLandWaterplane.Name = "buttonLandWaterplane";
            this.buttonLandWaterplane.Size = new System.Drawing.Size(134, 41);
            this.buttonLandWaterplane.TabIndex = 2;
            this.buttonLandWaterplane.Text = "Посадить гидросамолет";
            this.buttonLandWaterplane.UseVisualStyleBackColor = true;
            this.buttonLandWaterplane.Click += new System.EventHandler(this.buttonLandWaterplane_Click);
            // 
            // groupBoxTakePlane
            // 
            this.groupBoxTakePlane.Controls.Add(this.maskedTextBox);
            this.groupBoxTakePlane.Controls.Add(this.buttonTake);
            this.groupBoxTakePlane.Controls.Add(this.labelPlace);
            this.groupBoxTakePlane.Location = new System.Drawing.Point(764, 344);
            this.groupBoxTakePlane.Name = "groupBoxTakePlane";
            this.groupBoxTakePlane.Size = new System.Drawing.Size(134, 123);
            this.groupBoxTakePlane.TabIndex = 3;
            this.groupBoxTakePlane.TabStop = false;
            this.groupBoxTakePlane.Text = "Забрать самолет";
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(58, 51);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(39, 20);
            this.maskedTextBox.TabIndex = 2;
            // 
            // buttonTake
            // 
            this.buttonTake.Location = new System.Drawing.Point(22, 94);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(75, 23);
            this.buttonTake.TabIndex = 1;
            this.buttonTake.Text = "Забрать";
            this.buttonTake.UseVisualStyleBackColor = true;
            this.buttonTake.Click += new System.EventHandler(this.buttonTakePlane_Click);
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(6, 54);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(45, 13);
            this.labelPlace.TabIndex = 0;
            this.labelPlace.Text = "Место :";
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(764, 27);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(133, 20);
            this.textBoxNewLevelName.TabIndex = 4;
            // 
            // labelAerodrome
            // 
            this.labelAerodrome.AutoSize = true;
            this.labelAerodrome.Location = new System.Drawing.Point(791, 9);
            this.labelAerodrome.Name = "labelAerodrome";
            this.labelAerodrome.Size = new System.Drawing.Size(69, 13);
            this.labelAerodrome.TabIndex = 5;
            this.labelAerodrome.Text = "Аэродромы:";
            // 
            // buttonAddAerodrome
            // 
            this.buttonAddAerodrome.Location = new System.Drawing.Point(764, 54);
            this.buttonAddAerodrome.Name = "buttonAddAerodrome";
            this.buttonAddAerodrome.Size = new System.Drawing.Size(133, 23);
            this.buttonAddAerodrome.TabIndex = 6;
            this.buttonAddAerodrome.Text = "Добавить аэродром";
            this.buttonAddAerodrome.UseVisualStyleBackColor = true;
            this.buttonAddAerodrome.Click += new System.EventHandler(this.buttonAddAerodrome_Click);
            // 
            // listBoxAerodrome
            // 
            this.listBoxAerodrome.FormattingEnabled = true;
            this.listBoxAerodrome.Location = new System.Drawing.Point(764, 84);
            this.listBoxAerodrome.Name = "listBoxAerodrome";
            this.listBoxAerodrome.Size = new System.Drawing.Size(133, 95);
            this.listBoxAerodrome.TabIndex = 7;
            this.listBoxAerodrome.Click += new System.EventHandler(this.listBoxAerodrome_SelectedIndexChanged);
            // 
            // buttonDeleteAerodrome
            // 
            this.buttonDeleteAerodrome.Location = new System.Drawing.Point(764, 186);
            this.buttonDeleteAerodrome.Name = "buttonDeleteAerodrome";
            this.buttonDeleteAerodrome.Size = new System.Drawing.Size(133, 23);
            this.buttonDeleteAerodrome.TabIndex = 8;
            this.buttonDeleteAerodrome.Text = "Удалить аэродром";
            this.buttonDeleteAerodrome.UseVisualStyleBackColor = true;
            this.buttonDeleteAerodrome.Click += new System.EventHandler(this.buttonDeleteAerodrome_Click);
            // 
            // FormAerodrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 534);
            this.Controls.Add(this.buttonDeleteAerodrome);
            this.Controls.Add(this.listBoxAerodrome);
            this.Controls.Add(this.buttonAddAerodrome);
            this.Controls.Add(this.labelAerodrome);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.groupBoxTakePlane);
            this.Controls.Add(this.buttonLandWaterplane);
            this.Controls.Add(this.buttonLandPlane);
            this.Controls.Add(this.pictureBoxAerodrome);
            this.Name = "FormAerodrome";
            this.Text = "Аэродром";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAerodrome)).EndInit();
            this.groupBoxTakePlane.ResumeLayout(false);
            this.groupBoxTakePlane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAerodrome;
        private System.Windows.Forms.Button buttonLandPlane;
        private System.Windows.Forms.Button buttonLandWaterplane;
        private System.Windows.Forms.GroupBox groupBoxTakePlane;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.TextBox textBoxNewLevelName;
        private System.Windows.Forms.Label labelAerodrome;
        private System.Windows.Forms.Button buttonAddAerodrome;
        private System.Windows.Forms.Button buttonDeleteAerodrome;
        private System.Windows.Forms.ListBox listBoxAerodrome;
    }
}