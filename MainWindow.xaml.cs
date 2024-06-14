using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //hold count for the PieChart percentages
        int one = 0;
        int two = 0;
        int three = 0;
        int four = 0;
        int five = 0;
        int six = 0;
        int seven = 0;
        int eight = 0;
        


        //automic proparties for series collection of the pie-chart data collection
        public SeriesCollection SeriesCollection { get; private set; }


        //get instance of external class
        private Cooking_ingredient_Recipe Recipe = new Cooking_ingredient_Recipe();

        public MainWindow()
        {
            InitializeComponent();
        }


        //event handler for capturing
        private void capture(object sender, RoutedEventArgs e)
        {

            //open the capture page
            mainpage.Visibility = Visibility.Hidden;
            capturing.Visibility = Visibility.Visible;
            onpie.Visibility = Visibility.Hidden;
            display_all.Visibility = Visibility.Hidden;


           


        }

        //display event handler
        private void display(object sender, RoutedEventArgs e)
        {
            //open the display page
            mainpage.Visibility = Visibility.Hidden;
            capturing.Visibility = Visibility.Hidden;
            onpie.Visibility = Visibility.Hidden;
            display_all.Visibility = Visibility.Visible;

            //display all the data
            add_all.Items.Clear();

            //add from the display method in external class
            add_all.Items.Add(Recipe.displays() );
        }

        //saving the data 
        private void save(object sender, RoutedEventArgs e)
        {
            //get all the values from the user
            string name = recipe_name.Text;
            string quantity = recipe_quantity.Text;
            string measurement = recipe_measurement.Text;
            string food_groups = food_group.Text;

            //check the variables if they are not empty
            if (name.Equals("") || quantity.Equals("") || measurement.Equals("") ||  food_groups.Equals("") )
            {

                //display a message
                MessageBox.Show("     Error Message !! \n\n All fields are" +
                    "required !!\n\n");

            }
            else{


                //pass the varibales to store in the generics
                string message = Recipe.saves(name , quantity , measurement , food_groups);

                MessageBox.Show("Message !!\n\n" + message);
                //clear the fields 
                recipe_name.Clear();
                recipe_quantity.Clear();
                recipe_measurement.Clear();

            }




        }

        //display event handler
        private void filters(object sender, RoutedEventArgs e)
        {
            //open the display page
            mainpage.Visibility = Visibility.Hidden;
            capturing.Visibility = Visibility.Hidden;

            display_all.Visibility = Visibility.Hidden;

            onpie.Visibility = Visibility.Visible;
        }
        //piechart method or event handler
        private void check_pie(object sender, RoutedEventArgs e)
        {
            //alterate through filter hold filter_names generics
            for (int u = 0; u < Recipe.food_group.Count; u++)
            {


                //compare to assign percentage of them all if found
                if (Recipe.food_group[u].Contains("Vegetables and Fruits"))
                {

                    one += 1;
                }
                else if (Recipe.food_group[u].Contains("Dry beans ,Peas, Lentils and Soya"))
                {

                    two += 1;
                }
                else if (Recipe.food_group[u].Contains("Chicken, Fish, Meat and Eggs"))
                {
                    three += 1;
                }
                else if (Recipe.food_group[u].Contains("Milk and Dairy products"))
                {
                    four += 1;
                }
                else if (Recipe.food_group[u].Contains("Fats and Oil"))
                {
                    five += 1;
                }
                else if (Recipe.food_group[u].Contains("Water"))
                {
                    six += 1;
                }
                else if (Recipe.food_group[u].Contains("Starchy food"))
                {
                    seven += 1;
                }

            }



            //adding to series collections
            SeriesCollection = new SeriesCollection
            {
                //new series, to add all categories of food groups

                new PieSeries
                {
                    Title = "Vegetables and Fruits",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(one) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Dry beans ,Peas, Lentils and Soya",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(two) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chicken, Fish, Meat and Eggs",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(three) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Milk and Dairy products",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(four)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Fats and Oil",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(five)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Water",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(six)},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Starchy",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(seven)},
                    DataLabels = true
                },


            };

            //add the content into the pie chart
            DataContext = this;


            //reset values of counting
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;
            seven = 0;
            eight = 0;
        }


    }
}