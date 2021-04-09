using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp16
{
    /// <summary>
    /// Логика взаимодействия для WinGroups.xaml
    /// </summary>
    public partial class WinGroups : Page
    {
        public WinGroups()
        {
            InitializeComponent();
            DataContext = new VMGroups();
        }

       
    }
}
