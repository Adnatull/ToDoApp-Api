﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Application.Features.Tasks.Queries.GetAllIncompleteTasks
{
    public class GetIncompleteTasksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
