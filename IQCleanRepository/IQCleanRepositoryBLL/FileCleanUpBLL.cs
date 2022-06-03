using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryDAL;
using IQCleanRepositoryDAL.Service;
using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL
{
    public class FileCleanUpBLL : IFileCleanUpBLL
    {
        private readonly FileCleanUp _fileCleanUp;
        public FileCleanUpBLL()
        {
            _fileCleanUp = new FileCleanUp();
        }

        public string RunFilesCleanUp(int repository_id, string repositoryName, string user)
        {
            List<ImagesCleanUpDAO> list, result = new List<ImagesCleanUpDAO>();
            int saveCount=0;
            list = _fileCleanUp.GetFilesToCleanUp(repository_id, user);
            result = DeleteFiles(list, repositoryName);

            if (result.Count >= 1)
            {
                saveCount = _fileCleanUp.SaveFilesCleanup(result, repository_id, user);
                if (saveCount >= 1)
                    return "Se realizó la limpieza del repositorio seleccionado, consulte el reporte.";
                else
                    return "Se realizó la limpieza del repositorio pero hubo un problema en el guardado de los datos";
            }
            else
                return "No se realizó la limpieza del repositorio selecionado.";
        }

        private List<ImagesCleanUpDAO> DeleteFiles(List<ImagesCleanUpDAO> list, string repositoryName)
        {
            List<ImagesCleanUpDAO> result = new List<ImagesCleanUpDAO>();
            if (repositoryName == "Blob Storage")
            {
                var handlerBlob = new StorageHandlerService();
                var containerList = list.Select(x => x.Blob).Distinct();
                foreach (string container in containerList)
                {
                    var listBlob = handlerBlob.ListBlob(container);
                    if (listBlob.Count() > 0)
                    {
                        foreach (var file in list.Where(x => x.Blob.Equals(container)))
                        {
                            string realNameFile="";
                            string folder="";
                            if (file.Directory == "PRW")
                            {
                                realNameFile = (from x in listBlob where x.fileName.Contains(file.FileName) select x.fileName).FirstOrDefault();
                                if (!string.IsNullOrEmpty(realNameFile))
                                {
                                    file.RutaImagen = realNameFile;
                                    folder = file.Directory == "PRW" ? "PRW" : ""; 
                                }
                                else
                                {
                                    file.EstadoLimpieza = "No se encotró el archivo de este radicado en el blob container: " + container;
                                }
                            }
                            else
                            {
                                //PRED
                                realNameFile = string.Concat(file.Blob, "-", file.FileName);
                            }
                            var state = handlerBlob.DeleteBlobItem(file.Blob, realNameFile, folder);
                            file.EstadoLimpieza = state;
                            
                            result.Add(file);
                        }
                    }
                    else
                    {
                        var updateReg = list.Where(x => x.Blob.Equals(container)).ToList();
                        foreach (var reg in updateReg)
                        {
                            reg.EstadoLimpieza = "No se encotró el archivo de este radicado en el blob container: " + container;
                            result.Add(reg);
                        }
                    }
                }
                return result;
            }
            else
            {
                foreach (var l in list)
                {
                    try
                    {
                        if (!File.Exists(l.RutaImagen))
                            l.EstadoLimpieza = "El archivo no existe.";
                        else
                        {
                            File.Delete(l.RutaImagen);
                            l.EstadoLimpieza = "Archivo borrado satisfactoriamente.";
                            l.FechaEliminacion = DateTime.Now;
                            result.Add(l);
                        }
                    }
                    catch (Exception ex)
                    {
                        l.EstadoLimpieza = ex.ToString();
                        result.Add(l);
                    }
                }
                return result;
            }
                
        }
    }
}
