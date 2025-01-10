using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Show contextual information to your users using alert elements based on Tailwind CSS.
/// </summary>
/// <remarks>
/// The alert component can be used to provide information to your users such as success or error messages,
/// but also highlighted information complementing the normal flow of paragraphs and headers on a page.
/// Flowbite also includes dismissible alerts which can be hidden by the users by clicking on the close icon.
/// </remarks>
public partial class Alert : FlowbiteComponentBase
{
    public Alert() => Id ??= $"alert-{Identifier.NewId()}";

    private string DataDismissTarget => $"#{Id}";

    private string? RenderedBorderClass => new CssBuilder("border-t-4")
        .AddClass(SelectBorderVariant())
        .Build();

    private string? RenderedClass => new CssBuilder("flex p-4 mb-4 text-sm")
        .AddClass(SelectVariant())
        .AddClass("rounded-lg", Rounded)
        .AddClass(RenderedBorderClass)
        .AddClass(Class)
        .Build();

    private string? RenderedCloseClass => new CssBuilder("ml-auto -mx-1.5 -my-1.5 rounded-lg focus:ring-2 p-1.5 inline-flex items-center justify-center h-8 w-8")
        .AddClass(SelecteCloseVariant())
        .Build();

    #region Parameters

    /// <summary>
    /// Gets or sets a value indicating whether the alert should have a border accent.
    /// </summary>
    [Parameter]
    public bool BorderAccent { get; set; }

    /// <summary>
    /// Gets or sets the color of the alert.
    /// </summary>
    [Parameter]
    public Colors Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the alert is dismissable.
    /// </summary>
    [Parameter]
    public bool Dismissable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the alert should have rounded corners.
    /// </summary>
    [Parameter]
    public bool Rounded { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the alert should show an icon.
    /// </summary>
    [Parameter]
    public bool ShowIcon { get; set; }

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the actions to be rendered inside the alert.
    /// </summary>
    [Parameter]
    public RenderFragment? Actions { get; set; }

    /// <summary>
    /// Gets or sets the child content to be rendered inside the alert.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion Fragments

    #region Events

    /// <summary>
    /// Gets or sets the callback to be invoked when the alert is dismissed.
    /// </summary>
    [Parameter]
    public EventCallback OnDismissed { get; set; }

    #endregion Events

    #region Selectors

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
        Colors.Gray => "text-gray-700 bg-gray-100 dark:bg-gray-200 dark:text-gray-800",
        Colors.Red => "text-red-700 bg-red-100 dark:bg-red-200 dark:text-red-800",
        Colors.Yellow => "text-yellow-700 bg-yellow-100 dark:bg-yellow-200 dark:text-yellow-800",
        Colors.Green => "text-green-700 bg-green-100 dark:bg-green-200 dark:text-green-800",
        Colors.Blue => "text-blue-700 bg-blue-100 dark:bg-blue-200 dark:text-blue-800",
        Colors.Indigo => "text-indigo-700 bg-indigo-100 dark:bg-indigo-200 dark:text-indigo-800",
        Colors.Purple => "text-purple-700 bg-purple-100 dark:bg-purple-200 dark:text-purple-800",
        Colors.Pink => "text-pink-700 bg-pink-100 dark:bg-pink-200 dark:text-pink-800",
        _ => throw new NotImplementedException(),
    };

    private string? SelectVariant() => Color switch
    {
        Colors.Gray => "bg-gray-100 text-gray-500 focus:ring-gray-400 hover:bg-gray-200 dark:bg-gray-200 dark:text-gray-600 dark:hover:bg-gray-300",
        Colors.Red => "bg-red-100 text-red-500 focus:ring-red-400 hover:bg-red-200 dark:bg-red-200 dark:text-red-600 dark:hover:bg-red-300",
        Colors.Yellow => "bg-yellow-100 text-yellow-500 focus:ring-yellow-400 hover:bg-yellow-200 dark:bg-yellow-200 dark:text-yellow-600 dark:hover:bg-yellow-300",
        Colors.Green => "bg-green-100 text-green-500 focus:ring-green-400 hover:bg-green-200 dark:bg-green-200 dark:text-green-600 dark:hover:bg-green-300",
        Colors.Blue => "bg-blue-100 text-blue-500 focus:ring-blue-400 hover:bg-blue-200 dark:bg-blue-200 dark:text-blue-600 dark:hover:bg-blue-300",
        Colors.Indigo => "bg-indigo-100 text-indigo-500 focus:ring-indigo-400 hover:bg-indigo-200 dark:bg-indigo-200 dark:text-indigo-600 dark:hover:bg-indigo-300",
        Colors.Purple => "bg-purple-100 text-purple-500 focus:ring-purple-400 hover:bg-purple-200 dark:bg-purple-200 dark:text-purple-600 dark:hover:bg-purple-300",
        Colors.Pink => "bg-pink-100 text-pink-500 focus:ring-pink-400 hover:bg-pink-200 dark:bg-pink-200 dark:text-pink-600 dark:hover:bg-pink-300",
        _ => throw new NotImplementedException()
    };

    #endregion Selectors
}