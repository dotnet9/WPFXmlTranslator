using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace WPFXmlTranslator.Markup;

public class ArgCollection(I18nBinding owner) : Collection<object>
{
    // HACK: Replace the System.ValueTuple with a struct.
    // See here for details: https://github.com/dotnet/wpf/issues/2320
    internal struct ArgTuple
    {
        public bool IsBinding { get; }

        public int Index { get; }

        public ArgTuple(bool isBinding, int index)
        {
            IsBinding = isBinding;
            Index = index;
        }
    }
    internal List<ArgTuple> Indexes { get; } = [];

    protected override void InsertItem(int index, object item)
    {
        if (item is BindingBase binding)
        {
            Indexes.Add(new(true, owner.Bindings.Count));
            owner.Bindings.Add(binding);
        }
        else
        {
            Indexes.Add(new(false, Count));
            base.InsertItem(index, item);
        }
    }
}
