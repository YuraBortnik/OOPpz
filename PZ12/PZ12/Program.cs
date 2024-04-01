using System;
using System.Collections.Generic;
using System.Linq;



class Product
{
    public string Name { get; }
    public double Price { get; }
    public string Category { get; }

    public Product(string name, double price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введіть список товарів з полями name, price, category розділені комами:");
        Console.WriteLine("Приклад формату: Назва1, Ціна1, Категорія1; Назва2, Ціна2, Категорія2; ...");

        string input = Console.ReadLine();

        
        string[] productsInput = input.Split(';');

        
        List<Product> products = new List<Product>();

        
        foreach (string productInput in productsInput)
        {
            string[] data = productInput.Trim().Split(',');
            if (data.Length == 3)
            {
                products.Add(new Product(
                    name: data[0].Trim(),
                    price: double.Parse(data[1].Trim()),
                    category: data[2].Trim()));
            }
        }

        
        var groupedProducts = products.GroupBy(p => p.Category);

        
        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"Топ 3 найдорожчих товарів у категорії '{group.Key}':");

            var top3 = group.OrderByDescending(p => p.Price).Take(3);

            foreach (var product in top3)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            Console.WriteLine();
        }
    }
}
