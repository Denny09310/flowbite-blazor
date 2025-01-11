using Flowbite.Blazor.Components;
using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Icons;

public partial class FlowbiteIcon : FlowbiteComponentBase
{
    protected virtual string? RenderedClass => new CssBuilder()
        .AddClass(SelectSize())
        .Build();

    #region Parameters

    [Parameter]
    public Sizes Size { get; set; }

    #endregion Parameters

    private string? SelectSize() => Size switch
    {
        Sizes.Small => "w-6 h-6",
        Sizes.Medium => "w-8 h-8",
        Sizes.Large => "w-12 h-12",
        Sizes.ExtraLarge => "w-16 h-16",
        _ => "w-4 h-4",
    };
}