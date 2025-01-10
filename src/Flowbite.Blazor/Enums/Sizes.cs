namespace Flowbite.Blazor.Enums
{
    /// <summary>
    /// Specifies the predefined size options for components in the Flowbite Blazor library.
    /// </summary>
    /// <remarks>
    /// The <c>Sizes</c> enum defines a set of standard size values that can be used to control 
    /// the size of various components throughout the library. These sizes can be applied to 
    /// elements such as buttons, avatars, and other UI components.
    /// </remarks>
    public enum Sizes
    {
        /// <summary>
        /// No size specified. This value is typically used as a default or when size is not applicable.
        /// </summary>
        None = 0,

        /// <summary>
        /// Extra small size. Suitable for compact components.
        /// </summary>
        ExtraSmall = 1,

        /// <summary>
        /// Small size. A slightly larger size than extra small, suitable for smaller UI elements.
        /// </summary>
        Small = 2,

        /// <summary>
        /// Medium size. This is the default size for most components, providing a balanced appearance.
        /// </summary>
        Medium = 3,

        /// <summary>
        /// Large size. Used for larger components that need more emphasis or space.
        /// </summary>
        Large = 4,

        /// <summary>
        /// Extra large size. Suitable for prominent components that require the most space.
        /// </summary>
        ExtraLarge = 5,
    }
}
