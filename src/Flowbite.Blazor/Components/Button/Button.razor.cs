using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

public partial class Button : FlowbiteComponentBase
{
    private bool HasIcon => Icon != null;
    private bool IconAtEnd => HasIcon && IconPosition == Anchors.Right;
    private bool IconAtStart => HasIcon && IconPosition == Anchors.Left;

    private string? RenderedClass => new CssBuilder("font-medium focus:outline-none focus:ring-4")
        .AddClass("inline-flex items-center", HasIcon)
        .AddClass(Class)
        .AddClass(SelectSize())
        .AddClass(SelectVariant())
        .AddClass(Rounded ? "rounded-full" : "rounded-lg")
        .Build();

    #region Parameters

    /// <summary>
    /// Sets the color of the button. Determines the styling based on predefined color schemes.
    /// </summary>
    [Parameter]
    public Colors Color { get; set; }

    /// <summary>
    /// Specifies the position of the icon in the button. Defaults to the left side.
    /// </summary>
    [Parameter]
    public Anchors IconPosition { get; set; } = Anchors.Left;

    /// <summary>
    /// Indicates whether the button is in a loading state.
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// Specifies whether the button should have an outlined style.
    /// </summary>
    [Parameter]
    public bool Outlined { get; set; }

    /// <summary>
    /// Determines whether the button should have rounded corners.
    /// </summary>
    [Parameter]
    public bool Rounded { get; set; }

    /// <summary>
    /// Sets the size of the button, with options such as small, medium, or large.
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Defines the content to be rendered inside the button.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Specifies the icon to be displayed in the button.
    /// </summary>
    [Parameter]
    public RenderFragment? Icon { get; set; }

    /// <summary>
    /// Specifies the loader element to be displayed when the button is in a loading state.
    /// </summary>
    [Parameter]
    public RenderFragment? Loader { get; set; }

    #endregion Fragments

    private string SelectVariant() => Outlined ? SelectOutlinedVariant() : SelectFilledVariant();

    private string SelectFilledVariant() => Color switch
    {
        Colors.Gray => "text-white bg-gray-700 hover:bg-gray-800 focus:ring-gray-300 dark:bg-gray-600 dark:hover:bg-gray-700 dark:focus:ring-gray-800",
        Colors.Red => "text-white bg-red-700 hover:bg-red-800 focus:ring-red-300 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900",
        Colors.Yellow => "text-white bg-yellow-700 hover:bg-yellow-800 focus:ring-yellow-300 dark:bg-yellow-600 dark:hover:bg-yellow-700 dark:focus:ring-yellow-800",
        Colors.Green => "text-white bg-green-700 hover:bg-green-800 focus:ring-green-300 dark:bg-green-600 dark:hover:bg-green-700 dark:focus:ring-green-800",
        Colors.Blue => "text-white bg-blue-700 hover:bg-blue-800 focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800",
        Colors.Indigo => "text-white bg-indigo-700 hover:bg-indigo-800 focus:ring-indigo-300 dark:bg-indigo-600 dark:hover:bg-indigo-700 dark:focus:ring-indigo-800",
        Colors.Purple => "text-white bg-purple-700 hover:bg-purple-800 focus:ring-purple-300 dark:bg-purple-600 dark:hover:bg-purple-700 dark:focus:ring-purple-800",
        Colors.Pink => "text-white bg-pink-700 hover:bg-pink-800 focus:ring-pink-300 dark:bg-pink-600 dark:hover:bg-pink-700 dark:focus:ring-pink-800",
        Colors.Alternative => "text-gray-900 bg-white border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:ring-gray-100 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700",
        Colors.Dark => "text-white bg-gray-800 hover:bg-gray-900 focus:ring-gray-300 dark:bg-gray-800 dark:hover:bg-gray-700 dark:focus:ring-gray-700 dark:border-gray-700",
        Colors.Light => "text-gray-900 bg-white border border-gray-300 hover:bg-gray-100 focus:ring-gray-100 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700",
        _ => throw new NotImplementedException()
    };

    private string SelectOutlinedVariant() => Color switch
    {
        Colors.Gray => "text-gray-700 hover:text-white border border-gray-700 hover:bg-gray-800 focus:ring-gray-300 dark:border-gray-500 dark:text-gray-500 dark:hover:text-white dark:hover:bg-gray-500 dark:focus:ring-gray-800",
        Colors.Red => "text-red-700 hover:text-white border border-red-700 hover:bg-red-800 focus:ring-red-300 dark:border-red-500 dark:text-red-500 dark:hover:text-white dark:hover:bg-red-500 dark:focus:ring-red-800",
        Colors.Yellow => "text-yellow-700 hover:text-white border border-yellow-700 hover:bg-yellow-800 focus:ring-yellow-300 dark:border-yellow-500 dark:text-yellow-500 dark:hover:text-white dark:hover:bg-yellow-500 dark:focus:ring-yellow-800",
        Colors.Green => "text-green-700 hover:text-white border border-green-700 hover:bg-green-800 focus:ring-green-300 dark:border-green-500 dark:text-green-500 dark:hover:text-white dark:hover:bg-green-500 dark:focus:ring-green-800",
        Colors.Blue => "text-blue-700 hover:text-white border border-blue-700 hover:bg-blue-800 focus:ring-blue-300 dark:border-blue-500 dark:text-blue-500 dark:hover:text-white dark:hover:bg-blue-500 dark:focus:ring-blue-800",
        Colors.Indigo => "text-indigo-700 hover:text-white border border-indigo-700 hover:bg-indigo-800 focus:ring-indigo-300 dark:border-indigo-500 dark:text-indigo-500 dark:hover:text-white dark:hover:bg-indigo-500 dark:focus:ring-indigo-800",
        Colors.Purple => "text-purple-700 hover:text-white border border-purple-700 hover:bg-purple-800 focus:ring-purple-300 dark:border-purple-500 dark:text-purple-500 dark:hover:text-white dark:hover:bg-purple-500 dark:focus:ring-purple-800",
        Colors.Pink => "text-pink-700 hover:text-white border border-pink-700 hover:bg-pink-800 focus:ring-pink-300 dark:border-pink-500 dark:text-pink-500 dark:hover:text-white dark:hover:bg-pink-500 dark:focus:ring-pink-800",
        Colors.Dark => "text-gray-900 hover:text-white border border-gray-800 hover:bg-gray-900 focus:ring-gray-300 dark:border-gray-600 dark:text-gray-400 dark:hover:text-white dark:hover:bg-gray-600 dark:focus:ring-gray-800",
        _ => throw new NotImplementedException()
    };

    private string SelectSize() => Size switch
    {
        Sizes.ExtraSmall => "px-3 py-2 text-xs",
        Sizes.Small => "px-3 py-2 text-sm",
        Sizes.Large => "px-5 py-3 text-base",
        Sizes.ExtraLarge => "px-6 py-3.5 text-base",
        _ => "px-5 py-2.5 text-sm",
    };
}
