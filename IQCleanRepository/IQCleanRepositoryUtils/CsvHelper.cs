using CsvHelper;
using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryUtils
{
    public class CsvHelper
    {
        public CsvHelper()
        { 

        }

        public string GenerateFileCsv(List<ImagesCleanUpDAO> list)
        {
            string result = "";
            try
            {
                if (list.Count >= 1)
                {   
                    string path = ConfigurationManager.AppSettings[("savePathCSV")];
                    string fileName = ConfigurationManager.AppSettings[("fileName")];
                    string pathComplete = path + fileName;
                    using (var writer = new StreamWriter(path + fileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(list);
                    }
                    result = "Se generó el archivo correctamente en: " + pathComplete;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presentaron errores generando el csv: " + ex.Message);
            }
            
        }

        public List<ImagesCleanUpDAO> ImportFileCsv(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<ImagesCleanUpDAO>();
                        var listResult = records.ToList();
                        return listResult;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Se presentaron errores cargando el archivo csv: "+ex.Message );
            }
        }
    }
}
