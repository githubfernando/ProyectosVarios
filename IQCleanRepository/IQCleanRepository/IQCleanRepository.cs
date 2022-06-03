using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQCleanRepositoryBLL.SanitasBLL;
using IQCleanRepositoryBLL.PPLBLL;
using IQCleanRepositoryBLL.MundialBLL;
using IQCleanRepositoryDAO.SanitasDAO;

namespace IQCleanRepository
{
    public partial class IQCleanRepository : Form
    {
        private readonly IProjectBLL _projects;
        private readonly IRepositoryBLL _repository;
        private readonly IDownloadReport _generateFile;
        private readonly IImportFileBLL _importFile;
        private readonly IFileCleanUpBLL _cleanup;
        private string userName;
        private string domain;
        ICheckRangeDate checkDate;// = new SanitasCheckDateBLL();
        //ICheckRangeDate pplCheck = new PPLCheckDateBLL();
        //ICheckRangeDate mundialCheck = new MundialCheckDateBLL();

        public IQCleanRepository(IProjectBLL project, IRepositoryBLL repository, IDownloadReport generateFile
            , IImportFileBLL import, IFileCleanUpBLL cleanup)
        {
            _projects = project;
            _repository = repository;
            _generateFile = generateFile;
            _importFile = import;
            _cleanup = cleanup;
            InitializeComponent();
            ObtainUser();
        }

        private void LoadProjects()
        {
            cbProject.DataSource = _projects.GetProjects();
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "Id";
        }
        private void LoadRepository(int Id)
        {
            cbOrigen.DataSource = _repository.GetRepository(Id);
            cbOrigen.DisplayMember = "Name";
            cbOrigen.ValueMember = "Id";
            //GetDataDirectories();
        }
        private void ObtainUser()
        {
            domain = Environment.UserDomainName;
            userName = Environment.UserName;
        }
        private void ResetValuelbl()
        {
            lblValueConsultDate.Text = "0";
            lblValueProcesados.Text = "0";
            lblValueImageSnap.Text = "0";
        }
        private void ResetCalendar()
        {
            dtPickerDateIni.Value = DateTime.Now;
            dtPickerDateEnd.Value = DateTime.Now;
        }
        private void LockControlsIn()
        {
            cbOrigen.Enabled = false;
            cbProject.Enabled = false;
            dtPickerDateEnd.Enabled = false;
            dtPickerDateIni.Enabled = false;
        }
        private void UnlockControlsIn()
        {
            cbOrigen.Enabled = true;
            cbProject.Enabled = true;
            dtPickerDateEnd.Enabled = true;
            dtPickerDateIni.Enabled = true;
        }
        private void LockControlsStage2()
        {
            btnDownload.Enabled = false;
            btnImagesCleanUp.Enabled = false;
            btnImportFile.Enabled = false;
        }
        private void UnlockControlsStage2()
        {
            btnDownload.Enabled = true;
        }
        private void UnlockControlsStage3()
        {
            btnImportFile.Enabled = true;
            btnImagesCleanUp.Enabled = true;
        }
        private void btnCleanForm_Click(object sender, EventArgs e)
        {
            UnlockControlsIn();
            ResetCalendar();
            ResetValuelbl();
            LockControlsStage2();
        }
        private (int, string) GetCurrentProjectId()
        {
            int id = Convert.ToInt32(cbProject.SelectedItem.GetType().GetProperty("Id").GetValue(cbProject.SelectedItem).ToString());
            string name = (cbProject.SelectedItem.GetType().GetProperty("Name").GetValue(cbProject.SelectedItem).ToString());
            return (id, name);
        }
        private (int, string) GetCurrentRepositoryId()
        {
            int id = Convert.ToInt32(cbOrigen.SelectedItem.GetType().GetProperty("Id").GetValue(cbOrigen.SelectedItem).ToString());
            string name = (cbOrigen.SelectedItem.GetType().GetProperty("Name").GetValue(cbOrigen.SelectedItem).ToString());
            return (id, name);
        }
        private void RestrictDate()
        {
            dtPickerDateIni.MaxDate = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            dtPickerDateEnd.MaxDate = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
        }
        private bool ValidateConsult()
        {
            if (dtPickerDateIni.Value > dtPickerDateEnd.Value)
            {
                MessageBox.Show("La fecha inicio es mayor a la fecha fin.");
                return false;
            }
            else
                return true;
        }
        private (bool, string) ValidateUser()
        {
            string message = "Bienvenido a la aplicación.\n Ha ingresado con el usuario: " + userName;
            if (domain != "IQADMNT01" || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Su usuario no tiene permisos a esta aplicación");
                Application.Exit();
                return (false, message);
            }
            else
                return (true, message);
        }
        private void InjectCustomer(ICheckRangeDate customer)
        {
            checkDate = customer;
        }
        private int ExecuteConsult()
        {
            int repositoryId = GetCurrentRepositoryId().Item1;
            DateTime dateIni = dtPickerDateIni.Value.Date.Add(new TimeSpan(0, 00, 0));
            DateTime dateEnd = dtPickerDateEnd.Value.Date.Add(new TimeSpan(23, 59, 59));
            string customer = GetCurrentProjectId().Item2;
            string repository=null;
            switch (customer)
            { 
                case "Sanitas":
                    InjectCustomer(new SanitasCheckDateBLL());
                break;
                case "PPL":
                    InjectCustomer(new PPLCheckDateBLL());
                    break;
                case "Mundial":
                    InjectCustomer(new MundialCheckDateBLL());
                    repository = GetCurrentRepositoryId().Item2;
                    break;
                default:
                    break;
            }
            var consultaRad = checkDate.GetCheckRangeDate(dateIni, dateEnd, repository);
            lblValueConsultDate.Text = consultaRad.Count().ToString();
            var checkProcessed = checkDate.CheckDataProcessed(consultaRad);
            lblValueProcesados.Text = checkProcessed.Count().ToString();
            var listSnap = checkDate.ListImages(checkProcessed, repository);
            lblValueImageSnap.Text = listSnap.Count().ToString();
            var saveList = checkDate.SaveList(listSnap, repositoryId, userName);

            return listSnap.Count();
        }
        private void IQCleanRepository_Load(object sender, EventArgs e)
        {
            ObtainUser();
            var validateUser = ValidateUser();
            if (validateUser.Item1)
                //MessageBox.Show(validateUser.Item2);
            LoadProjects();
            LockControlsStage2();
            RestrictDate();
        }

