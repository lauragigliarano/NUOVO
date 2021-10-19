using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NUOVO.Models
{
    public class CommessaRischio
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Progressivo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Commessa")]
        [Required]
        public int CommessaID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string NomeRischio { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Rilevamento")]
        public DateTime DataRilevamento { get; set; }

        [DateGreaterThan("DataRilevamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Aggiornamento")]
        public DateTime? DataAggiornamento { get; set; }

        [Range(1, 5)]
        public int Voto { get; set; }

        [Range(1, 5)]
        public int Priorita { get; set; }

        [DataType(DataType.Text)]
        public float Importo { get; set; }

        public string Probabilita { get; set; }
        public string Impatto { get; set; }
        public string Strategia { get; set; }

        public Commessa Commessa { get; set; }

    }
}