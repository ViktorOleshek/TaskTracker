﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Users")]
public class User : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}