using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Icons;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Use Tailwind CSS badges as elements to show counts or labels separately or inside other components
/// </summary>
/// <remarks>
/// The badge component can be used to complement other elements such as buttons or text elements as a label or to show the count of a given data,
/// such as the number of comments for an article or how much time has passed by since a comment has been made.<br />
/// <br />
/// Alternatively, badges can also be used as standalone elements that link to a certain page by using the anchor tag instead of a span element.
/// </remarks>
public partial class Badge : FlowbiteComponentBase
{
    public Badge() => Id ??= $"badge-{Identifier.NewId()}";

    private string? RenderedBorderClass => new CssBuilder("border")
       .AddClass(SelectBorderVariant())
       .Build();

    private string? RenderedClass => new CssBuilder("font-medium px-2.5 py-0.5")
        .AddClass(RenderedBorderClass, Bordered)
        .AddClass(Class)
        .AddClass(SelectVariant())
        .AddClass(SelectSizeVariant())
        .AddClass(SelectRoundedVariant())
        .Build();

    private string? RenderedCloseClass => new CssBuilder("inline-flex items-center p-1 ms-2 bg-transparent rounded-sm")
        .AddClass(SelecteCloseVariant())
        .Build();

    private RenderFragment Tag => builder =>
    {
        var tagName = !string.IsNullOrWhiteSpace(Href) ? "a" : "span";

        builder.OpenElement(0, tagName);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "id", Id);
        builder.AddAttribute(3, "class", RenderedClass);
        builder.AddAttribute(4, "style", Style);

        if (!string.IsNullOrWhiteSpace(Href))
        {
            builder.AddAttribute(5, "href", Href);
        }

        if (!string.IsNullOrWhiteSpace(Text))
        {
            builder.AddContent(6, Text);
        }
        else
        {
            builder.AddContent(7, ChildContent);
        }

        if (Dismissable)
        {
            builder.OpenElement(0, "button");
            builder.AddAttribute(1, "type", "button");
            builder.AddAttribute(2, "class", RenderedCloseClass);
            builder.AddAttribute(3, "aria-label", "Close");
            builder.AddAttribute(4, "data-dismiss-target", $"#{Id}");

            builder.OpenElement(5, "span");
            builder.AddAttribute(6, "class", "sr-only");
            builder.AddContent(7, "Close");
            builder.CloseElement();

            builder.OpenComponent<Close>(8);
            builder.AddComponentParameter(9, nameof(Size), Sizes.ExtraSmall);
            builder.CloseComponent();

            builder.CloseElement();
        }

        builder.CloseElement();
    };

    #region Parameters

    /// <summary>
    /// Gets or sets a value indicating whether the component should have a border.
    /// </summary>
    [Parameter]
    public bool Bordered { get; set; }

    /// <summary>
    /// Gets or sets the color of the component.
    /// </summary>
    [Parameter]
    public Colors Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the alert is dismissable.
    /// </summary>
    [Parameter]
    public bool Dismissable { get; set; }

    /// <summary>
    /// Gets or sets the hyperlink reference (URL) for the component.
    /// </summary>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the component should have rounded corners.
    /// </summary>
    [Parameter]
    public bool Rounded { get; set; }

    /// <summary>
    /// Gets or sets the size of the component.
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }

    /// <summary>
    /// Gets or sets the text to display within the component.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the content to render inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion Fragments

    private string? SelectBorderVariant() => Color switch
    {
        Colors.Gray => "border-gray-500",
        Colors.Red => "border-red-500",
        Colors.Yellow => "border-yellow-500",
        Colors.Green => "border-green-500",
        Colors.Blue => "border-blue-500",
        Colors.Indigo => "border-indigo-500",
        Colors.Purple => "border-purple-500",
        Colors.Pink => "border-pink-500",
        _ => throw new NotImplementedException(),
    };

    private string? SelecteCloseVariant() => Color switch
    {
        Colors.Gray => "text-gray-700 dark:text-gray-800",
        Colors.Red => "text-red-700 dark:text-red-800",
        Colors.Yellow => "text-yellow-700 dark:text-yellow-800",
        Colors.Green => "text-green-700 dark:text-green-800",
        Colors.Blue => "text-blue-700 dark:text-blue-800",
        Colors.Indigo => "text-indigo-700 dark:text-indigo-800",
        Colors.Purple => "text-purple-700 dark:text-purple-800",
        Colors.Pink => "text-pink-700 dark:text-pink-800",
        _ => throw new NotImplementedException(),
    };

    private string? SelectRoundedVariant() => Rounded ? "rounded-full" : "rounded";

    private string? SelectSizeVariant() => Size switch
    {
        Sizes.Small => "text-sm",
        Sizes.Medium => "text-md",
        Sizes.Large => "text-lg",
        Sizes.ExtraLarge => "text-xl",
        Sizes.None or Sizes.ExtraSmall or _ => "text-xs",
    };

    private string? SelectVariant() => Color switch
    {
        Colors.Gray => "bg-gray-100 text-gray-800 dark:bg-gray-900 dark:text-gray-300",
        Colors.Red => "bg-red-100 text-red-800 dark:bg-red-900 dark:text-red-300",
        Colors.Yellow => "bg-yellow-100 text-yellow-800 dark:bg-yellow-900 dark:text-yellow-300",
        Colors.Green => "bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300",
        Colors.Blue => "bg-blue-100 text-blue-800 dark:bg-blue-900 dark:text-blue-300",
        Colors.Indigo => "bg-indigo-100 text-indigo-800 dark:bg-indigo-900 dark:text-indigo-300",
        Colors.Purple => "bg-purple-100 text-purple-800 dark:bg-purple-900 dark:text-purple-300",
        Colors.Pink => "bg-pink-100 text-pink-800 dark:bg-pink-900 dark:text-pink-300",
        _ => throw new NotImplementedException()
    };
}