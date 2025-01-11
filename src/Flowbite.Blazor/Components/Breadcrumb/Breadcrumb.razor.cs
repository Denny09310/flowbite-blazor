using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Show the location of the current page in a hierarchical structure
/// using the Tailwind CSS breadcrumb components
/// </summary>
/// <remarks>
/// The breadcrumb component is an important part of any website or application
/// that can be used to show the current location of a page in a hierarchical structure of pages. <br />
/// <br />
/// Flowbite includes two styles of breadcrumb elements, one that has a
/// transparent background and a few more that come with a background in different colors. <br />
/// </remarks>
public partial class Breadcrumb : FlowbiteComponentBase
{
    public IList<BreadcrumbItem> Items { get; private set; } = [];

    private string? RenderedBorderClass => new CssBuilder("border")
                    .AddClass(SelectBorderVariant())
        .Build();

    private string? RenderedClass => new CssBuilder("flex")
        .AddClass(RenderFillClass, Filled)
        .AddClass(Class)
        .Build();

    private string? RenderFillClass => new CssBuilder("px-5 py-3 rounded-lg")
        .AddClass(RenderedBorderClass)
        .AddClass(SelectVariant())
        .Build();

    #region Parameters

    /// <summary>
    /// Gets or sets the background color of the breadcrumb component.
    /// </summary>
    [Parameter]
    public Colors Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the breadcrumb should have a filled background.
    /// </summary>
    [Parameter]
    public bool Filled { get; set; }

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the content to be rendered inside the breadcrumb.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion Fragments

    private string? SelectBorderVariant() => Color switch
    {
        Colors.Gray => "border-gray-500 dark:border-gray-700",
        Colors.Red => "border-red-500 dark:border-red-700",
        Colors.Yellow => "border-yellow-500 dark:border-yellow-700",
        Colors.Green => "border-green-500 dark:border-green-700",
        Colors.Blue => "border-blue-500 dark:border-blue-700",
        Colors.Indigo => "border-indigo-500 dark:border-indigo-700",
        Colors.Purple => "border-purple-500 dark:border-purple-700",
        Colors.Pink => "border-pink-500 dark:border-pink-700",
        _ => throw new NotImplementedException(),
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