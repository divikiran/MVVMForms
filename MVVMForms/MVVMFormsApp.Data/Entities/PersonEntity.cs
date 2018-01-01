using System;
using System.ComponentModel.DataAnnotations;

namespace MVVMFormsApp.Data.Entities
{
    public class PersonEntity : IEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
    }
}
