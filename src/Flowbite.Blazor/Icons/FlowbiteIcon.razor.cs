using Flowbite.Blazor.Components;
using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace Flowbite.Blazor.Icons;

public partial class FlowbiteIcon : FlowbiteComponentBase
{
    protected virtual string? RenderedClass => new CssBuilder()
        .AddClass(SelectSizeVariant())
        .Build();

    #region Parameters

    [Parameter]
    public Sizes Size { get; set; }

    #endregion Parameters

    private string? SelectSizeVariant() => Size switch
    {
        Sizes.Medium => "w-10 h-10",
        Sizes.Small => "w-8 h-8",
        Sizes.Large => "w-20 h-20",
        Sizes.ExtraLarge => "w-36 h-36",
        Sizes.None or Sizes.ExtraSmall or _ => "w-6 h-6",
    };
}