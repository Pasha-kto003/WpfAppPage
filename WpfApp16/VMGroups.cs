using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WpfApp16
{
    internal class VMGroups : INotifyPropertyChanged
    {
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Special> Specials { get; set; }
        private Group selectedGroup;

        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set { 
                selectedGroup = value;
                SignalChanged();
            }
        }

        public CustomCommand AddGroup { get; set; }
        public CustomCommand SaveGroups { get; set; }
        public CustomCommand OpenGroups { get; set; }
        public CustomCommand OpenSpecials { get; set; }

        public Page CurrentPage { get; set; }

        Entities2 entities;
        public VMGroups()
        {
            entities = DB.GetDB();
            LoadGroups();
            Groups = new ObservableCollection<Group>(entities.Groups);
            Specials = new ObservableCollection<Special>(entities.Specials);

            AddGroup = new CustomCommand(() =>
            {
                var group = new Group { Number = "Номер группы" };
                entities.Groups.Add(group);
                SelectedGroup = group;
            });

            SaveGroups = new CustomCommand(() =>
            {
               try
               {
                   entities.SaveChanges();
                   LoadGroups();
               }
               catch (Exception ex)
               {
                   System.Windows.MessageBox.Show(ex.Message);
               }

           });

            OpenSpecials = new CustomCommand(() => { CurrentPage = new WinSpecials(); SignalChanged("CurrentPage"); });
            OpenGroups = new CustomCommand(() => { CurrentPage = new WinGroups(); SignalChanged("CurrentPage"); });
            
        }

        private void LoadGroups()
        {
            Groups = new ObservableCollection<Group>(entities.Groups);
            SignalChanged("Groups");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}