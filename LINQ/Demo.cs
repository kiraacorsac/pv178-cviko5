using System.Collections.Generic;
using System.Linq;
using LINQ.HelperMethods;
using System;

namespace LINQ
{
    /// <summary>
    /// LINQ cheatsheet: 
    /// http://nickberardi.com/content/images/2008/02/linq-standard-query-operators.pdf
    /// </summary>
    public static class Demo
    {
        public static void Example()
        {
            // Query syntax
            var accidentsWithMoreThan100Fatalities =
                 from accident in DataContext.AirCrashes
                 where accident.Fatalities > 100
                 select accident;
            LinqHelperMethods.WriteResult(accidentsWithMoreThan100Fatalities, "Accidents with more than 100 fatalities");

            // Lambda syntax
            var accidentsWithMoreThan100PeopleAboard = DataContext.AirCrashes
                .Where(crash => crash.Aboard > 100);

            LinqHelperMethods.WriteResult(accidentsWithMoreThan100PeopleAboard, "Now for something completely the same...");

            // Max
            var mostPeopleAboard = accidentsWithMoreThan100PeopleAboard
                .Max(p => p.Fatalities);
            LinqHelperMethods.WriteResult(mostPeopleAboard, "Worst fatality count within single air crash:");

            // First & OrderBy
            var firstCrashWithSurvivors = DataContext.AirCrashes
                .OrderBy(crash => crash.Date)
                .First(crash => crash.Aboard > crash.Fatalities);
            LinqHelperMethods.WriteResult(firstCrashWithSurvivors, "First crash with survivors: ");

            // Select
            var typesOfAircrafts = DataContext.Aircrafts
                .Select(a => a.AircraftType)
                .Distinct();
            LinqHelperMethods.WriteResult(typesOfAircrafts, "Known aircraft types alphabetically: ");

            // GroupBy
            var crashesByYear = DataContext.AirCrashes
                .GroupBy(crash => crash.Date.Year)
                .Select(g => new { Year = g.Key, Crashes = g.ToList() });
            LinqHelperMethods.WriteResult(crashesByYear, "Number of crashes by year: ");

            // Join
            var crashesWithManufacturers = DataContext.AirCrashes
                .Join(DataContext.Aircrafts,
                    crash => crash.AircraftType,
                    aircraft => aircraft.AircraftType,
                    (crash, aircraft) => new { crash.Description, aircraft.Manufacturer});

            // Agregate
            var sumOfFatalities = DataContext.AirCrashes
                .Aggregate(0, (sum, crash) => sum + crash.Fatalities);

            // Zip
            int[] numbers = { 1, 2, 3, 4, 6 };
            int[] numbers2 = { 5, 2, 1, 3 };
            var largerNumbers = numbers2
                .Zip(numbers, (first, second) => first > second ? first : second);
            LinqHelperMethods.WriteResult(largerNumbers, "Larger numbers from 2 lists");

            var foods = new List<string> { "apple", "juice", "bread" };
            int[] foodNumbers = { 1, 0, 5, 8 };
            var shoppingList = foods
                .Zip(foodNumbers, (food, count) => count + "x " + food);
            LinqHelperMethods.WriteResult(shoppingList, "Shopping list items");
        }
    }
}
