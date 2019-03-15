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
		public MainPage()
		{
			InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Food> menu;
            menu = await App.ServerAPI.GetFoodListAsync();

            App.Menu = new DynamicMenu(menu);

            var grid = new Grid();
            int count = 0;
            int row = 0;
            int column = 0;

            for (int i = 0; i < 4; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < 4; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            foreach(Food food in App.Menu.Foods)
            {
                var tempObject = new Button { Text = food.Name };
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

        }

    }
}
