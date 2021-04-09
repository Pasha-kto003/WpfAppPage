using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp16
{
    internal class VMStudent : INotifyPropertyChanged
    {
        Entities2 entities;
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        private Student selectedStudent;
        public CustomCommand AddStudent { get; set; }
        public CustomCommand SaveStudents { get; set; }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set { selectedStudent = value; SignalChanged(); }
        }


        public VMStudent()
        {
            entities = DB.GetDB();
            LoadStudents();
            Groups = new ObservableCollection<Group>(entities.Groups);

            AddStudent = new CustomCommand(() =>
            {
                var student = new Student { FirstName = "Имя", LastName = "Фамилия" };
                entities.Students.Add(student);
                SelectedStudent = student;
                LoadStudents();

            });
            SaveStudents = new CustomCommand(() =>
            {
                try
                {
                    entities.SaveChanges();
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void LoadStudents()
        {
            Students = new ObservableCollection<Student>(entities.Students);
            SignalChanged("Students");
        }
    }
}
