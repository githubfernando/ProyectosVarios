using AppCleanImageBLL;
using AppCleanImageDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCleanImage
{
    public partial class Index : Form
    {

        private ProjectBLL logicProject;
        private RouteBLL logicRoute;

        public Index()
        {
            InitializeComponent();
        }
        private void Index_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            logicProject = new ProjectBLL();
            cbProject.DataSource = logicProject.GetProjects();
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "Id";
        }

        private void LoadRoutes(int Id)
        {
            logicRoute = new RouteBLL();
            cbRoute.DataSource = logicRoute.GetRoutes(Id);
            cbRoute.DisplayMember = "Route";
            cbRoute.ValueMember = "Id";
            GetDataDirectories();
           
        }

        private void GetDataDirectories()
        {
            int countDirectories = 0;
            var directories = Directory.GetDirectories(cbRoute.Text);
            countDirectories = directories.Count();
            foreach (var item in directories)
            {
                
            }
        }

        private void cbProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var obj = int.Parse(cbProject.SelectedValue.ToString());            
            LoadRoutes(obj);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            ValidateCleanImage();
        }

        private void ValidateCleanImage()
        {
            try
            {
                
            }
             catch (Exception ex)
            {

                throw;
            }
        }

        private void cbProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
