using System;
using System.Windows;
using ShoeStore.Models;

namespace ShoeStore
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

     
        public string ImagePath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Product.Image))
                    return "/Resources/picture.png";

                string path = $"/Resources/{Product.Image}";

                try
                {
                    
                    if (Application.GetResourceStream(new Uri(path, UriKind.Relative)) == null)
                        return "/Resources/picture.png";
                    return path;
                }
                catch
                {
                    return "/Resources/picture.png";
                }
            }
        }

       
        public string HeaderText => $"{Product.Production.ProductionName} | {Product.ProductName}";
        public string CategoryText => Product.Category.CategoryName;
        public string CompositionText => Product.Compound;

        public string PriceText => $"{Product.Price:0} ₽";

      
        public int TotalQuantity { get; set; }

        public string QuantityText => TotalQuantity > 5 ? "много" : "мало";

   
        public bool IsHighlight => TotalQuantity <= 3;
    }
}