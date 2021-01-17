using System;
using System.Reflection;

namespace BasicClicker.API.APICore.Exceptions
{
    public class MultipleModClassException : Exception
    {
        public Assembly mod;

        public MultipleModClassException(Assembly mod)
        {
            this.mod = mod;
        }

        public override string Message => $"Error loading mod assembly with a full name of {mod.FullName} due to the fact it has two or more non-abstract types extending the Mod class.";
    }
}