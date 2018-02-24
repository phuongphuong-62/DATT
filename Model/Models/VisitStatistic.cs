
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Model.Models
{
    [Table("VisitStatistics")]
    public class VisitStatistic
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime VisitedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string IDAddress { get; set; }
    }
}
