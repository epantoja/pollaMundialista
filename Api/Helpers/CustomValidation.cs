using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Helpers.CustomValidation {

    [AttributeUsage (AttributeTargets.Property)]
    public class MayorCeroAttribute : ValidationAttribute {

        public override bool IsValid (object value) {
            try {
                var number = Convert.ToInt32 (value);
                if (number > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception) {
                return base.IsValid (value);
            }
        }
    }
}