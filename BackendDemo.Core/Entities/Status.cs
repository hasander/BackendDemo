using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.Entities;

public class Status : BaseEntity
{
    [StringLength(255)]
    public string Name { get; set; }
}
