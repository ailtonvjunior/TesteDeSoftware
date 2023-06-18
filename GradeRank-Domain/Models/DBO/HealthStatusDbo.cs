using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
    [Table("gr_health")]
    public class HealthStatusDbo
    {
        [Key]
        [Column("id_status")]
        public int Id { get; set; }

        [Column("desc_status")]
        public string? Status { get; set; }
    }
}
