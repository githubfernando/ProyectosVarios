using IQCleanRepositoryBLL;
using IQCleanRepositoryBLL.SanitasBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQCleanRepository
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var project = new ProjectBLL();
                var repos = new RepositoryBLL();
                var generateFile = new DownloadReportBLL();
                var importFile = new ImportFileBLL();
                var clean = new FileCleanUpBLL();
                Application.Run(new IQCleanRepository(project, repos, generateFile, importFile, clean));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error realizando el proceso: "+ ex.Message);
            }
            
        }
    }
}
