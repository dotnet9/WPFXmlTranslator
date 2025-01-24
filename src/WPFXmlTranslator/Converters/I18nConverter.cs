using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using WPFXmlTranslator.Markup;

namespace WPFXmlTranslator.Converters;

public class I18nConverter: IMultiValueConverter
{
    private readonly I18nExtension _owner;
    public I18nConverter(I18nExtension owner)
    {
        _owner = owner;
    }
    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is not CultureInfo _)
        {
            return default;
        }

        var value = values[1];
        if (_owner.KeyConverter.Convert(value, null, null, culture) is not string key)
        {
            return value;
        }

        value = I18nManager.Instance.GetResource(key, _owner.CultureName) ?? key;

        if (value is string format)
        {
            value = string.Format(format, _owner.Args.Indexes
                .Select(item => item.IsBinding ? values[item.Index] : this._owner.Args[item.Index])
                .ToArray());
        }

        return _owner.ValueConverter.Convert(value, null, null, culture);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
