using System.ComponentModel.DataAnnotations;

namespace apilab1.validation
{
    public class PastDate:ValidationAttribute
    {
        public override bool IsValid(object? value)
        => value is DateTime date && date < DateTime.Now;
           
    }
}
