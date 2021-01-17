using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BasicClicker.Core.IO
{
    /// <summary>
    /// An abstract class that allows you to save and load data. <br />
    /// Uses binary reading and writing.
    /// </summary>
    public abstract class SaveFile
    {
        // TODO: Add hooks for PreSave, PostSave, PreLoad, and PostLoad

        /// <summary>
        /// The name of this file.
        /// </summary>
        public abstract string FileName { get; }

        /// <summary>
        /// The save path of your file. Appends to the directory BasicClicker is located in. <br />
        /// This path is appended to the directory BaseClicker is located in. <br />
        /// Defaults to <see cref="Environment.CurrentDirectory"/>. Make sure you keep this if you want it to be in the same directory as other data.
        /// </summary>
        public virtual string SavePath => Environment.CurrentDirectory;

        public BinaryFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// Handles saving, calls <see cref="Save"/>.
        /// </summary>
        public void SaveData()
        {
            if (File.Exists(SavePath + Path.DirectorySeparatorChar + FileName))
                File.Delete(SavePath + Path.DirectorySeparatorChar + FileName);

            using FileStream stream = File.Create(SavePath + Path.DirectorySeparatorChar + FileName);
            Save(stream, formatter);
        }

        /// <summary>
        /// Handles loading, calls <see cref="Load"/>.
        /// </summary>
        public void LoadData()
        {
            if (File.Exists(SavePath + Path.DirectorySeparatorChar + FileName))
                using (FileStream stream = File.OpenRead(SavePath + Path.DirectorySeparatorChar + FileName))
                    Load(stream, formatter);
        }

        /// <summary>
        /// Allows you to choose what data to save and what happens during data saving.
        /// </summary>
        public abstract void Save(FileStream stream, BinaryFormatter formatter);

        /// <summary>
        /// Allows you to load data and what happens during data loading.
        /// </summary>
        public abstract void Load(FileStream stream, BinaryFormatter formatter);
    }
}