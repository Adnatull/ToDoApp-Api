using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Entities
{
    public class Task : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Task()
        {
            IsCompleted = false;
        }
    }
}
