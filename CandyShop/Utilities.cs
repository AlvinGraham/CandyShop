namespace CandyShop;

internal static class Utilities
{

	internal static int GetDaysSinceOpening()
	{
		DateTime openingDate = new DateTime(2024, 1, 1);
		TimeSpan timeDifference = DateTime.Now - openingDate;

		return timeDifference.Days;
	}


}
