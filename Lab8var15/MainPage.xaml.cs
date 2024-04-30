using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using CoinCollection.Data;
using CoinCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinCollection
{
    public sealed partial class MainPage : Page
    {
        public CoinViewModel ViewModel { get; } = new CoinViewModel();

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new CoinViewModel();
            DataContext = ViewModel;
            CoinCollectionDbContext.Initialize();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadData();
        }

        private void ClearTextboxes()
        {
            textBoxYear.Text = string.Empty;
            textBoxCountry.Text = string.Empty;
            textBoxNominal.Text = string.Empty;
            textBoxCondition.Text = string.Empty;
        }

        private async void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxYear.Text, out int year))
            {
                Coin coin = new Coin
                {
                    Year = year,
                    Country = textBoxCountry.Text,
                    Nominal = textBoxNominal.Text,
                    Condition = textBoxCondition.Text
                };

                await ViewModel.AddCoin(coin);
                ClearTextboxes();
            }
        }

        private async void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex >= 0 && listView1.SelectedItem != null)
            {
                Coin coin = (Coin)listView1.SelectedItem;

                if (int.TryParse(textBoxYear.Text, out int year))
                {
                    coin.Year = year;
                }

                if (!string.IsNullOrEmpty(textBoxCountry.Text))
                {
                    coin.Country = textBoxCountry.Text;
                }

                if (!string.IsNullOrEmpty(textBoxNominal.Text))
                {
                    coin.Nominal = textBoxNominal.Text;
                }

                if (!string.IsNullOrEmpty(textBoxCondition.Text))
                {
                    coin.Condition = textBoxCondition.Text;
                }

                await ViewModel.EditCoin(coin);
                ClearTextboxes();
            }
        }

        private async void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex >= 0)
            {
                Coin coin = (Coin)listView1.SelectedItem;
                await ViewModel.DeleteCoin(coin);
            }
        }
    }
}