
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

public class StudentEntity{

}

public class CustomerEntity : TableEntity
{
    public CustomerEntity(string unis, string cnp)
    {
        this.PartitionKey = unis;
        this.RowKey = cnp;
    }
    public CustomerEntity() { }
    public string Name { get; set; }
    public string CNP { get; set; }
}
