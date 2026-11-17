using System;
using System.Collections.Generic;

namespace POS_Business.Validations
{
    public class ValidationResult : Exception
    {
        public List<string> Errors { get; } = new List<string>();
        public bool IsValid => Errors.Count == 0;

        public void Add(string error) => Errors.Add(error);

        public void ThrowIfInvalid()
        {
            if (!IsValid)
                throw new ValidationException(Errors);
        }

    }

}
