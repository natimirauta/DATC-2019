
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

public class CustomerEntity : TableEntity
{
    public CustomerEntity(string university, string CNP)
    {
        this.PartitionKey = university;
        this.RowKey = CNP;
    }
    public CustomerEntity() { }
    public string Name { get; set; }
    public string CNP { get; set; }
    public string University { get; set; }
    public string Email { get; set; }
    
}
