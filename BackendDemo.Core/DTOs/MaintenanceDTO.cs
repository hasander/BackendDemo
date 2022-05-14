using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.DTOs;

public class MaintenanceDTO : BaseDTO
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


    public virtual List<MaintenanceHistoryDTO> MaintenanceHistories { get; set; }
    public virtual StatusDTO Status { get; set; }
    public virtual PictureGroupDTO PictureGroup { get; set; }
    public virtual UserDTO User { get; set; }
    public virtual UserDTO ResponsibleUser { get; set; }
    public virtual VehicleDTO Vehicle { get; set; }
}
