using Azure.Storage.Blobs;
using IQCleanRepositoryDAO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL.Service
{
    public class StorageHandlerService
    {
        public static string StorageAccountName { get; set; }
        public static string StorageAccountKey { get; set; }
        private static CloudStorageAccount storageAccount;
        private static object _lockObject = new object();

        public StorageHandlerService()
        {
            new StorageHandlerService();
        }

        public string DeleteBlobItem(string blob, string fileName, string directory)
        {
            StorageAccountName = ConfigurationManager.AppSettings["StorageAccountName"];
            StorageAccountKey = ConfigurationManager.AppSettings["StorageAccountKey"];
            storageAccount = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey), true);

            try
            {
                string addressFile = Path.Combine(directory, "").Replace("\\", "/");
                CloudBlobClient blobClientSource = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainerSource = blobClientSource.GetContainerReference(Path.Combine(blob, addressFile));
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

        public List<BlobMundialDAO> ListBlob(string container) 
        {
            List<BlobMundialDAO> blobFile = new List<BlobMundialDAO>();
            try
            {
                string StorageAccountName = ConfigurationManager.AppSettings["StorageConnectionString"];
                BlobContainerClient containerClient = new BlobContainerClient(StorageAccountName, container);
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
            catch (Exception)
            {
                return null;
            }
            
        }


    }
}
