namespace BasicClicker.API.APICore.Interfaces
{
    /// <summary>
    /// A <see cref="IModType"/> with an <c>internal name</c>.
    /// </summary>
    public interface INamedModType : IModType
    {
        /// <summary>
        /// The internal name of a type's instance.
        /// </summary>
        public string Name { get; }
    }
}