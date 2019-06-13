// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// https://github.com/aspnet/AspNetCore/blob/master/src/Components/Components/src/Forms/InputComponents/InputDate.cs

using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;
using static System.Nullable;
using static Microsoft.AspNetCore.Components.BindMethods;

namespace UniversityManagementSystem.Apps.Blazor.Components.Forms
{
    /// <summary>
    ///     An input component for editing time values.
    ///     Supported types are <see cref="DateTime" />, <see cref="DateTimeOffset" /> and <see cref="TimeSpan" />.
    /// </summary>
    public class InputTime<T> : InputBase<T>
    {
        private const string TimeFormat = "HH:mm";

        /// <summary>
        ///     Gets or sets the error message used when displaying a parsing error.
        /// </summary>
        [Parameter]
        public string ParsingErrorMessage { get; } = "The {0} field must be a time.";

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddAttribute(2, "type", "time");
            builder.AddAttribute(3, "id", Id);
            builder.AddAttribute(4, "class", CssClass);
            builder.AddAttribute(5, "value", GetValue(CurrentValueAsString));
            builder.AddAttribute(6, "onchange", SetValueHandler(__value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override string FormatValueAsString(T value)
        {
            switch (value)
            {
                case DateTime dateTimeValue:
                    return dateTimeValue.ToString(TimeFormat);
                case DateTimeOffset dateTimeOffsetValue:
                    return dateTimeOffsetValue.ToString(TimeFormat);
                case TimeSpan timeSpanValue:
                    return timeSpanValue.ToString(TimeFormat);
                default:
                    return string.Empty;
            }
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            var targetType = GetUnderlyingType(typeof(T)) ?? typeof(T);

            bool success;

            if (targetType == typeof(DateTime))
                success = TryParseDateTime(value, out result);
            else if (targetType == typeof(DateTimeOffset))
                success = TryParseDateTimeOffset(value, out result);
            else if (targetType == typeof(TimeSpan))
                success = TryParseTimeSpan(value, out result);
            else
                throw new InvalidOperationException($"The type '{targetType}' is not a supported time type.");

            if (success)
            {
                validationErrorMessage = null;
                return true;
            }

            validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
            return false;
        }

        private static bool TryParseDateTime(string value, out T result)
        {
            var success = DateTime.TryParse(value, out var parsedValue);

            if (success)
            {
                result = (T) (object) parsedValue;
                return true;
            }

            result = default;
            return false;
        }

        private static bool TryParseDateTimeOffset(string value, out T result)
        {
            var success = DateTimeOffset.TryParse(value, out var parsedValue);

            if (success)
            {
                result = (T) (object) parsedValue;
                return true;
            }

            result = default;
            return false;
        }

        private static bool TryParseTimeSpan(string value, out T result)
        {
            var success = TimeSpan.TryParse(value, out var parsedValue);

            if (success)
            {
                result = (T) (object) parsedValue;
                return true;
            }

            result = default;
            return false;
        }
    }
}