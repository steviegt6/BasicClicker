using BasicClicker.API.APICore.Exceptions;
using BasicClicker.Core;
using BasicClicker.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BasicClicker.API.APICore
{
    public static class ModLoader
    {
        /// <summary>
        /// A read-only collection of loaded <see cref="Mod"/>s.
        /// </summary>
        public static ReadOnlyCollection<Mod> Mods => mods.AsReadOnly();

        /// <summary>
        /// The directory to the <c>Mods</c> folder that is currently in use.
        /// </summary>
        public static string ModsPath => Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Mods";

#pragma warning disable IDE0044 // Add readonly modifier
        private static List<Mod> mods = new List<Mod>();
#pragma warning restore IDE0044 // Add readonly modifier

        // Finds a list of paths to load mods.
        private static List<string> FindMods()
        {
            Logging.Logger.Info("Finding mods");

            List<string> foundMods = new List<string>()
            {
                "BasicClicker"
            };

            Directory.CreateDirectory(ModsPath);

            foreach (string file in Directory.GetFiles(ModsPath, "*.dll"))
                foundMods.Add(file);

            Logging.Logger.Info($"Mods found:");

            foreach (string mod in foundMods)
                Logging.Logger.Info(mod);

            return foundMods;
        }

        // Loads all mods in the mods list.
        internal static void LoadMods()
        {
            List<string> mods = FindMods();
            List<Assembly> loadedMods = new List<Assembly>();

            foreach (string mod in mods)
            {
                if (mod == "BasicClicker")
                    loadedMods.Add(typeof(BCGame).Assembly);
                else if (AssemblyMethods.TryLoadFile(mod, out Assembly assembly))
                    loadedMods.Add(assembly);
            }

            foreach (Assembly loadedMod in loadedMods)
                LoadTypes(loadedMod);
        }

        private static void LoadTypes(Assembly loadingMod)
        {
            bool foundModClass = false;

            foreach (Type type in loadingMod.GetTypes().Where(x => x.IsSubclassOf(typeof(Mod))))
            {
                if (type.IsAbstract || type.GetConstructor(new Type[] { }) == null)
                    continue; // Don't load any abstract types or types without a parameter-less ctor.

                if (foundModClass)
                    throw new MultipleModClassException(loadingMod);

                Mod mod = Activator.CreateInstance(type) as Mod;
                mod.Assembly = loadingMod;
                mods.Add(mod);
            }

            foreach (Type type in loadingMod.GetTypes().Where(x => !x.IsSubclassOf(typeof(Mod))))
            {
                if (type.IsAbstract || type.GetConstructor(new Type[] { }) == null)
                    continue;

                // TODO: Add methods for loading modded content.
                // This will come later.
            }
        }
    }
}