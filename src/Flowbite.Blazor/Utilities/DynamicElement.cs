using Microsoft.AspNetCore.Components.Rendering;

namespace Microsoft.AspNetCore.Components;

public class DynamicElement : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public string As { get; set; } = "div";

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? Attributes { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(As);

        // Open the dynamic tag
        builder.OpenElement(0, As);

        // Add attributes
        builder.AddMultipleAttributes(1, Attributes);

        // Add child content
        if (ChildContent != null)
        {
            builder.AddContent(2, ChildContent);
        }

        // Close the dynamic tag
        builder.CloseElement();
    }
}
