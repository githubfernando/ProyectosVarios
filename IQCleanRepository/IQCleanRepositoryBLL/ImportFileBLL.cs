using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL
{
    public class ImportFileBLL : IImportFileBLL
    {
        private readonly ImportFile _importFile;
        //Importar archivo
        public ImportFileBLL()
        {
            _importFile = new ImportFile();
        }
        public int ImportFile(string fileName, int repositoryId, string user)
        {
            try
            {
                int result = _importFile.ImportFileToBD(fileName, repositoryId, user);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en la importación del archivo: "+ex.Message);
            }
            
        }
    }
}
