using System;
using System.Collections.Generic;
using System.Linq;
using DataLoader.Model;
using LINQ.HelperMethods;

namespace LINQ
{
    public static class Tasks
    {
        public static void Task01()
        {
            // vypiste vsetky lietadla, ktorych sa vyrobilo viac ako 5000
            var aircraftUnitsMoreThan5000 = DataContext.Aircrafts
                .Where(c => c.UnitsBuilt > 5000)
                .ToList();

            LinqHelperMethods.WriteResult(aircraftUnitsMoreThan5000, "Aircrafts with more than 5000 units built");



            // vypiste vsetky havarie, ktore sa stali na mieste "Newark, New Jersey" a mali menej ako 5 pasazierov
            var crashesInNewarkAndLessThan5Passengers = DataContext.AirCrashes
                .Where(c => c.Location.Equals("Newark, New Jersey") && c.Aboard < 5)
                .ToList();

            LinqHelperMethods.WriteResult(crashesInNewarkAndLessThan5Passengers, "Crashes in Newark, New Jersey with less than 5 passengers");



            // vypiste vsetky kody spolocnosti, ktore zacinaju cislicou 1, zoradene podla abecedy
            var carrierOrderedCodes = DataContext.Carriers
                .Where(c => c.Code.StartsWith("1"))
                .OrderBy(c => c.Code)
                .ToList();

            LinqHelperMethods.WriteResult(carrierOrderedCodes, "Ordered carrier codes beginning with 1");



            // vypiste prvu havariu pri ktorej zomrelo 10 ludi
            var crashWith10Fatalities = DataContext.AirCrashes
                .First(c => c.Fatalities == 10);

            LinqHelperMethods.WriteResult(crashWith10Fatalities, "First crash with 10 fatalities");



            // vypiste tretiu havariu pri ktorej zomrelo 10 ludi
            var thirdCrashWith10Fatalities = DataContext.AirCrashes
                .Where(c => c.Fatalities == 10)
                .ElementAt(2);

            LinqHelperMethods.WriteResult(thirdCrashWith10Fatalities, "Third crash with 10 fatalities");



            // vypiste priemerny pocet pasazierov lietadiel typu "Lockheed Vega", ktore havarovali
            var avgPassengersOnLockheedVega = DataContext.AirCrashes
                .Where(c => c.AircraftType.Equals("Lockheed Vega"))
                .Average(c => c.Aboard);

            LinqHelperMethods.WriteResult(avgPassengersOnLockheedVega, "Average passengers on Lockheed Vega which crashed");
        }

        public static void Task02()
        {
            // vypiste pocet lietadiel, ktorych vyrobca bola firma "Lockheed Corporation"
            var aircraftsByLockheedCorporation = DataContext.Aircrafts
                .Count(c => c.Manufacturer.Equals("Lockheed Corporation"));

            LinqHelperMethods.WriteResult(aircraftsByLockheedCorporation, "Lockheed aircrafts");



            // Zjistete celkovy pocet evidovanych obeti, nezapomente
            // vyloucit defaultni hodnoty (-1) z dotazu
            var totalFatalitiesCount = DataContext.AirCrashes
                        .Where(crash => crash.Fatalities > 0)
                        .Sum(crash => crash.Fatalities);

            LinqHelperMethods.WriteResult(totalFatalitiesCount, "Total fatalities recorded");



            // najdete nejcetnejsi letadlo (typ s nejvice vyrobenymi kusy),
            // jehoz prvni let se uskutecnil mezi roky 1960 az 1990 vcetne
            var mostCommonAircraft = DataContext.Aircrafts
                    .Where(aircraft =>
                        aircraft.FirstFlight != DateTime.MinValue &&
                        aircraft.FirstFlight.Year >= 1960 &&
                        aircraft.FirstFlight.Year <= 1990
                    )
                    .OrderByDescending((aircraft => aircraft.UnitsBuilt))
                    .First();

            LinqHelperMethods.WriteResult(mostCommonAircraft, "Most common aircraft");



            // zjistete roky, kdy doslo k padu letadel na nasem uzemi (czechoslovakia), 
            // zajistete, aby porovnani retezcu probehlo jako case - insensitive
            var airCrashesInCzechoslovakia = DataContext.AirCrashes
                    .Where(crash => crash.Location.ToLower().Contains("czechoslovakia"))
                    .Select(crash => crash.Date.Year)
                    .ToList();

            LinqHelperMethods.WriteResult(airCrashesInCzechoslovakia, "Years of aircrashes in CzechoSlovakia");



            // rozdelte udaje o leteckych katastrofach dle
            // vyctoveho typu AirCrashClassification (viz popis), 
            // Tip: vyuzijte predpripravene extension metody ClassifyAircrash,
            // kterou naleznete v LinqHelperMethods
            var airCrashesClasification = DataContext.AirCrashes
                    .GroupBy(airCrash => airCrash.Fatalities.ClassifyAircrash())
                    .ToList();

            LinqHelperMethods.WriteResult(airCrashesClasification, "Air crashes classification");



            // vyberte vsechny letadla, jejiz prvni let se uskutecnil v prestupnem roce
            var firstFlightInLeapYear = DataContext.Aircrafts
                    .GroupBy(aircraft => DateTime.IsLeapYear(aircraft.FirstFlight.Year))
                    .ToList();

            // lookup vs dictionary (immutability, KeyNotFoundException)
            LinqHelperMethods.WriteResult(firstFlightInLeapYear, "Aircrafts with first flight in leap year");
        }

