using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class ClientSession
    {
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column(TypeName = "int(11)")]
        public int ClientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        [Required]
        [Column("LoginIP")]
        [StringLength(50)]
        public string LoginIp { get; set; }
        [StringLength(128)]
        public string Token { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("ClientSession")]
        public Client Client { get; set; }
    }
}
