using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class Service
    {
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "int(11)")]
        public int Type { get; set; }
        [Column(TypeName = "int(11)")]
        public int PartnerId { get; set; }

        [ForeignKey("PartnerId")]
        [InverseProperty("Service")]
        public Partner Partner { get; set; }
        [ForeignKey("Type")]
        [InverseProperty("Service")]
        public ServiceType TypeNavigation { get; set; }
    }
}
