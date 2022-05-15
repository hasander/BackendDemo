using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.Entities;

public class ActionType : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; }
}
