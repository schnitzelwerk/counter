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
        Label currentPrice;
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
            currentPrice = new Label { Text = "0.0€" };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var grid = new Grid();
            Content = grid;

            List<Food> menu;
            menu = await App.ServerAPI.GetFoodListAsync();
            App.Menu = new DynamicMenu(menu, new List<Ingredient>(), new List<Extra>());

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
                tempObject.Style = (Style)Application.Current.Resources["foodButtonStyle"];
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

            // Current Order List and Controls
            grid.Children.Add(new Label() { Text = "Current Order" }, size - 1, 0);

            DataTemplate dT = new DataTemplate(typeof(TextCell));
            dT.SetBinding(TextCell.TextProperty, "Name");

            orderListView.ItemTemplate = dT;
            orderListView.ItemsSource = currentOrder.Parts;

            grid.Children.Add(orderListView, size - 1, 1);
            Grid.SetRowSpan(orderListView, size - 3);

            grid.Children.Add(currentPrice, size-1, size-2);

            var placeOrderButton = new Button { Text = "Place Order" };
            placeOrderButton.Clicked += placeOrder;
            placeOrderButton.Style = (Style)Application.Current.Resources["placeOrderButtonStyle"];
            grid.Children.Add(placeOrderButton, size - 1, size - 1);
        }


        private async void addOrder(object sender, EventArgs e)
        {
            orderListView.BeginRefresh();
            currentOrder.Parts.Insert(0, App.Menu.getCopyMealByName((sender as Button).Text));
            orderListView.ItemsSource = null;
            orderListView.ItemsSource = currentOrder.Parts;
            currentPrice.Text = currentOrder.Price.ToString() + "€";
            orderListView.EndRefresh();
        }

        private async void placeOrder(object sender, EventArgs e)
        {

        }

    }
}