        public static void Task03()
        {
            // vypiste minimalnu pocet vyrobenych kusov z prvych 10 lietadiel, ktorych prvy let sa uskutocnil
            // od roku 1964
            var minUnitsBuiltOfFirst10AircraftsFrom1964 = DataContext.Aircrafts
                .Where(c => c.FirstFlight.Year > 1964)
                .Take(10)
                .Min(c => c.UnitsBuilt);

            LinqHelperMethods.WriteResult(minUnitsBuiltOfFirst10AircraftsFrom1964, "Minimal units built of first 10 aircrafts from 1964");



            // Nejdrive sestupne seradte nazvy vyrobcu letadel (Manufacturer), 
            // nasledne vzestupne vypiste typ prvnich deseti letadel
            var aircraftCodesFrom10LastManufacturers = DataContext.Aircrafts
                .OrderByDescending(c => c.Manufacturer)
                .Take(10)
                .OrderBy(c => c.AircraftType)
                .Select(c => c.AircraftType)
                .ToList();

            LinqHelperMethods.WriteResult(aircraftCodesFrom10LastManufacturers, "Aircraft codes from 10 last manufacturers");



            // vypiste vsechny lokace, kde havarovalo nejake letadlo od vyrobce Boeing
            /*
             var boeingAircrashLocations =
                DataContext.Aircrafts
                    .Where(aircraft => aircraft.Manufacturer.Contains("Boeing"))
                    .GroupJoin(DataContext.AirCrashes,
                        aircraft => aircraft.AircraftType,
                        crash => crash.AircraftType,
                        (aircraft, crash) => new { aircraft.AircraftType, crash })
                    .SelectMany(aircraft => aircraft.crash)
                    .Select(airCrash => airCrash.Location)
                    .ToList(); 
             */


            var boeingAircrashLocations = DataContext.Aircrafts
                    .Where(aircraft => aircraft.Manufacturer.Contains("Boeing"))
                    .Join(DataContext.AirCrashes,
                        aircraft => aircraft.AircraftType,
                        crash => crash.AircraftType,
                        (aircraft, crash) => crash)
                    .Select(airCrash => airCrash.Location)
                    .ToList();

            LinqHelperMethods.WriteResult(boeingAircrashLocations, "Boeing aircrash locations2");



            // vypiste pocet obeti a plne nazvy dopravcu u 10
            // nejhorsich leteckych nehod (majici nejvetsi pocet obeti)
            var worstAirCrashes = DataContext.AirCrashes
                .Join(DataContext.Carriers,
                    crash => crash.CarrierCode,
                    carrier => carrier.Code,
                    (crash, carrier) => new { carrier.Name, crash.Fatalities })
                .OrderByDescending(o => o.Fatalities)
                .Take(10)
                .ToList();

            LinqHelperMethods.WriteResult(worstAirCrashes, "Worst 10 air crashes");



            // vypiste vyrobce letadel, ktera havarovala s vice
            // jak 100 lidmi na palube, nezapomente odfiltrovat duplicity
            var manufacturersInvolvedInSevereAirCrashes =
                DataContext.AirCrashes
                    .Where(crash => crash.Fatalities > 100)
                    .Join(DataContext.Aircrafts,
                        crash => crash.AircraftType,
                        aircraft => aircraft.AircraftType,
                        (crash, aircraft) => aircraft.Manufacturer)
                    .Distinct()
                    .ToList();

            LinqHelperMethods.WriteResult(manufacturersInvolvedInSevereAirCrashes, "Manufacturers involved in tragic air crashes");
        }

