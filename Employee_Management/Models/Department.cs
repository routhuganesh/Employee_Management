﻿using System.Text.Json.Serialization;

namespace Employee_Management.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [JsonIgnore]
        public virtual List<Employee> Employee { get; set; }
    }
}
