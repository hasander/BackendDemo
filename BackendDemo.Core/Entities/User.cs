﻿using System.ComponentModel.DataAnnotations;

namespace BackendDemo.Core.Entities;

public class User : BaseEntity
{
    [StringLength(255)]
    public string FirstName { get; set; }
    [StringLength(255)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string PhoneNumber { get; set; }
    [StringLength(255)]
    public string Adress { get; set; }
    public string profilePicture { get; set; }
}
