using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class Partner
    {
        public Partner()
        {
            Service = new HashSet<Service>();
        }

        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Partner")]
        public ICollection<Service> Service { get; set; }
    }
}
