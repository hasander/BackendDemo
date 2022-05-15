using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.DTOs;

public class VehicleTypeDTO : BaseDTO
{
    [StringLength(255)]
    public string Name { get; set; }
}
