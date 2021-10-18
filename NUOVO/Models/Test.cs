using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.Extensions.Logging.Debug;

namespace NUOVO.Models
{
    [AttributeUsage(AttributeTargets.All)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if( value != null)
            {
                DateTime DataFine = (DateTime)value;
                DateTime DataInizio = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);

                 if (DataInizio < DataFine)
                    {
                        return ValidationResult.Success;
                    }
                else
                {
                    Debug.Write("My debug string here");
                    return new ValidationResult("La data fine deve essere successiva alla data inizio!");
                }
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}