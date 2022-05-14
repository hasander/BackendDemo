using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.DTOs;

public class StatusDTO : BaseDTO
{
    [StringLength(255)]
    public string Name { get; set; }
}
