namespace BackendDemo.Core.DTOs;

public class MaintenanceHistoryDTO : BaseDTO
{
    public int MaintenanceID { get; set; }
    public int ActionTypeID { get; set; }
    public string text { get; set; }


    public virtual MaintenanceDTO Maintenance { get; set; }
    public virtual ActionTypeDTO ActionType { get; set; }
}
