using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Represents an individual item in a breadcrumb navigation, optionally with a dropdown menu.
/// </summary>
/// <remarks>
/// A breadcrumb item is a part of a breadcrumb navigation trail, which helps users track their location within a website or application.
/// </remarks>
public partial class BreadcrumbItem : FlowbiteComponentBase, IDisposable
{
    private bool _disposed;

    /// <summary>
    /// Determines the HTML tag for the breadcrumb item based on whether it is a link or not.
    /// </summary>
    private string Tag => Href == null ? "span" : "a";

    /// <summary>
    /// Indicates whether this item is the first in the breadcrumb trail.
    /// </summary>
    private bool IsFirst => Breadcrumb.Items.FirstOrDefault() == this;

    /// <summary>
    /// Indicates whether this item is the last in the breadcrumb trail.
    /// </summary>
    private bool IsLast => Breadcrumb.Items.LastOrDefault() == this;

    /// <summary>
    /// Computes the CSS class for the breadcrumb item container.
    /// </summary>
    private string? RenderedClass => new CssBuilder("flex items-center")
        .AddClass(Class)
        .Build();

    /// <summary>
    /// Computes the CSS class for the breadcrumb item content.
    /// </summary>
    private string? RenderedContentClass => new CssBuilder("ms-1 text-sm font-medium md:ms-2")
        .AddClass(SelectContentClass())
        .Build();

    #region Parameters

    /// <summary>
    /// The parent <see cref="Breadcrumb"/> instance that this breadcrumb item belongs to.
    /// This is a cascading parameter provided automatically by the parent <see cref="Breadcrumb"/>.
    /// </summary>
    [CascadingParameter]
    public Breadcrumb Breadcrumb { get; set; } = default!;

    /// <summary>
    /// The URL to navigate to when the breadcrumb item is clicked. If null, the item will render as plain text.
    /// </summary>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Specifies whether to show an icon alongside the breadcrumb item.
    /// </summary>
    [Parameter]
    public bool ShowIcon { get; set; } = true;

    #endregion

    #region Fragments

    /// <summary>
    /// The content to render inside the breadcrumb item.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion

    /// <summary>
    /// Selects the appropriate CSS class for the breadcrumb item based on whether it is a link.
    /// </summary>
    private string SelectContentClass() =>
        Href == null
            ? "text-gray-500 dark:text-gray-400"
            : "text-gray-700 hover:text-blue-600 dark:text-gray-400 dark:hover:text-white";

    /// <summary>
    /// Adds this breadcrumb item to the parent's item collection when initialized.
    /// </summary>
    protected override void OnInitialized()
    {
        if (Breadcrumb == null)
        {
            throw new InvalidOperationException($"{nameof(BreadcrumbItem)} must be used inside a {nameof(Breadcrumb)}.");
        }

        Breadcrumb.Items.Add(this);
        base.OnInitialized();
    }

    /// <summary>
    /// Removes this breadcrumb item from the parent's item collection when disposed.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            Breadcrumb.Items.Remove(this);
        }

        _disposed = true;
    }

    /// <summary>
    /// Disposes of the breadcrumb item and suppresses finalization.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
