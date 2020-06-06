using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Base.Static.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ObjectInContainterAttribute : ValidationAttribute
    {
        public object[] Container { get; set; }
        public bool AllowBlank { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!AllowBlank && value == null) return ValidationResult.Success;
            var attributeValue = value.ToString();
            if (!Container.Contains(attributeValue))
                return new ValidationResult(GetErrorMessage(validationContext),
                    new List<string> {validationContext.MemberName});
            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ErrorMessage;

            // Use generic message: i.e. The field {0} is invalid
            //return this.FormatErrorMessage(validationContext.DisplayName);

            // Custom message
            return string.Format("{0} phải nhận một trong các giá trị ({1})", validationContext.DisplayName,
                string.Join(",", Container));
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NumberInContainterAttribute : ValidationAttribute
    {
        public double[] Container { get; set; }
        public bool AllowBlank { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!AllowBlank && value == null) return ValidationResult.Success;
            var attributeValue = double.Parse(value.ToString());
            if (!Container.Contains(attributeValue))
                return new ValidationResult(GetErrorMessage(validationContext),
                    new List<string> {validationContext.MemberName});
            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ErrorMessage;

            // Use generic message: i.e. The field {0} is invalid
            //return this.FormatErrorMessage(validationContext.DisplayName);

            // Custom message
            return string.Format("{0} must be in ({1})", validationContext.DisplayName, string.Join(",", Container));
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SizeAttribute : ValidationAttribute
    {
        public bool AllowBlank { get; set; }
        public int Min { get; set; }

        public int Max { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsList = (IList) value;
            if (valueAsList == null || valueAsList.Count == 0)
                return new ValidationResult(validationContext.MemberName + " might not be blank",
                    new List<string> {validationContext.MemberName});
            if (Min >= 0 && valueAsList.Count < Min)
                return new ValidationResult(
                    validationContext.MemberName + ".Count might be greats than or equals to " + Min,
                    new List<string> {validationContext.MemberName});
            if (Max >= 0 && valueAsList.Count > Max)
                return new ValidationResult(
                    validationContext.MemberName + ".Count might be less than or equals to " + Max,
                    new List<string> {validationContext.MemberName});
            return ValidationResult.Success;
        }
    }
}