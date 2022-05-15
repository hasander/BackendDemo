using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.Entities;

public class Maintenance : BaseEntity
{
    public int VehicleID { get; set; }

    public int UserID { get; set; }
    public string Description { get; set; }
    public int PictureGroupID { get; set; }
    public DateTime ExpectedTimeToFix { get; set; }
    public int ResponsibleUserID { get; set; }
    [StringLength(20)]
    public string LocationLongitude { get; set; }
    [StringLength(20)]
    public string LocationLatitude { get; set; }
    public int StatusID { get; set; }


    public virtual List<MaintenanceHistory> MaintenanceHistories { get; set; }
    public virtual Status Status { get; set; }
    public virtual PictureGroup PictureGroup { get; set; }
    public virtual User User { get; set; }
    public virtual User ResponsibleUser { get; set; }
    public virtual Vehicle Vehicle { get; set; }
}
