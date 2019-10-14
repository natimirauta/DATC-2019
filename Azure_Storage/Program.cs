using System;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace Azure_Storage
{
    class Program
    {

        public static string cloud_storage_name = "datcdemoluni";
        public static string cloud_storage_key = "Xf0DheNxYHU8BAyOV0snfLt3Y8R9kO7TADAvhLHi31f8LQdU04q3BTGrUKQVIV6BzvwHPYEPSfd4aElDhHxYhQ==";

        static public async Task CreatePeopleTableAsync(CloudTable peopleTable)
        {
            // Create the CloudTable if it does not exist
            await peopleTable.CreateIfNotExistsAsync();
        }

        static async Task initialize(){

            CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
            cloud_storage_name, cloud_storage_key), true);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable peopleTable = tableClient.GetTableReference("StudentiNAM");

            await CreatePeopleTableAsync(peopleTable);

        }

        static void Main(string[] args)
        {
            Task.Run( async () => await initialize()).GetAwaiter().GetResult();
        }
    }
}
