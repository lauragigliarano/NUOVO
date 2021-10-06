using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUOVO.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        [Range(1, 9999)]
        public int ClienteID { get; set; }

        [StringLength(50)]
        [Display(Name = "Ragione Sociale")]
        public string RagioneSociale { get; set; }

        [StringLength(10)]
        [Phone]
        public string Telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Mail { get; set; }

        public virtual ICollection<Commessa> Commesse { get; set; }
    }
}