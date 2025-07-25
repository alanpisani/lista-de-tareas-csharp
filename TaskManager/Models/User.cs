using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    public User() { }

    public User(string username, string email, string password) {
        Id = 0;
        Username = username;
        Email = email;
        Password = password;
        TaskItems = new List<TaskItem>();
    }
}
