using System;
using System.Collections.Generic;

namespace POS_Business.Validations
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(List<string> errors)
            : base(string.Join(Environment.NewLine, errors))
        {
            Errors = errors;
        }

        public ValidationException(string error)
            : this(new List<string> { error }) { }
    }

}
