using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HandlerBlobStorage
{
    class Program
    {
        public static string StorageAccountName { get; set; }
        public static string StorageAccountKey { get; set; }
        private static CloudStorageAccount storageAccount;
        private static string log = ConfigurationManager.AppSettings["RutaLog"];
        private static object _lockObject = new object();

        public static async Task Main(string[] args)
        {
            List<objeto> list = new List<objeto>();
            list.Add(new objeto
            {
                blob = "800110181",
                file = "AA"
            });
            list.Add(new objeto
            {
                blob = "800110181",
                file = "BB"
            });
            list.Add(new objeto
            {
                blob = "800110181",
                file = "CC"
            });
            list.Add(new objeto
            {
                blob = "789",
                file = "AB"
            });
            list.Add(new objeto
            {
                blob = "789",
                file = "CD"
            });

            var filtro = list.Select(x => x.blob).Distinct();
            string blob = "800110181";
            var listBlob = ListBlob(blob);

            var result = DeleteBlobItem(blob, "prueba.png", "");


            //RenameFileInBlob();
            foreach (var f in filtro)
            { 
                //listar blob

                //comparar cada archivo con la lista del blob y extraer el nombre completo

                //mandar a borrar el nombre completo
            }
        }

        public static List<BlobMundialDAO> ListBlob(string container)
        {
            List<BlobMundialDAO> blobFile = new List<BlobMundialDAO>();
            try
            {
                string StorageAccountName = ConfigurationManager.AppSettings["StorageConnectionString"];
                BlobContainerClient containerClient = new BlobContainerClient(StorageAccountName, container);
                if (containerClient.Exists())
                {
                    var getBlob = containerClient.GetBlobs().Where(x => x.Name.Contains(".zip"));
                    foreach (var blob in getBlob)
                    {
                        blobFile.Add(
                        new BlobMundialDAO
                        {
                            blobName = container,
                            fileName = blob.Name
                        });
                    }
                    return blobFile;
                }
                else
                    return blobFile;
            }
            catch (Exception ex)
            {
                return blobFile;
            }

        }

        public static string DeleteBlobItem(string blob, string fileName, string directory)
        {
            StorageAccountName = ConfigurationManager.AppSettings["StorageAccountName"];
            StorageAccountKey = ConfigurationManager.AppSettings["StorageAccountKey"];
            storageAccount = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey), true);

            try
            {
                string addressFile = Path.Combine(directory, "").Replace("\\", "/");
                CloudBlobClient blobClientSource = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainerSource = blobClientSource.GetContainerReference(Path.Combine(blob, ""));
                //CloudBlobContainer blobContainerSource = blobClientSource.GetContainerReference(Path.Combine(blob, addressFile));
                CloudBlockBlob blockBlobSource = blobContainerSource.GetBlockBlobReference(fileName);
                if (blockBlobSource.ExistsAsync().Result)
                {
                    var re = blockBlobSource.DeleteAsync();
                    re.Wait();
                    while (re.IsCompleted == false)
                    {
                        Thread.Sleep(1000);
                    }

                    return ("Se eliminó el archivo: " + fileName);
                }
                else
                {
                    return ("El archivo a eliminar no existe.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RenameFileInBlob()
        {
            try
            {
                StorageAccountName = ConfigurationManager.AppSettings["StorageAccountName"];
                StorageAccountKey = ConfigurationManager.AppSettings["StorageAccountKey"];
                storageAccount = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey), true);
                string FileToRead = ConfigurationManager.AppSettings["DirectoryFile"];
                try
                {
                    string containerSource = "800110181";
                    string fileExists = "prueba.png";
                    //prw
                    string addressFile = Path.Combine("PRW", "").Replace("\\", "/");
                    CloudBlobClient blobClientSource = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainerSource = blobClientSource.GetContainerReference(Path.Combine(containerSource, addressFile)); ;
                    CloudBlockBlob blockBlobSource = blobContainerSource.GetBlockBlobReference(fileExists);
                    //prw explore directorio
                    CloudBlobContainer blobContainerSourceDirectory = blobClientSource.GetContainerReference(containerSource);
                    CloudBlobDirectory directory = blobContainerSourceDirectory.GetDirectoryReference(addressFile);

                    BlobContainerClient ller = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=almacenamientonuevo;AccountKey=B/4L/IpddbsmiZoY3EvwF2ieWUmAZ2p0d3P2mqShKe5A7rg8/YBKhd+KGxFRlbacHOb4IoQmVPn1nD3seeXQZQ==;EndpointSuffix=core.windows.net", "80011018");
                    var BlocCon = ller.GetBlobs().Where(x => x.Name.Contains(".png"));
                    List<string> encontrados = new List<string>();
                    foreach (var b in BlocCon)
                    {
                        if (b.Name.Contains("prueba"))
                            encontrados.Add(b.Name);
                    }
                    //BlocCon.Wait();
                    //var st = r.Status;


                    //IEnumerable<IListBlobItem> blobs = directory.GetBlob ListBlobs().Where(x => x.Uri.AbsolutePath.Contains(".tif"));

                    if (blockBlobSource.ExistsAsync().Result)
                    {
                        var re = blockBlobSource.DeleteAsync();
                        re.Wait();
                        while (re.IsCompleted == false)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lock (_lockObject)
                    {
                        using (StreamWriter writer = new StreamWriter(log, true))
                        {
                            writer.WriteLine("Se produjo un error en el mensaje");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lock (_lockObject)
                {
                    using (StreamWriter writer = new StreamWriter(log, true))
                    {
                        writer.WriteLine("Se produjo un error " + ex);
                    }
                }
            }
        }
    }

    public class objeto
    {
        public string blob{ get; set; }
        public string file{ get; set;   }
    }
    public class BlobMundialDAO
    {
        public string blobName { get; set; }
        public string fileName { get; set; }
    }
}
