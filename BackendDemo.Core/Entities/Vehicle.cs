using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.Entities;

public class Vehicle : BaseEntity
{
    [StringLength(60)]
    public string PlateNo { get; set; }
    public int VehicleTypeID { get; set; }
    public int UserID { get; set; }


    public virtual VehicleType VehicleType { get; set; }
    public virtual User User { get; set; }
}
