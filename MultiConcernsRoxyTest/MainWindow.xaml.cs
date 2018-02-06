using MultiConcernsRoxyTest.RoxyViewModels;
using NP.Roxy;
using NP.Utilities.Behaviors;
using System.Windows;

namespace MultiConcernsRoxyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // create the generated types
            RoxyModelAssembler.AssembleSelectableRemovablePerson();
            RoxyModelAssembler.AssembleSelectableRemovableBusinessGroup();
            RoxyModelAssembler.AssembleBusinessGroupsCollection();

            // get the data context as BusinessGroupsVM type
            SingleSelectionObservableCollection<ISelectableRemovableBusinessGroup> dataContext =
                Core.GetInstanceOfGeneratedType<SingleSelectionObservableCollection<ISelectableRemovableBusinessGroup>>();

            // set the data context of the main window
            this.DataContext = dataContext;

           // create businessGroup1 as BusingGroupVM object
           ISelectableRemovableBusinessGroup businessGroup1 = 
                Core.GetInstanceOfGeneratedType<ISelectableRemovableBusinessGroup>();

            businessGroup1.Name = "Astrologists";

            // add businessGroup1 to the data context collection
            dataContext.Add(businessGroup1);

            // create person1 as PersonVM object
            ISelectableRemovablePerson person1 = Core.GetInstanceOfGeneratedType<ISelectableRemovablePerson>();

            //set properties
            person1.FirstName = "Joe";
            person1.LastName = "Doe";

            // add person1 object to businessGroup1
            businessGroup1.People.Add(person1);

            // create and add person2
            ISelectableRemovablePerson person2 = Core.GetInstanceOfGeneratedType<ISelectableRemovablePerson>();
            person2.FirstName = "Jane";
            person2.LastName = "Dane";
            businessGroup1.People.Add(person2);

            // create and add businessGroup2
            ISelectableRemovableBusinessGroup businessGroup2 =
                Core.GetInstanceOfGeneratedType<ISelectableRemovableBusinessGroup>();
            businessGroup2.Name = "Alchemists";
            dataContext.Add(businessGroup2);

            // create and add person3 
            ISelectableRemovablePerson person3 = Core.GetInstanceOfGeneratedType<ISelectableRemovablePerson>();
            person3.FirstName = "Michael";
            person3.LastName = "Mont";
            businessGroup2.People.Add(person3);

            // create and add person4
            ISelectableRemovablePerson person4 = Core.GetInstanceOfGeneratedType<ISelectableRemovablePerson>();
            person4.FirstName = "Michelle";
            person4.LastName = "Mitchell";
            businessGroup2.People.Add(person4);
        }
    }
}
