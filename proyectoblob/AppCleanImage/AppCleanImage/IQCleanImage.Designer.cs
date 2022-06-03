
namespace AppCleanImage
{
    partial class Index
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProject = new System.Windows.Forms.ComboBox();
            this.cbRoute = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbProject
            // 
            this.cbProject.FormattingEnabled = true;
            this.cbProject.Location = new System.Drawing.Point(124, 46);
            this.cbProject.Name = "cbProject";
            this.cbProject.Size = new System.Drawing.Size(121, 21);
            this.cbProject.TabIndex = 0;
            this.cbProject.SelectedIndexChanged += new System.EventHandler(this.cbProject_SelectedIndexChanged);
            this.cbProject.SelectionChangeCommitted += new System.EventHandler(this.cbProject_SelectionChangeCommitted);
            // 
            // cbRoute
            // 
            this.cbRoute.FormattingEnabled = true;
            this.cbRoute.Location = new System.Drawing.Point(428, 46);
            this.cbRoute.Name = "cbRoute";
            this.cbRoute.Size = new System.Drawing.Size(204, 21);
            this.cbRoute.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proyecto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ruta repositorio";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(72, 227);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 4;
            this.btnClean.Text = "Clean Image";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad de subdirectorios";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad de imagenes";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRoute);
            this.Controls.Add(this.cbProject);
            this.Name = "Index";
            this.Text = "IQ Clean Image";
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProject;
        private System.Windows.Forms.ComboBox cbRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

