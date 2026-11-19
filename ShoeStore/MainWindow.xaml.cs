using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;

namespace ShoeStore
{
    public partial class MainWindow : Window
    {
        private readonly User _currentUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;

          
            txtFio.Text = $"{user.LastName} {user.FirstName} {user.Patronymic}".Trim();

            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var db = new ShoeStoreContext())
            {
               
                var products = db.Products
                    .Include(p => p.Category)
                    .Include(p => p.Production)
                    .ToList();

                
                var stockItems = db.StockItems.ToList();

                var viewModels = new List<ProductViewModel>();

                foreach (var p in products)
                {
                   
                    int totalQty = stockItems
                        .Where(s => s.ProductId == p.ProductId)
                        .Sum(s => s.StockQuantity);

                    viewModels.Add(new ProductViewModel
                    {
                        Product = p,
                        TotalQuantity = totalQty
                    });
                }

                lstProducts.ItemsSource = viewModels;
            }
        }
    }
}