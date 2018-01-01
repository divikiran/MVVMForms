using System.ComponentModel.DataAnnotations;

namespace MVVMFormsApp.Data.Entities
{
    public interface IEntity
    {
        [Key]
        string Id
        {
            get;
            set;
        }
    }
}
