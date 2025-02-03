﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Activities")]
public class Activity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
}