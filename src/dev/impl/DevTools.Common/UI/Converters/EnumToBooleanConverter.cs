﻿#nullable enable

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DevTools.Common.UI.Converters
{
    /// <summary>
    /// Convert a <see cref="Enum"/> to a <see cref="bool"/> value.
    /// </summary>
    public sealed class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null || parameter is null || !(value is Enum))
            {
                return false;
            }

            var currentState = value.ToString();
            var stateStrings = parameter.ToString();

            string[] stateStringsSplitted = stateStrings.Split(',');
            for (int i = 0; i < stateStringsSplitted.Length; i++)
            {
                if (string.Equals(currentState, stateStringsSplitted[i].Trim(), StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string? parameterString = parameter as string;
            var valueBool = value as bool?;
            if (parameterString is null || valueBool is null)
            {
                return DependencyProperty.UnsetValue;
            }

            return Enum.Parse(targetType, parameterString);
        }
    }
}