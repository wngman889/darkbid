
using Microsoft.ML.Data;

namespace Regression_TaxiFarePrediction.DataStructures
{
    public class TaxiTrip
    {
        [LoadColumn(0)]
        public int UserID;

        [LoadColumn(1)]
        public int ProductID;

        [LoadColumn(2)]
        public string ProductName;

        [LoadColumn(3)]
        public string Brand;

        [LoadColumn(4)]
        public string Category;

        [LoadColumn(5)]
        public float Price;

        [LoadColumn(6)]
        public float Rating;

        [LoadColumn(7)]
        public string Color;

        [LoadColumn(8)]
        public string Size;


    }
}