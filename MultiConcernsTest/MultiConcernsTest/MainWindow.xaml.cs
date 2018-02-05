using MultiConcernsTest.ViewModels;
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

namespace MultiConcernsTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BusinessGroupsVM businessGroups = new BusinessGroupsVM();

            // build some test data
            BusinessGroupVM businessGroup1 = new BusinessGroupVM
            {
                Name = "Astrologists"
            };

            businessGroup1.People.Add(new PersonVM { FirstName = "Joe", LastName = "Doe" });
            businessGroup1.People.Add(new PersonVM { FirstName = "Jane", LastName = "Dane" });

            businessGroups.Add(businessGroup1);

            BusinessGroupVM businessGroup2 = new BusinessGroupVM
            {
                Name = "Alchemists"
            };

            businessGroup2.People.Add(new PersonVM { FirstName = "Michael", LastName = "Mont" });
            businessGroup2.People.Add(new PersonVM { FirstName = "Michelle", LastName = "Mitchell" });

            businessGroups.Add(businessGroup2);

            this.DataContext = businessGroups;
        }
    }
}
