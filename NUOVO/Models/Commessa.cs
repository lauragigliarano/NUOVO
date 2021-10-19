using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUOVO.Models
{
    public class Commessa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Commessa")]
        [Range(1, 9999)]
        [Required]
        public int CommessaID { get; set; }

        [StringLength(50)]
        public string Descrizione { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "Cliente ID")]
        public int ClienteID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Inizio")]
        public DateTime DataInizio { get; set; }

        [DateGreaterThan("DataInizio")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Fine")]
        public DateTime? DataFine { get; set; }


        [DataType(DataType.Text)]
        public float Importo { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<CommessaStackholder> CommessaStackholders { get; set; }
        public virtual ICollection<CommessaRischio> CommessaRischio{ get; set; }

    }
}