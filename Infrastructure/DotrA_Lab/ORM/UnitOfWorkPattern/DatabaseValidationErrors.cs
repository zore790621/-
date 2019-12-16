using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Runtime.Serialization;

namespace DotrA_Lab.ORM.UnitOfWorkPattern
{
    [Serializable]
    internal class DatabaseValidationErrors : Exception
    {
        private IEnumerable<DbEntityValidationResult> errors;

        public DatabaseValidationErrors()
        {
        }

        public DatabaseValidationErrors(IEnumerable<DbEntityValidationResult> errors)
        {
            this.errors = errors;
        }

        public DatabaseValidationErrors(string message) : base(message)
        {
        }

        public DatabaseValidationErrors(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DatabaseValidationErrors(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}