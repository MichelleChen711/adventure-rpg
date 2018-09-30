using System;
namespace CodeHelpers {
    public static class Guard {
        /// <summary>
        /// Ensures that the specified argument is not null.
        //[DebuggerStepThrough]
        //[ContractAnnotation("halt <= argument:null")]
        public static void ArgumentNotNull(object argument, string argumentName) {
            if (argument == null) {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
