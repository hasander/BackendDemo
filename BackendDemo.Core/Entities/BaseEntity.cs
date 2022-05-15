using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDemo.Core.Entities;

public class BaseEntity
{
    [Key]
    public int ID { get; set; }

    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime ModifyDate { get; set; }
    public int? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey("ModifiedBy")]
    public virtual User ModifiedByUser { get; set; }
    [ForeignKey("CreatedBy")]
    public virtual User CreatedByUser { get; set; }

}
