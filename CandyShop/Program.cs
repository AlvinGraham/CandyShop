string docPath = @"C:\Users\grah0\projects\csharpAcademy\CandyShop\CandyShop\history.txt";
bool isMenuRunning = true;
var products = new Dictionary<int, string>();

string[] candyNameSeeds = { "M and Ms", "Mike and Ikes", "Twizzlers", "Jolly Ranchers", "Snickers",
"Bubble Gum", "Laffy Taffy", "Skittles", "Butterfingers", "Peanut Butter Cups"};

// SeedData();

if (File.Exists(docPath))
	LoadData();
else
	SeedData();

while (isMenuRunning)
{
	PrintHeader();

	string usersChoice = Console.ReadLine()!.Trim().ToUpper();
	string menuMessage = "Press any key to Go Back To Main Menu.";

	switch (usersChoice)
	{
		case "A":
			AddProduct("User choice A");
			break;
		case "D":
			DeleteProduct("User choice D");
			break;
		case "V":
			ViewProduct("User choice V");
			break;
		case "U":
			UpdateProduct("User choice U");
			break;
		case "Q":
			SaveProducts();
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

void SeedData()
{
	for (int i = 0; i < candyNameSeeds.Length; i++)
		products.Add(i, candyNameSeeds[i]);
}

string GetMenu()
{
	return "Choose an option\n"
	+ 'V' + " to view products\n"
	+ 'A' + " to add products\n"
	+ 'D' + " to delete products\n"
	+ 'U' + " to update roducts\n"
	+ 'Q' + " to quit\n";
}

int GetDaysSinceOpening()
{
	DateTime openingDate = new DateTime(2024, 1, 1);
	TimeSpan timeDifference = DateTime.Now - openingDate;

	return timeDifference.Days;
}

void UpdateProduct(string message)
{
	Console.WriteLine(message);
}

void ViewProduct(string message)
{
	Console.WriteLine(message);
}

void DeleteProduct(string message)
{
	Console.WriteLine(message);
}

void AddProduct(string message)
{
	Console.WriteLine("What Candy Would you like to add?");
	var product = Console.ReadLine();
	var index = products.Count();
	products.Add(index, product!);
}

void PrintHeader()
{
	var title = "Alvin's Candy Shop";
	var divide = "-----------------------------------";
	var dateTime = DateTime.Now;
	var daysSinceOpening = GetDaysSinceOpening();
	var todaysProfit = 5.5m;
	var targetAchieved = false;
	var menu = GetMenu();


	Console.WriteLine($@"{title}
{divide}
Today's Date {dateTime}
Days since opening: {GetDaysSinceOpening()}
Today's profit: {todaysProfit}
Today's target achieved: {targetAchieved}
{divide}
{menu}");
}

void SaveProducts()
{
	using (StreamWriter outputFile = new StreamWriter(docPath))
	{
		foreach (KeyValuePair<int, string> product in products)
		{
			outputFile.WriteLine($"{product.Key}, {product.Value}");
		}
	}
	Console.WriteLine("Products Save");
}

void LoadData()
{
	using (StreamReader reader = new StreamReader(docPath))
	{
		var line = reader.ReadLine();
		while (line != null)
		{
			string[] parts = line.Split(',');
			products.Add(int.Parse(parts[0]), parts[1]);
			line = reader.ReadLine();
		}
	}
}