        private void cboOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentProjectId().Item1;
            LoadRepository(id);
        }
        
        private void btnConsultRepository_Click(object sender, EventArgs e)
        {
            try
            {
                ResetValuelbl();
                if (ValidateConsult())
                {
                    if (ExecuteConsult() >= 1)
                    {
                        LockControlsIn();
                        UnlockControlsStage2();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error obteniendo los datos: "+ex.Message);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnImagesCleanUp_Click(object sender, EventArgs e)
        {
            try
            {
                string result = _cleanup.RunFilesCleanUp(GetCurrentRepositoryId().Item1
                    ,GetCurrentRepositoryId().Item2, userName);
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                throw;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                int repositoryId = GetCurrentRepositoryId().Item1;
                string resultGenerate = _generateFile.GenerateReport(repositoryId);
                if (!string.IsNullOrEmpty(resultGenerate))
                {
                    MessageBox.Show(resultGenerate);
                    UnlockControlsStage3();
                }
                else
                    MessageBox.Show("No se generó la información del archivo.","Generacion csv",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la generación del archivo: " + ex.Message);
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogImport.ShowDialog() == DialogResult.OK)
            {
                int repositoryId = GetCurrentRepositoryId().Item1;
                string fileName = openFileDialogImport.FileName;
                int carga = _importFile.ImportFile(fileName, repositoryId, userName);
                MessageBox.Show("Se cargaron: " + carga + " registros.");
            }
        }
    }
}
