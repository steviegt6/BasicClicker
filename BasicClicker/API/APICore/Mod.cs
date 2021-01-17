using BasicClicker.Core.Interfaces;
using log4net;
using System;
using System.Reflection;

namespace BasicClicker.API.APICore
{
    /// <summary>
    /// Every mod relies on an instance of this class. <br />
    /// It contains basic info about your mod, along with basic loading/initialization hooks.
    /// </summary>
    public abstract class Mod : ILoadable
    {
        /// <summary>
        /// A <see cref="Mod"/>'s display name. <br />
        /// This is what users will see your <see cref="Mod"/>'s name displayed as.
        /// </summary>
        public abstract string DisplayName { get; }

        /// <summary>
        /// A <see cref="Mod"/>'s version.
        /// </summary>
        public abstract Version ModVersion { get; }

        /// <summary>
        /// A <see cref="Mod"/>'s code.
        /// </summary>
        public Assembly Assembly { get; internal set; }

        /// <summary>
        /// Logger from <c>log4net</c>. Allows you to log with your own <see cref="Mod"/>'s name.
        /// </summary>
        public ILog Logger { get; internal set; }

        /// <summary>
        /// Hook called after <see cref="Autoload"/>ing is complete and before content is set up. <br />
        /// This hook also serves the purpose of "<c>pre-<see cref="SetupContent"/></c>".
        /// </summary>
        public virtual void Load() { }

        /// <summary>
        /// Hook called during a <see cref="Mod"/>'s unloading process. <br />
        /// </summary>
        public virtual void Unload() { }

        /// <summary>
        /// Hook called after <see cref="SetupContent"/>. Use this when you need to load anything that relies on content to already be set up.
        /// </summary>
        public virtual void PostSetupContent() { }

        internal void Autoload()
        {
        }

        internal void SetupContent()
        {
        }
    }
}