namespace BackendDemo.Core.Entities;

public class MaintenanceHistory : BaseEntity
{
    public int MaintenanceID { get; set; }
    public int ActionTypeID { get; set; }
    public string text { get; set; }


    public virtual Maintenance Maintenance { get; set; }
    public virtual ActionType ActionType { get; set; }
}
