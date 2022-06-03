
namespace IQCleanRepository
{
    partial class IQCleanRepository
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProject = new System.Windows.Forms.ComboBox();
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.btnConsultRepository = new System.Windows.Forms.Button();
            this.dtPickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtPickerDateIni = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImagesCleanUp = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblValueImageSnap = new System.Windows.Forms.Label();
            this.lblValueProcesados = new System.Windows.Forms.Label();
            this.lblValueConsultDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblConsultDate = new System.Windows.Forms.Label();
            this.btnCleanForm = new System.Windows.Forms.Button();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProject
            // 
            this.cbProject.FormattingEnabled = true;
            this.cbProject.Location = new System.Drawing.Point(484, 62);
            this.cbProject.Name = "cbProject";
            this.cbProject.Size = new System.Drawing.Size(170, 23);
            this.cbProject.TabIndex = 0;
            this.cbProject.SelectedIndexChanged += new System.EventHandler(this.cbProject_SelectedIndexChanged);
            // 
            // cbOrigen
            // 
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(484, 118);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(170, 23);
            this.cbOrigen.TabIndex = 1;
            this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cboOrigen_SelectedIndexChanged);
            // 
            // btnConsultRepository
            // 
            this.btnConsultRepository.Location = new System.Drawing.Point(341, 306);
            this.btnConsultRepository.Name = "btnConsultRepository";
            this.btnConsultRepository.Size = new System.Drawing.Size(161, 30);
            this.btnConsultRepository.TabIndex = 5;
            this.btnConsultRepository.Text = "Consultar repositorio";
            this.btnConsultRepository.UseVisualStyleBackColor = true;
            this.btnConsultRepository.Click += new System.EventHandler(this.btnConsultRepository_Click);
            // 
            // dtPickerDateEnd
            // 
            this.dtPickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerDateEnd.Location = new System.Drawing.Point(484, 236);
            this.dtPickerDateEnd.Name = "dtPickerDateEnd";
            this.dtPickerDateEnd.Size = new System.Drawing.Size(200, 23);
            this.dtPickerDateEnd.TabIndex = 6;
            // 
            // dtPickerDateIni
            // 
            this.dtPickerDateIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerDateIni.Location = new System.Drawing.Point(484, 179);
            this.dtPickerDateIni.Name = "dtPickerDateIni";
            this.dtPickerDateIni.Size = new System.Drawing.Size(200, 23);
            this.dtPickerDateIni.TabIndex = 7;
            this.dtPickerDateIni.Value = new System.DateTime(2021, 5, 25, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccionar proyecto :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seleccionar repositorio :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Seleccionar fecha inicial :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Seleccionar fecha fin :";
            // 
            // btnImagesCleanUp
            // 
            this.btnImagesCleanUp.Location = new System.Drawing.Point(339, 616);
            this.btnImagesCleanUp.Name = "btnImagesCleanUp";
            this.btnImagesCleanUp.Size = new System.Drawing.Size(205, 34);
            this.btnImagesCleanUp.TabIndex = 13;
            this.btnImagesCleanUp.Text = "Eliminar imágenes del repositorio";
            this.btnImagesCleanUp.UseVisualStyleBackColor = true;
            this.btnImagesCleanUp.Click += new System.EventHandler(this.btnImagesCleanUp_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(339, 528);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(161, 33);
            this.btnDownload.TabIndex = 14;
            this.btnDownload.Text = "Descargar consulta";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnImportFile
            // 
            this.btnImportFile.Location = new System.Drawing.Point(592, 528);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(107, 33);
            this.btnImportFile.TabIndex = 15;
            this.btnImportFile.Text = "Importar archivo";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblValueImageSnap);
            this.panel1.Controls.Add(this.lblValueProcesados);
            this.panel1.Controls.Add(this.lblValueConsultDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblConsultDate);
            this.panel1.Location = new System.Drawing.Point(339, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 91);
            this.panel1.TabIndex = 16;
            // 
            // lblValueImageSnap
            // 
            this.lblValueImageSnap.AutoSize = true;
            this.lblValueImageSnap.Location = new System.Drawing.Point(195, 67);
            this.lblValueImageSnap.Name = "lblValueImageSnap";
            this.lblValueImageSnap.Size = new System.Drawing.Size(13, 15);
            this.lblValueImageSnap.TabIndex = 5;
            this.lblValueImageSnap.Text = "0";
            // 
            // lblValueProcesados
            // 
            this.lblValueProcesados.AutoSize = true;
            this.lblValueProcesados.Location = new System.Drawing.Point(195, 39);
            this.lblValueProcesados.Name = "lblValueProcesados";
            this.lblValueProcesados.Size = new System.Drawing.Size(13, 15);
            this.lblValueProcesados.TabIndex = 4;
            this.lblValueProcesados.Text = "0";
            // 
            // lblValueConsultDate
            // 
            this.lblValueConsultDate.AutoSize = true;
            this.lblValueConsultDate.Location = new System.Drawing.Point(195, 11);
            this.lblValueConsultDate.Name = "lblValueConsultDate";
            this.lblValueConsultDate.Size = new System.Drawing.Size(13, 15);
            this.lblValueConsultDate.TabIndex = 3;
            this.lblValueConsultDate.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Total listado con ruta imagen :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Procesados :";
            // 
            // lblConsultDate
            // 
            this.lblConsultDate.AutoSize = true;
            this.lblConsultDate.Location = new System.Drawing.Point(20, 11);
            this.lblConsultDate.Name = "lblConsultDate";
            this.lblConsultDate.Size = new System.Drawing.Size(132, 15);
            this.lblConsultDate.TabIndex = 0;
            this.lblConsultDate.Text = "Consultados por fecha :";
            // 
            // btnCleanForm
            // 
            this.btnCleanForm.Location = new System.Drawing.Point(582, 306);
            this.btnCleanForm.Name = "btnCleanForm";
            this.btnCleanForm.Size = new System.Drawing.Size(117, 30);
            this.btnCleanForm.TabIndex = 17;
            this.btnCleanForm.Text = "Limpiar consulta";
            this.btnCleanForm.UseVisualStyleBackColor = true;
            this.btnCleanForm.Click += new System.EventHandler(this.btnCleanForm_Click);
            // 
            // openFileDialogImport
            // 
            this.openFileDialogImport.FileName = "openFileDialogImport";
            // 
            // IQCleanRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 749);
            this.Controls.Add(this.btnCleanForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnImportFile);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnImagesCleanUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPickerDateIni);
            this.Controls.Add(this.dtPickerDateEnd);
            this.Controls.Add(this.btnConsultRepository);
            this.Controls.Add(this.cbOrigen);
            this.Controls.Add(this.cbProject);
            this.Name = "IQCleanRepository";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.IQCleanRepository_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProject;
        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Button btnConsultRepository;
        private System.Windows.Forms.DateTimePicker dtPickerDateEnd;
        private System.Windows.Forms.DateTimePicker dtPickerDateIni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImagesCleanUp;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblValueImageSnap;
        private System.Windows.Forms.Label lblValueProcesados;
        private System.Windows.Forms.Label lblValueConsultDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblConsultDate;
        private System.Windows.Forms.Button btnCleanForm;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
    }
}

