using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using RenameFileInBlob.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RenameFileInBlob
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
            RenameFileInBlob();
        }

        public static void RenameFileInBlob()
        {
            try
            {
                StorageAccountName = ConfigurationManager.AppSettings["StorageAccountName"];
                StorageAccountKey = ConfigurationManager.AppSettings["StorageAccountKey"];
                storageAccount = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey), true);
                string FileToRead = ConfigurationManager.AppSettings["DirectoryFile"];
                var msg = string.Empty;
                IEnumerable<string> line = File.ReadLines(FileToRead);
                try
                {
                    foreach (var item in line)
                    {
                        msg = item;
                        //var nit = item.Split('-')[2];
                        string containerSource = "800110181";//nit.Substring(0, 9);
                        string fileExists = "prueba.png";//item + "_0.tif";
                        string addressFile = Path.Combine("prw", "").Replace("\\", "/");
                        CloudBlobClient blobClientSource = storageAccount.CreateCloudBlobClient();
                        CloudBlobContainer blobContainerSource = null;
                        CloudBlobContainer blobContainerSourceDirectory = null;
                        CloudBlobDirectory directory = null;
                        CloudBlockBlob blockBlobSource = null;
                        CloudBlockBlob blockBlobTarget = null;

                        blobContainerSourceDirectory = blobClientSource.GetContainerReference(containerSource);
                        directory = blobContainerSourceDirectory.GetDirectoryReference(addressFile);
                        blobContainerSource = blobClientSource.GetContainerReference(Path.Combine(containerSource, addressFile));
                        blockBlobSource = blobContainerSource.GetBlockBlobReference(fileExists);

                        if (blockBlobSource.Exists())
                        {
                            
                            IEnumerable<IListBlobItem> blobs = directory.ListBlobs().Where(x => x.Uri.AbsolutePath.Contains(".png"));
                            int count = blobs.Count();
                            int flag = count;
                            for (int i = 1; i <= count; i++)
                            {
                                string file1 = "prueba.png";// string.Format("{0}_{1}.tif", item, count - i);
                                string file2 = string.Format("{0}_{1}.tif", item, flag);
                                blockBlobSource = blobContainerSource.GetBlockBlobReference(file1);
                                var re = blockBlobSource.DeleteAsync();
                                blockBlobTarget = blobContainerSource.GetBlockBlobReference(file2);
                                blockBlobTarget.StartCopyFromBlob(blockBlobSource);
                                while (blockBlobTarget.CopyState.Status == CopyStatus.Pending)
                                {
                                    Thread.Sleep(1000);
                                }

                                if (blockBlobTarget.CopyState.Status != CopyStatus.Success)
                                    throw new Exception(blockBlobTarget.CopyState.StatusDescription);

                                blockBlobSource.DeleteIfExists();
                                flag--;
                                Audit audit = new Audit();
                                audit.CreateAudit(item.Split('-')[3], file1, file2);
                            }
                            Console.WriteLine(string.Format("el siguiente mensaje fue procesado: {0}", item));
                        }
                    }
                }
                catch (Exception)
                {
                    lock (_lockObject)
                    {
                        using (StreamWriter writer = new StreamWriter(log, true))
                        {
                            writer.WriteLine("Se produjo un error en el mensaje" + msg);
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
}
