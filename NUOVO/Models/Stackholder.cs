using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUOVO.Models
{
    public class Stackholder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, 9999)]
        public int StackholderID { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Cognome { get; set; }

        [StringLength(10)]
        [Phone]
        //[RegularExpression(@"^[0-9""'\s-]*$")]
        public string Telefono { get; set; }

        [StringLength(10)]
        [Phone]
        public string Cellulare { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Mail { get; set; }

        public string Note { get; set; }

        public virtual ICollection<CommessaStackholder> CommessaStackholders { get; set; }
    }
}