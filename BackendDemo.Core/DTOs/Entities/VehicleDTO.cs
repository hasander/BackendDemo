using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.DTOs;

public class VehicleDTO : BaseDTO
{
    [StringLength(60)]
    public string PlateNo { get; set; }
    public int VehicleTypeID { get; set; }
    public int UserID { get; set; }


    public virtual VehicleTypeDTO VehicleType { get; set; }
    public virtual UserDTO User { get; set; }
}
