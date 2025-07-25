using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}
