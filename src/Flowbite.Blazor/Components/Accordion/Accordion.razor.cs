using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Use the accordion component to show hidden information based on the collapse and expand state of the child elements using data attribute options.
/// </summary>
/// <remarks>
/// The accordion component is a collection of vertically collapsing header and body elements that can be used to show and hide information based on the Tailwind CSS utility classes and JavaScript from Flowbite. <br />
/// A popular use case would be the “Frequently Asked Questions” section of a website or page when you can show questions and answers for each child element. <br />
/// There are two main options to initialize the accordion component: <br />
/// <br />
/// data-accordion="collapse" show only one active child element <br />
/// data-accordion="open" keep multiple elements open <br />
/// <br />
/// Don’t forget to set the data-accordion-target="{selector}" data attribute to the header element where the value is the id or class of the accordion body element and the aria-expanded="{true|false}" attribute to mark the active or inactive state of the accordion. <br />
/// </remarks>
public partial class Accordion : FlowbiteComponentBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Accordion"/> component.
    /// Sets a default value for <see cref="Id"/> if it is not already provided.
    /// </summary>
    public Accordion() => Id ??= $"accordion-{Identifier.NewId()}";

    #region Parameters

    /// <summary>
    /// Gets or sets the classes to apply when an accordion item is active.
    /// These classes will be added to the accordion item when it is in the "active" state.
    /// </summary>
    [Parameter]
    public string? ActiveClasses { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Type"/> of icon to display in the accordion. 
    /// The icon class can be set using a <see cref="Type"/> that corresponds to an icon type, which is rendered alongside the accordion item.
    /// </summary>
    [Parameter]
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    public Type? Icon { get; set; }

    /// <summary>
    /// Gets or sets the classes to apply when an accordion item is inactive.
    /// These classes will be applied to the accordion item when it is in the "inactive" state.
    /// </summary>
    [Parameter]
    public string? InactiveClasses { get; set; }

    /// <summary>
    /// Gets or sets the type of accordion behavior. The default value is <see cref="Constants.Accordion.Collapse"/>.
    /// <list type="bullet">
    /// <item><description>collapse - Only one accordion item can be open at a time.</description></item>
    /// <item><description>open - Multiple accordion items can be open simultaneously.</description></item>
    /// </list>
    /// </summary>
    [Parameter]
    public string Type { get; set; } = Constants.Accordion.Collapse;

    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Gets or sets the content that will be rendered inside the accordion component. 
    /// This property allows the user to insert child elements into the accordion dynamically.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion Fragments
}
