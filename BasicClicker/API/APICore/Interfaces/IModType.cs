using BasicClicker.Core.Interfaces;

namespace BasicClicker.API.APICore.Interfaces
{
    public interface IModType : ILoadable
    {
        /// <summary>
        /// The <see cref="APICore.Mod"/> this type belongs to.
        /// </summary>
        public Mod Mod { get; }
    }
}