        public static void Task04()
        {
            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji alespon jedno z 5 nejbeznejsich letadel
            // (cili kterych je nejvice vyrobeno, vsechny typy
            // nemusi byt vyuzivany vsemi spolecnostmi)
            var carriersWithCommonAircrafts =
                DataContext.Aircrafts
                .OrderByDescending(aircraft => aircraft.UnitsBuilt)
                .Take(5)
                .Join(DataContext.AirCrashes,
                    aircraft => aircraft.AircraftType,
                    crash => crash.AircraftType,
                    (aircraft, crash) => new { crash.CarrierCode })
                .Join(DataContext.Carriers,
                    anon => anon.CarrierCode,
                    carrier => carrier.Code,
                    (anon, carrier) => new { carrier.Name })
                .Distinct()
                .ToList();

            LinqHelperMethods.WriteResult(carriersWithCommonAircrafts, "Carriers with 5 common aircrafts ");



            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji alespon jedno z 5 nejbeznejsich letadel
            //  + vypiste i 5 nejpouzivanejsich letadel
            var carriersAndCommonAircrafts =
               DataContext.Aircrafts
               .OrderByDescending(aircraft => aircraft.UnitsBuilt)
               .Take(5)
               .Join(DataContext.AirCrashes,
                   aircraft => aircraft.AircraftType,
                   crash => crash.AircraftType,
                   (aircraft, crash) => new { aircraft.AircraftType, crash.CarrierCode })
               .Join(DataContext.Carriers,
                   anon => anon.CarrierCode,
                   carrier => carrier.Code,
                   (anon, carrier) => new { anon.AircraftType, carrier.Name })
               .ToList();

            LinqHelperMethods.WriteResult(carriersAndCommonAircrafts, "Carriers and 5 common aircrafts ");



            // zjistete kolik procent lidi prezilo v ramci evidovanych dat, v dotazu pouzijte klauzuli Aggregate(...)
            var aggregatedAirCrash =
                    DataContext.AirCrashes
                        .Where(crash => crash.Fatalities > 0 && crash.Aboard > 0)
                        .Aggregate((crash1, crash2) =>
                           new AirCrash
                           {
                               Aboard = crash1.Aboard + crash2.Aboard,
                               Fatalities = crash1.Fatalities + crash2.Fatalities
                           });
            var survivalPercentage =
                (1.0 - aggregatedAirCrash.Fatalities / (double)aggregatedAirCrash.Aboard) * 100;

            LinqHelperMethods.WriteResult(survivalPercentage, "Survival percentage is ");



            // naleznete letecke nehody pro 5 nejcastejsich
            // typu letadel (dle poctu vyrobenych kusu)
            // vysledek ulozte do lookupu kde:
            //   klic je typ letadla
            //   hodnotou je list leteckych nehod
            var airCrashesAccordingTo5CommonAircraftTypes = DataContext.Aircrafts
                .OrderByDescending(aircraft => aircraft.UnitsBuilt)
                .Take(5)
                .GroupJoin(DataContext.AirCrashes,
                    aircraft => aircraft.AircraftType,
                    crash => crash.AircraftType,
                    (aircraft, crashes) => new { aircraft.AircraftType, crashes })
                .ToLookup(anon => anon.AircraftType, anon => anon.crashes);

            LinqHelperMethods.WriteResult(airCrashesAccordingTo5CommonAircraftTypes, "Air crashes according To 5 common aircraft types");
        }

        public static void Task05()
        {
            // pro kazdy typ letadla (v leteckych nehodach) spocitejte
            // celkovy pocet obeti, vysledek ulozte do vhodne datove 
            // struktury, seradte dle poctu obeti a vypiste prvnich
            // 5 typu letadel a celkovy pocet obeti, nezapomente pak 
            // vyloucit pripady, kdy u dane letecke nehody neni znam 
            // typ letadla
            var worst5 = DataContext.AirCrashes
                .Where(crash => !string.IsNullOrWhiteSpace(crash.AircraftType))
                .GroupBy(crash => crash.AircraftType, crash => crash.Fatalities)
                .Select(group => new { AircraftType = group.Key, FatalitiesCount = group.Sum() })
                .OrderByDescending(anon => anon.FatalitiesCount)
                .Take(5)
                .ToDictionary(anon => anon.AircraftType, anon => anon.FatalitiesCount);

            LinqHelperMethods.WriteResult(worst5, "Top 5 number of fatalities for aircraft types");



            // z worst5 vyberte BEZ pouziti Where() ty zaznamy, ktere maji mene nez 3000 obeti
            var specificRange = worst5
                .SkipWhile(pair => pair.Value > 3000)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            LinqHelperMethods.WriteResult(specificRange, "Fatalities (less than 3000) according to plane type");



            // z worst5 vyberte kazdy druhy typ letadla (zacnete prvnim prvkem)
            var everySecond = worst5
                .Select(pair => pair.Key)
                .Where((x, i) => i % 2 == 0)
                .ToList();

            LinqHelperMethods.WriteResult(everySecond, "Every second record according to plane type");



            // z worst5 vyberte zaznam, na nemz se pocet obeti nejvice blizi cislu 4000
            var closestTo4000 = worst5
                .Aggregate((pair1, pair2) => Math.Abs(pair1.Value - 4000) < Math.Abs(pair2.Value - 4000) ? pair1 : pair2);

            LinqHelperMethods.WriteResult(closestTo4000, "Fatalities according to plane type with fatalities closest to 4000: ");



            // z worst5 odeberte vsechny zaznamy letadel typu Douglas
            var worst5WithoutDouglas = worst5
                .Except(worst5.Where(pair => pair.Key.Contains("Douglas")));

            LinqHelperMethods.WriteResult(worst5WithoutDouglas, "Worst 5 fatalities according to plane type without all Douglas planes");
        }

