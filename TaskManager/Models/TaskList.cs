namespace TaskManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskList")]
    public partial class TaskList
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Mark { get; set; }

        public DateTime Dt { get; set; }
    }
}
