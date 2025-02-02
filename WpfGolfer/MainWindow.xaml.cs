using GolfGamingBL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfGolfer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string currentGolferFullName;

        public string CurrentGolferFullName
        {
            get { return currentGolferFullName; }
            set
            {
                currentGolferFullName = value;
                NotifyPropertyChanged("CurrentGolferFullName");
            }
        }

        private string currentGolfCourseName;

        public string CurrentGolfCourseName
        {
            get { return currentGolfCourseName; }
            set
            {
                    CurrentGolfCourseName = value;
                    NotifyPropertyChanged("CurrentGolfCourseName");
            }
        }




        private Season golfSeason;
        public Season GolfSeason
        {
            get
            {
                return golfSeason;
            }
            set
            {
                golfSeason = value;
                NotifyPropertyChanged("GolfSeason");
            }
        }




        public MainWindow()
        {
            InitializeComponent();
            GolfSeason = new Season();
            CurrentGolferFullName = GolfSeason.CurrentGolfer.ToString();
            CurrentGolfCourseName = GolfSeason.CurrentGolfCourse.ToString();
           this.DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
   //         CurrentGolferName = GolfSeason.CurrentGolfer.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GolfSeason = new Season();
            GolfSeason.AdvanceToNextCurrentGolfer();
            CurrentGolferFullName = GolfSeason.CurrentGolfer.ToString();
 
        }
    }

}
