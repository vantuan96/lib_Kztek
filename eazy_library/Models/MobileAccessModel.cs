using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace eazy_library.Models
{
    public class MobileAccessModel
    {
        public TimeAttendance CheckIn { get; set; } //Chấm công

        public WorkSummary Work { get; set; } //Công việc

        public TimeAttendance Overtime { get; set; } //Làm thêm giờ
    }

    public class TimeAttendance
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public string DateCheckIn { get; set; }

        public string DateCheckOut { get; set; }

        public string EventCode { get; set; }

        public DateTime DateTimeCheckIn { get; set; }

        public DateTime DateTimeCheckOut { get; set; }
    }

    public class WorkSummary
    {
        public int ToDo { get; set; }

        public int Doing { get; set; }
    }

    public class TimeCheckIn
    {
        public string Id { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Latitude { get; set; } = "";

        public string Longitude { get; set; } = "";

        //public IFormFile ImagePath { get; set; }

        public string Type { get; set; } = "5";//Mobile

        public string Note { get; set; } = "";

        public string DateTimeIn { get; set; } = "";

        public string DateTimeOut { get; set; } = "";
    }

    public class TaskStage
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }
    }

    public class TaskData
    {
        public string ProjectId { get; set; }

        public List<ProjectList> Projects { get; set; }

        public List<TaskList> Tasks { get; set; }
    }

    public class TaskList
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string DateEnd { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string AccountId { get; set; }

        public string StageId { get; set; }

        public string PercentCompleted { get; set; }
    }

    public class ProjectList
    {
        public string Id { get; set; }

        public string Title { get; set; }
    }

    public class TaskDetail
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public string ProjectName { get; set; }

        public List<TaskComponent> Components { get; set; }

        public string StageId { get; set; }

        public string ProjectId { get; set; }

        public string AccountId { get; set; }

        public int SortOrder { get; set; }
    }

    public class TaskComponent
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string TaskId { get; set; }

        public int SortOrder { get; set; }

        public string AccountId { get; set; }
    }

    public class TaskSub
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsComplete { get; set; }

        public string TaskId { get; set; }

        public string ComponentId { get; set; }

        public int SortOrder { get; set; }

        public string AccountId { get; set; }
    }
}
