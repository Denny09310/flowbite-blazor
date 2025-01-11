using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

// TODO: Create the tooltip element to add to this

/// <summary>
/// Use the avatar component to show a visual representation of a user profile
/// using an image element or SVG object based on multiple styles and sizes
/// </summary>
/// <remarks>
/// The avatar component can be used as a visual identifier for a user profile on your website
/// and you can use the examples from Flowbite to modify the styles and sizes of these components
/// using the utility classes from Tailwind CSS.
/// </remarks>
public partial class Avatar
{
    private string? ContainerRenderedClass => new CssBuilder()
        .AddClass("flex items-center gap-4", HasTextFragment)
        .Build();

    private bool HasInitials => !string.IsNullOrWhiteSpace(Initials);
    private bool HasPlaceholder => Placeholder != null;
    private bool HasTextFragment => Text != null || ChildContent != null;

    private string? IndicatorRenderedClass => new CssBuilder("absolute w-3.5 h-3.5 bg-green-400 border-2 border-white dark:border-gray-800 rounded-full")
        .AddClass(SelectAnchorVariant())
        .Build();

    private string? RenderedClass => new CssBuilder()
        .AddClass("ring-2 ring-gray-300 dark:ring-gray-500", Bordered)
        .AddClass("relative overflow-hidden bg-gray-100 dark:bg-gray-600", HasPlaceholder)
        .AddClass("relative inline-flex items-center justify-center overflow-hidden bg-gray-100 dark:bg-gray-600", HasInitials)
        .AddClass(Rounded ? "rounded-full" : "rounded")
        .AddClass(SelectSize())
        .Build();

    #region Parameters

    /// <summary>
    /// Gets or sets the alternative text for the avatar image.
    /// </summary>
    [Parameter]
    public string? AlternativeText { get; set; }

    /// <summary>
    /// Gets or sets the anchor position for the indicator.
    /// </summary>
    [Parameter]
    public Anchors Anchor { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the avatar has a border.
    /// </summary>
    [Parameter]
    public bool Bordered { get; set; }

    /// <summary>
    /// Gets or sets the image source for the avatar.
    /// </summary>
    [Parameter]
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the initials to display as a fallback or alternative content in the avatar.
    /// </summary>
    [Parameter]
    public string? Initials { get; set; }

    /// <summary>
    /// Gets or sets the placeholder content for the avatar.
    /// </summary>
    [Parameter]
    public RenderFragment? Placeholder { get; set; }

    /// <summary>
    // Gets or sets a value indicating whether the avatar is rounded.
    /// </summary>
    [Parameter]
    public bool Rounded { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display an indicator on the avatar.
    /// </summary>
    [Parameter]
    public bool ShowIndicator { get; set; }

    /// <summary>
    /// Gets or sets the size of the avatar.
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the child content to render alongside the avatar.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the text content associated with the avatar.
    /// </summary>
    [Parameter]
    public RenderFragment? Text { get; set; }

    #endregion Fragments

    private string SelectAnchorVariant() => Anchor switch
    {
        Anchors.BottomRight => "bottom-0 right-7",
        Anchors.TopLeft => "top-0 left-7",
        Anchors.BottomLeft => "bottom-0 left-7",
        Anchors.TopRight or _ => "top-0 right-7",
    };

    private string SelectSize() => Size switch
    {
        Sizes.ExtraSmall => "w-6 h-6",
        Sizes.Small => "w-8 h-8",
        Sizes.Large => "w-20 h-20",
        Sizes.ExtraLarge => "w-36 h-36",
        _ => "w-10 h-10",
    };
}