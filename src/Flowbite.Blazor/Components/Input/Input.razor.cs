using Flowbite.Blazor.Enums;
using Flowbite.Blazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Flowbite.Blazor.Components;

/// <summary>
/// Provides a component for rendering input fields with customizable styles, sizes, and behaviors.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with the input field.</typeparam>
/// <remarks>
/// This component is built using Tailwind CSS and Flowbite utilities to support a variety of input types such as 
/// text, email, number, password, URL, phone number, and more. It includes options for customization in terms of 
/// colors, sizes, and visual variants, making it versatile for different use cases in forms and data entry scenarios.
/// </remarks>
public partial class Input<TValue> : FlowbiteInputBase<TValue>
{
    private string? RenderBorderClass => new CssBuilder("border")
        .AddClass(SelectBorder())
        .Build();

    private string? RenderedClass => new CssBuilder("bg-gray-50 text-gray-900 rounded-lg block w-full dark:bg-gray-600 dark:placeholder-gray-400 dark:text-white")
        .AddClass("ps-10", Start != null)
        .AddClass("pe-10", End != null)
        .AddClass(RenderBorderClass)
        .AddClass(Class)
        .AddClass(SelectColor())
        .AddClass(SelectSize())
        .Build();

    #region Parameters

    /// <summary>
    /// Specifies the color variant for the input field.
    /// </summary>
    [Parameter]
    public Colors Color { get; set; }

    /// <summary>
    /// Specifies the size of the input field (e.g., Small, Large).
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }


    #endregion Parameters

    #region Fragments

    /// <summary>
    /// Fragment to render at the end of the input field.
    /// </summary>
    [Parameter]
    public RenderFragment? End { get; set; }

    /// <summary>
    /// Fragment to render at the start of the input field.
    /// </summary>
    [Parameter]
    public RenderFragment? Start { get; set; }

    #endregion Fragments

    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (typeof(TValue) == typeof(int))
        {
            if (int.TryParse(value, out var intResult))
            {
                result = (TValue)(object)intResult;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = "The input is not a valid integer.";
                return false;
            }
        }
        else if (typeof(TValue) == typeof(double))
        {
            if (double.TryParse(value, out var doubleResult))
            {
                result = (TValue)(object)doubleResult;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = "The input is not a valid double.";
                return false;
            }
        }
        else if (typeof(TValue) == typeof(DateTime))
        {
            if (DateTime.TryParse(value, CultureInfo.CurrentCulture, out var dateResult))
            {
                result = (TValue)(object)dateResult;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = "The input is not a valid date.";
                return false;
            }
        }
        else if (typeof(TValue) == typeof(bool))
        {
            if (bool.TryParse(value, out var boolResult))
            {
                result = (TValue)(object)boolResult;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage = "The input is not a valid boolean.";
                return false;
            }
        }
        else
        {
            result = default;
            validationErrorMessage = $"Unsupported type: {typeof(TValue).FullName}";
            return false;
        }
    }

    private string? SelectBorder() => Color switch
    {
        Colors.Gray => "focus:ring-gray-500 dark:focus:ring-gray-500",
        Colors.Red => "focus:ring-red-500 dark:focus:ring-red-500",
        Colors.Yellow => "focus:ring-yellow-500 dark:focus:ring-yellow-500",
        Colors.Green => "focus:ring-green-500 dark:focus:ring-green-500",
        Colors.Blue => "focus:ring-blue-500 dark:focus:ring-blue-500",
        Colors.Indigo => "focus:ring-indigo-500 dark:focus:ring-indigo-500",
        Colors.Purple => "focus:ring-purple-500 dark:focus:ring-purple-500",
        Colors.Pink => "focus:ring-pink-500 dark:focus:ring-pink-500",
        _ => throw new NotImplementedException()
    };

    private string? SelectColor() => Color switch
    {
        Colors.Gray => "focus:border-gray-500 dark:focus:border-gray-500",
        Colors.Red => "focus:border-red-500 dark:focus:border-red-500",
        Colors.Yellow => "focus:border-yellow-500 dark:focus:border-yellow-500",
        Colors.Green => "focus:border-green-500 dark:focus:border-green-500",
        Colors.Blue => "focus:border-blue-500 dark:focus:border-blue-500",
        Colors.Indigo => "focus:border-indigo-500 dark:focus:border-indigo-500",
        Colors.Purple => "focus:border-purple-500 dark:focus:border-purple-500",
        Colors.Pink => "focus:border-pink-500 dark:focus:border-pink-500",
        _ => throw new NotImplementedException()
    };

    private string? SelectSize() => Size switch
    {
        Sizes.Small => "p-2 text-xs",
        Sizes.Large => "p-4 text-base",
        _ => "p-2.5 text-sm",
    };
}