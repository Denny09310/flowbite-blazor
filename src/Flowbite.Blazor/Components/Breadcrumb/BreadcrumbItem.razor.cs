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
    private bool disposed;

    private string? RenderedClass => new CssBuilder("inline-flex items-center")
        .AddClass(Class)
        .Build();

    private bool IsLast => Breadcrumb.Items[^1] == this;

    #region Parameters

    /// <summary>
    /// Gets or sets the parent <see cref="Breadcrumb"/> instance that this breadcrumb item belongs to.
    /// This is a cascading parameter, which means it is automatically provided by the parent accordion.
    /// </summary>
    [CascadingParameter]
    public Breadcrumb Breadcrumb { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the breadcrumb icon should be shown.
    /// </summary>
    [Parameter]
    public bool ShowIcon { get; set; } = true;

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the content to render inside the breadcrumb item.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion Fragments

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Breadcrumb.Items.Remove(this);
            }

            disposed = true;
        }
    }

    protected override void OnInitialized()
    {
        if (Breadcrumb == null)
        {
            throw new NotSupportedException($"{nameof(BreadcrumbItem)} must be used inside an {nameof(Breadcrumb)}.");
        }

        Breadcrumb.Items.Add(this);
    }
}