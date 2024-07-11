namespace CandyShop;

internal class DataSeed
{
	internal string[] candyNameSeeds = { "M and Ms", "Mike and Ikes", "Twizzlers", "Jolly Ranchers", "Snickers",
"Bubble Gum", "Laffy Taffy", "Skittles", "Butterfingers", "Peanut Butter Cups"};


	internal void SeedData()
	{
		var productController = new ProductController();
		productController.AddProducts(candyNameSeeds.ToList());
	}
}
