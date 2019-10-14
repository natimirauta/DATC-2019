using System;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace Azure_Storage
{
    class Program
    {

        // https://docs.microsoft.com/en-us/azure/visual-studio/vs-storage-aspnet5-getting-started-tables?fbclid=IwAR2XP1v1-rR_0O4-KK2Mk1fF_HkPQzhibGYW62WlD_5EPcKl-BIkG7Bi3MI
        // temp data
        public static CloudTable table;
        public static string temp_Name = "Cineva Altcineva";
        public static string temp_CNP = "463178525";
        public static string temp_University = "UPT";
        public static string temp_Email = "student@b624.com";

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

            table = peopleTable;

            await CreatePeopleTableAsync(peopleTable);

        }

        static async Task AddEntity(CloudTable peopleTable, string Name, string CNP, string University, string Email)
        {
            // Create a new customer entity.
            CustomerEntity customer1 = new CustomerEntity(Name, CNP);
            customer1.Name = Name;
            customer1.CNP = CNP;
            customer1.University = University;
            customer1.Email = Email;

            temp_Name = Name;
            temp_CNP = CNP;
            temp_University = University;
            temp_Email = Email;

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(customer1);

            // Execute the insert operation.
            await peopleTable.ExecuteAsync(insertOperation);
        }

        static void Main(string[] args)
        {
            Task.Run( async () => await initialize()).GetAwaiter().GetResult();
            Task.Run( async () => await AddEntity(table, Name:temp_Name, CNP:temp_CNP, University:temp_University, Email:temp_Email)).GetAwaiter().GetResult();
        }
    }
}
