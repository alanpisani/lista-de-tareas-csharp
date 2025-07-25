﻿using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public int? CategoryId { get; set; }

    public int? UserId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
