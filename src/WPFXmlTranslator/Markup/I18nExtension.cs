using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using WPFXmlTranslator.Converters;

namespace WPFXmlTranslator.Markup;

[ContentProperty(nameof(Args))]
[MarkupExtensionReturnType(typeof(object))]
public class I18nExtension : MultiBinding
{
    public I18nExtension(object key)
    {
        Mode = BindingMode.OneWay;
        Converter = new I18nConverter(this);
        KeyConverter = new I18nKeyConverter();
        ValueConverter = new I18nValueConverter();
        Args = new ArgCollection(this);

        var cultureBinding = new Binding
            { Source = I18nManager.Instance, Path = new PropertyPath(nameof(I18nManager.Culture)) };
        Bindings.Add(cultureBinding);

        Key = key;
        if (Key is not BindingBase keyBinding)
        {
            keyBinding = new Binding { Source = key };
        }

        Bindings.Add(keyBinding);
    }

    public I18nExtension(object key, object arg0) : this(key)
    {
        Args.Add(arg0);
    }

    public I18nExtension(object key, object arg0, object arg1) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2, object arg3) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
        Args.Add(arg3);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2, object arg3, object arg4) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
        Args.Add(arg3);
        Args.Add(arg4);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) :
        this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
        Args.Add(arg3);
        Args.Add(arg4);
        Args.Add(arg5);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5,
        object arg6) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
        Args.Add(arg3);
        Args.Add(arg4);
        Args.Add(arg5);
        Args.Add(arg6);
    }

    public I18nExtension(object key, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5,
        object arg6, object arg7) : this(key)
    {
        Args.Add(arg0);
        Args.Add(arg1);
        Args.Add(arg2);
        Args.Add(arg3);
        Args.Add(arg4);
        Args.Add(arg5);
        Args.Add(arg6);
        Args.Add(arg7);
    }

    public object Key { get; }

    public string? CultureName { get; set; }

    public ArgCollection Args { get; }

    [ConstructorArgument(nameof(KeyConverter))]
    public IValueConverter KeyConverter { get; set; }

    [ConstructorArgument(nameof(ValueConverter))]
    public IValueConverter ValueConverter { get; set; }
}