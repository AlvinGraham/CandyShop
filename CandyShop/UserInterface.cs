namespace CandyShop;

internal static class UserInterface
{
	internal const string divide = "-----------------------------------";


	internal static void RunMainMenu()
	{
		ProductController productController = new ProductController();
		bool isMenuRunning = true;

		while (isMenuRunning)
		{
			PrintHeader();

			string usersChoice = Console.ReadLine()!.Trim().ToUpper();
			string menuMessage = "Press any key to Go Back To Main Menu.";

			switch (usersChoice)
			{
				case "A":
					productController.AddProduct();
					break;
				case "D":
					productController.DeleteProduct("User choice D");
					break;
				case "V":
					var products = productController.GetProducts();
					ViewProduct(products);
					break;
				case "U":
					productController.UpdateProduct("User choice U");
					break;
				case "Q":
					menuMessage = "Goodbye";
					isMenuRunning = false;
					break;
				default:
					Console.WriteLine("Invalid choice. Please choose one of the above");
					break;
			}

			Console.WriteLine(menuMessage);
			Console.ReadKey(false);
			Console.Clear();
		}
	}

	private static string GetMenu()
	{
		return "Choose an option\n"
		+ 'V' + " to view products\n"
		+ 'A' + " to add products\n"
		+ 'D' + " to delete products\n"
		+ 'U' + " to update roducts\n"
		+ 'Q' + " to quit\n";
	}

	internal static void PrintHeader()
	{
		var title = "Alvin's Candy Shop";

		var dateTime = DateTime.Now;
		var daysSinceOpening = Utilities.GetDaysSinceOpening();
		var todaysProfit = 5.5m;
		var targetAchieved = false;
		var menu = GetMenu();


		Console.WriteLine($@"{title}
{divide}
Today's Date {dateTime}
Days since opening: {Utilities.GetDaysSinceOpening()}
Today's profit: {todaysProfit}
Today's target achieved: {targetAchieved}
{divide}
{menu}");
	}

	internal static void ViewProduct(List<string> products)
	{
		foreach (var product in products)
		{
			Console.WriteLine(product);
		}
		Console.WriteLine(divide);
	}
}
