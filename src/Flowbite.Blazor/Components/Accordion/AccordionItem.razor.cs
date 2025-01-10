using Flowbite.Blazor.Icons;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Components;

public partial class AccordionItem : FlowbiteComponentBase
{
    /// <summary>
    /// Gets or sets a value indicating whether the accordion item is expanded.
    /// </summary>
    public bool Expanded { get; set; }

    /// <summary>
    /// Gets the unique ID of the body section of the accordion item, which is used to identify and toggle the body visibility.
    /// </summary>
    private string BodyId => $"{Accordion.Id}-body-{SequentialId}";

    /// <summary>
    /// Gets the unique ID of the heading section of the accordion item, which is used for accessibility and identification purposes.
    /// </summary>
    private string HeadingId => $"{Accordion.Id}-heading-{SequentialId}";

    /// <summary>
    /// A dynamically generated icon component for the accordion item. 
    /// The icon is rendered as a component, and its class is set dynamically based on whether the item is expanded.
    /// </summary>
    private RenderFragment Icon => new(builder =>
    {
        builder.OpenComponent(0, Accordion.Icon ?? typeof(ChevronDown));
        builder.AddAttribute(1, "data-accordion-icon", true);
        builder.AddComponentParameter(2, nameof(Class), RenderedIconClass);
        builder.CloseComponent();
    });

    /// <summary>
    /// Gets the CSS class to apply to the icon based on the expanded state of the accordion item. 
    /// If the item is expanded, the icon is rotated by 180 degrees.
    /// </summary>
    private string? RenderedIconClass => new CssBuilder("w-3 h-3 shrink-0")
        .AddClass("rotate-180", Expanded)
        .Build();

    /// <summary>
    /// Gets the unique sequential ID for each accordion item, used to distinguish items within an accordion.
    /// </summary>
    private string SequentialId { get; set; } = Identifier.SequentialContext().GenerateId();

    #region Parameters

    /// <summary>
    /// Gets or sets the parent <see cref="Accordion"/> instance that this accordion item belongs to.
    /// This is a cascading parameter, which means it is automatically provided by the parent accordion.
    /// </summary>
    [CascadingParameter]
    public Accordion Accordion { get; set; } = default!;

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the content to render in the body of the accordion item.
    /// This property allows users to dynamically insert the body content for each item.
    /// </summary>
    [Parameter]
    public RenderFragment? Body { get; set; }

    /// <summary>
    /// Gets or sets the content to render in the heading of the accordion item.
    /// This property allows users to dynamically insert the heading content for each item.
    /// </summary>
    [Parameter]
    public RenderFragment? Heading { get; set; }

    #endregion Fragments

    /// <summary>
    /// Ensures that the <see cref="AccordionItem"/> is used within an <see cref="Accordion"/>.
    /// Throws an exception if the item is not nested inside an accordion component.
    /// </summary>
    protected override void OnInitialized()
    {
        if (Accordion == null)
        {
            throw new NotSupportedException($"{nameof(AccordionItem)} must be used inside an {nameof(Accordion)}.");
        }
    }
}
