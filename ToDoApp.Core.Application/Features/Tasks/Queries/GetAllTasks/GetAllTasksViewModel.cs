﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
