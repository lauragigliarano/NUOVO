using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUOVO.Models
{
    public class CommessaStackholder
    {
        [ForeignKey("Commessa")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Commessa")]
        [Required]
        public int CommessaID { get; set; }

        [ForeignKey("Stackholder")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Stackholder")]
        [Required]
        public int StackholderID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero Rilevamento")]
        [Range(1, 9999)]
        [Required]
        public int NumeroRilevamentoID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Rilevamento")]
        public DateTime DataRilevamento { get; set; }

        [Range(1, 5)]
        public int Interesse { get; set; }


        [Range(1, 5)]
        public int Potere { get; set; }


        [Range(1, 5)]
        public int Impatto { get; set; }

        public string Note { get; set; }

        public Commessa Commessa { get; set; }
        public Stackholder Stackholder { get; set; }
    }
}