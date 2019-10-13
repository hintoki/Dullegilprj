using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dulaegil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class stylesMaster : ContentPage
    {
        public ListView ListView;

        public stylesMaster()
        {
            InitializeComponent();

            BindingContext = new stylesMasterViewModel();
            ListView = MenuItemsListView;
        }

        class stylesMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<stylesMenuItem> MenuItems { get; set; }
            
            public stylesMasterViewModel()
            {
                MenuItems = new ObservableCollection<stylesMenuItem>(new[]
                {
                    new stylesMenuItem { Id = 0, Title = "Page 1" },
                    new stylesMenuItem { Id = 1, Title = "Page 2" },
                    new stylesMenuItem { Id = 2, Title = "Page 3" },
                    new stylesMenuItem { Id = 3, Title = "Page 4" },
                    new stylesMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}