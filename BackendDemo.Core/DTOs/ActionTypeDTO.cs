using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.DTOs;

public class ActionTypeDTO : BaseDTO
{
    [StringLength(50)]
    public string Name { get; set; }
}
