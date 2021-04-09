using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp16
{
    internal class VMSpecials : INotifyPropertyChanged
    {
        Entities2 Entities2;
        private Special selectedSpecial;

        public Special SelectedSpecial { get => selectedSpecial; set { selectedSpecial = value; SignalChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Special> Specials { get; set; }
        public VMSpecials()
        {
            Entities2 = DB.GetDB();
            LoadSpecials();
            AddSpecial = new CustomCommand(() => {
                SelectedSpecial = new Special { Title = "Название" };
                Entities2.Specials.Add(SelectedSpecial);
            LoadSpecials();
            });

            SaveSpecials = new CustomCommand(() =>
            {
                try 
                {
                    Entities2.SaveChanges();
                    LoadSpecials();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
            
            
        }

       

        private void LoadSpecials()
        {
            Specials = new ObservableCollection<Special>(Entities2.Specials);
            SignalChanged("Specials");
        }
        void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public CustomCommand AddSpecial { get; set; }
        public CustomCommand SaveSpecials { get; set; }
    }
}