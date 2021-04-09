using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WpfApp16
{
    internal class VM : INotifyPropertyChanged
    {
        Entities2 entities;
        private Special selectedSpecial;
        private Group selectedGroup;
        public Page CurrentPage { get; set; }

        public ObservableCollection<Special> Specials { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public CustomCommand OpenSpecials { get; set; }
        public CustomCommand OpenGroups { get; set; }
        public CustomCommand OpenStudents { get; set; }

        public Special SelectedSpecial
        {
            get => selectedSpecial; set
            {
                selectedSpecial = value;
                if (SelectedSpecial != null) { Groups = new ObservableCollection<Group>(SelectedSpecial.Groups); }
                else
                { Groups = new ObservableCollection<Group>(); }
                SignalChanged("Groups");
            }
        }

        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                if (selectedGroup != null) { Students = new ObservableCollection<Student>(selectedGroup.Students); }
                else
                { Students = new ObservableCollection<Student>(); }
                SignalChanged("Students");
            }
        }

        public VM()
        {
            entities = DB.GetDB();
            Specials = new ObservableCollection<Special>(entities.Specials);
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}