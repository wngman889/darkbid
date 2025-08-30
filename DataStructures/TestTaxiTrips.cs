namespace Regression_TaxiFarePrediction.DataStructures
{
    internal class SingleTaxiTripSample
    {
        internal static readonly TaxiTrip Trip1 = new TaxiTrip
        {
            //VendorId = "VTS",
            //RateCode = "1",
            //PassengerCount = 1,
            //TripDistance = 10.33f,
            //PaymentType = "CSH",
            //FareAmount = 0 // predict it. actual = 29.5

            UserID = 10,
            ProductID = 1,
            ProductName = "Shoes",
            Brand = "Nike",
            Category = "Men's Fashion",
            Price = 5.5f,
            Rating = 2,
            Color = "Black",
            Size = "L"
        };
    }
}