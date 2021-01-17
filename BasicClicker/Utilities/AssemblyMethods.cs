using System.Reflection;

namespace BasicClicker.Utilities
{
    public static class AssemblyMethods
    {
        /// <summary>
        /// Returns true if <see cref="Assembly.LoadFile(string)"/> successfully found and loaded an <see cref="Assembly"/>.
        /// </summary>
        public static bool TryLoadFile(string path, out Assembly assembly)
        {
            assembly = Assembly.LoadFile(path);

            return assembly != null;
        }
    }
}