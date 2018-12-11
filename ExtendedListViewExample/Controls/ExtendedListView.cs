using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExtendedListViewExample.Controls
{
    public class ExtendedListView : ListView
    {
        public static readonly BindableProperty ItemAppearingCommandProperty =
            BindableProperty.Create(nameof(ItemAppearingCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand ItemAppearingCommand
        {
            get { return (ICommand)GetValue(ItemAppearingCommandProperty); }
            set { SetValue(ItemAppearingCommandProperty, value); }
        }

        public static readonly BindableProperty LoadMoreCommandProperty =
                    BindableProperty.Create(nameof(LoadMoreCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public ExtendedListView()
        {
            this.ItemAppearing += OnItemAppearing;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (ItemAppearingCommand != null)
            {
                ItemAppearingCommand?.Execute(e.Item);
            }
            if (LoadMoreCommand != null)
            {
                if (e.Item == ItemsSource.Cast<object>().Last())
                {
                    LoadMoreCommand?.Execute(null);
                }
            }
        }
    }
}
