using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace counter
{
	public partial class MainPage : ContentPage
	{
        Order currentOrder;
        ListView orderListView;

        public MainPage()
		{
			InitializeComponent();

            if (App.Orders.Any(O => O.State == OrderState.OPEN))
            {
                currentOrder = App.Orders.Find(O => O.State == OrderState.OPEN);
            }
            else
            {
                currentOrder = new Order();
                App.Orders.Add(currentOrder);
            }
            orderListView = new ListView();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Food> menu;

            menu = await App.ServerAPI.GetFoodListAsync();


            App.Menu = new DynamicMenu(menu, new List<Ingredient>(), new List<Extra>());

            var grid = new Grid();
            int size = 4;
            int count = 0;
            int row = 0;
            int column = 0;

            for (int i = 0; i < size; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < size; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            foreach (Food meal in App.Menu.Meals)
            {
                var tempObject = new Button { Text = meal.Name };
                tempObject.Clicked += addOrder;
                tempObject.Style = (Style) Application.Current.Resources["foodButtonStyle"];
                grid.Children.Add(tempObject, column, row);

                if (column < 2)
                {
                    column++;
                }
                else
                {
                    row++;
                    column = 0;
                }

                count++;
            }

            Content = grid;

            grid.Children.Add(new Label() { Text = "Current Order" }, size - 1, 0);

            DataTemplate dT = new DataTemplate(typeof (TextCell));
            dT.SetBinding(TextCell.TextProperty, "Name");
            //{
            //    Grid ingrid = new Grid();
            //    Label nameLabel = new Label() { FontSize = 9};
            //    nameLabel.BindingContext = ;
            //    nameLabel.SetBinding(Label.TextProperty, "Name");
            //    ingrid.Children.Add(nameLabel);
            //    return new ViewCell { View = ingrid };
            //});
            
            orderListView.ItemTemplate = dT;
            orderListView.ItemsSource = currentOrder.Parts;
            
            grid.Children.Add( orderListView, size-1, 1);
            Grid.SetRowSpan(orderListView, 3);
        }


        private async void addOrder(object sender, EventArgs e)
        {
            currentOrder.Parts.Add(App.Menu.getCopyMealByName((sender as Button).Text));

            orderListView.ItemsSource = null;
            orderListView.ItemsSource = currentOrder.Parts;
        }

    }
}
