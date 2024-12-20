﻿using SQLite;

namespace MyTasker.Domain.Models
{
    public class ToDo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Description { get; set; }
        public bool Done { get; set; } = false;
        public bool Redeemed { get; set; } = false;

        // FK for 'ToDoList' table
        public int ToDoListId { get; set; }

        public ToDo() { }
    }
}
