using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp16
{


        internal class MainVM : INotifyPropertyChanged
        {
            public Page CurrentPage { get; set; }

            Entities2 entities;

            public ObservableCollection<Special> Specials { get; set; }
            public ObservableCollection<Group> Groups { get; set; }
            public ObservableCollection<Student> Students { get; set; }

            public CustomCommand OpenGroups { get; set; }
            public CustomCommand OpenStudents { get; set; }
            public CustomCommand OpenSpecials { get; set; }
            public CustomCommand OpenList { get; set; }

            public MainVM()
            {
                entities = DB.GetDB();
                Specials = new ObservableCollection<Special>(entities.Specials);
                OpenSpecials = new CustomCommand(() => { CurrentPage = new WinSpecials(); SignalChanged("CurrentPage"); });
                OpenGroups = new CustomCommand(() => { CurrentPage = new WinGroups(); SignalChanged("CurrentPage"); });
                OpenStudents = new CustomCommand(() => { CurrentPage = new WinSudents(); SignalChanged("CurrentPage"); });
                OpenList = new CustomCommand(() => { CurrentPage = new MainPage(); SignalChanged("CurrentPage"); });
            }

            void SignalChanged([CallerMemberName] string prop = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

            public event PropertyChangedEventHandler PropertyChanged;
        }
}


