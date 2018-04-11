using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class Client
    {
        public Client()
        {
            ClientSession = new HashSet<ClientSession>();
        }

        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(45)]
        public string LastName { get; set; }
        [StringLength(45)]
        public string Email { get; set; }
        [StringLength(18)]
        public string Phone { get; set; }

        [InverseProperty("Client")]
        public ICollection<ClientSession> ClientSession { get; set; }
    }
}