        public static void Task06()
        {
            // naleznete rok, ve kterem se stalo nejvice leteckych nehod
            var yearWithMostAirCrashes =
                DataContext.AirCrashes
                    .GroupBy(
                        airCrash => airCrash.Date.Year,
                        airCrash => airCrash)
                    .Aggregate(
                        (group1, group2) => group1.Count() > group2.Count() ? group1 : group2).Key;

            LinqHelperMethods.WriteResult(yearWithMostAirCrashes, "Year with most air crashes: ");



            //pro nalezeny rok zjistete, kolik stroju od vyrobce Douglas melo v jen za tento rok nehodu
            var douglasAirCrashes =
                DataContext.Aircrafts
                    .Where(aircraft => aircraft.Manufacturer.Contains("Douglas"))
                    .Join(
                        DataContext.AirCrashes.Where(crash => crash.Date.Year == yearWithMostAirCrashes),
                        aircraft => aircraft.AircraftType,
                        crash => crash.AircraftType,
                        (aircraft, crash) => crash)
                     .Count();

            LinqHelperMethods.WriteResult(douglasAirCrashes, $"Douglas air crashes in {yearWithMostAirCrashes}:");



            // naleznete nejtragictejsi rok (vzhledem k poctu obeti)
            var mostTragicYear =
                 DataContext.AirCrashes
                    .GroupBy(
                        airCrash => airCrash.Date.Year,
                        airCrash => airCrash)
                    .Aggregate(
                        (group1, group2) =>
                        group1.Sum(crash => crash.Fatalities) > group2.Sum(crash => crash.Fatalities) ? group1 : group2)
                     .Key;

            LinqHelperMethods.WriteResult(mostTragicYear, "Most tragic year is: ");



            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji letadla od spolecnosti Boeing a Airbus
            // (respektive se u nich eviduje havarie stroje u obou
            // vyse uvedenych vyrobcu)
            // Tip: Dotaz lze vhodne rozdelit na vice dilcich dotazu
            var carriersWithBoeingAircrash =
                DataContext.Aircrafts
                .Where(aircraft => aircraft.Manufacturer.Contains("Boeing"))
                .Join(DataContext.AirCrashes,
                   aircraft => aircraft.AircraftType,
                   crash => crash.AircraftType,
                   (aircraft, crash) => new { aircraft.Manufacturer, crash.CarrierCode })
               .Join(DataContext.Carriers,
                   anon => anon.CarrierCode,
                   carrier => carrier.Code,
                   (anon, carrier) => new { carrier.Name })
               .ToList();

            var carriersWithAirbusAircrash =
                DataContext.Aircrafts
                .Where(aircraft => aircraft.Manufacturer.Contains("Airbus"))
                .Join(DataContext.AirCrashes,
                   aircraft => aircraft.AircraftType,
                   crash => crash.AircraftType,
                   (aircraft, crash) => new { aircraft.Manufacturer, crash.CarrierCode })
               .Join(DataContext.Carriers,
                   anon => anon.CarrierCode,
                   carrier => carrier.Code,
                   (anon, carrier) => new { carrier.Name })
               .ToList();

            var carriersUsingAirbusAndBoeingAircrafts =
                carriersWithBoeingAircrash.Intersect(carriersWithAirbusAircrash)
                .ToList();

            LinqHelperMethods.WriteResult(carriersUsingAirbusAndBoeingAircrafts, "Carriers using Airbus and Boeing aircrafts");
        }
    }
}
