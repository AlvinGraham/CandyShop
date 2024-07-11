namespace CandyShop;

internal class ProductController
{
	internal void UpdateProduct(string message)
	{
		Console.WriteLine(message);
	}



	internal void DeleteProduct(string message)
	{
		Console.WriteLine(message);
	}

	internal void AddProducts(List<string> products)
	{
		try
		{
			using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
			{
				foreach (var product in products)
				{
					outputFile.WriteLine($"{product.Trim()}", true);
				}
			}
			Console.WriteLine("Products Saved");
		}
		catch (Exception ex)
		{
			Console.WriteLine("There was an error saving products: " + ex.Message);
		}
	}

	internal void AddProduct()
	{
		Console.WriteLine("What Candy Would you like to add?");
		var product = Console.ReadLine();
		try
		{
			using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
			{
				outputFile.WriteLine($"{product!.Trim()}", true);
			}
			Console.WriteLine("Product Saved");
		}
		catch (Exception ex)
		{
			Console.WriteLine("There was an error saving product: " + ex.Message);
		}
	}


	internal List<string> GetProducts()
	{
		var products = new List<string>();

		try
		{
			using (StreamReader reader = new StreamReader(Configuration.docPath))
			{
				var line = reader.ReadLine();
				while (line != null)
				{
					products.Add(line);
					line = reader.ReadLine();
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(UserInterface.divide);
		}
		return products;
	}
}
