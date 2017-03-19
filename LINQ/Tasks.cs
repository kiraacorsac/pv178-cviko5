using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoader.Model;
using LINQ.HelperMethods;

namespace LINQ
{
    public static class Tasks
    {
        public static void Task01()
        {
            // vypiste vsetky lietadla, ktorych sa vyrobilo viac ako 5000
            //var aircraftUnitsMoreThan5000 = TODO: your query goes here

            //LinqHelperMethods.WriteResult(aircraftUnitsMoreThan5000, "Aircrafts with more than 5000 units built");



            // vypiste vsetky havarie, ktore sa stali na mieste "Newark, New Jersey" a mali menej ako 5 pasazierov
            //var crashesInNewarkAndLessThan5Passengers = TODO: your query goes here

            //LinqHelperMethods.WriteResult(crashesInNewarkAndLessThan5Passengers, "Crashes in Newark, New Jersey with less than 5 passengers");



            // vypiste vsetky kody spolocnosti, ktore zacinaju cislicou 1, zoradene podla abecedy
            //var carrierOrderedCodes = TODO: your query goes here

            //LinqHelperMethods.WriteResult(carrierOrderedCodes, "Ordered carrier codes beginning with 1");



            // vypiste prvu havariu pri ktorej zomrelo 10 ludi
            //var crashWith10Fatalities = TODO: your query goes here

            //LinqHelperMethods.WriteResult(crashWith10Fatalities, "First crash with 10 fatalities");



            // vypiste tretiu havariu pri ktorej zomrelo 10 ludi
            //var thirdCrashWith10Fatalities = TODO: your query goes here

            //LinqHelperMethods.WriteResult(thirdCrashWith10Fatalities, "Third crash with 10 fatalities");



            // vypiste priemerny pocet pasazierov lietadiel typu "Lockheed Vega", ktore havarovali
            //var avgPassengersOnLockheedVega = TODO: your query goes here

            //LinqHelperMethods.WriteResult(avgPassengersOnLockheedVega, "Average passengers on Lockheed Vega which crashed");
        }

        public static void Task02()
        {
            // vypiste pocet lietadiel, ktorych vyrobca bola firma "Lockheed Corporation"
            //var aircraftsByLockheedCorporation = TODO: your query goes here

            //LinqHelperMethods.WriteResult(aircraftsByLockheedCorporation, "Lockheed aircrafts");



            // Zjistete celkovy pocet evidovanych obeti, nezapomente
            // vyloucit defaultni hodnoty (-1) z dotazu
            //var totalFatalitiesCount = TODO: your query goes here           

            //LinqHelperMethods.WriteResult(totalFatalitiesCount, "Total fatalities recorded");



            // najdete nejcetnejsi letadlo (typ s nejvice vyrobenymi kusy),
            // jehoz prvni let se uskutecnil mezi roky 1960 az 1990 vcetne
            //var mostCommonAircraft = TODO: your query goes here

            //LinqHelperMethods.WriteResult(mostCommonAircraft, "Most common aircraft");



            // zjistete roky, kdy doslo k padu letadel na nasem uzemi (Czechoslovakia)
            //var airCrashesInCzechoslovakia = TODO: your query goes here

            //LinqHelperMethods.WriteResult(airCrashesInCzechoslovakia, "Years of aircrashes in CzechoSlovakia");



            // rozdelte udaje o leteckych katastrofach dle
            // vyctoveho typu AirCrashClassification, popis naleznete
            // ve slozce Enums, kde je vyctovy typ umisten 
            //var airCrashesClasification = TODO: your query goes here            

            //LinqHelperMethods.WriteResult(airCrashesClasification, "Air crashes classification");



            // vyberte vsechny letadla, jejiz let se uskutecnil v prestupnem roce
            // muze se hodit prvni metoda uvedena v LinqHelperMethods (slozka HelperMethods)
            //var firstFlightInLeapYear = TODO: your query goes here            

            //LinqHelperMethods.WriteResult(firstFlightInLeapYear, "Aircrafts with first flight in leap year");


        }

        public static void Task03()
        {
            // vypiste minimalnu hodnotu vyrobenych kusov z prvych 10 lietadiel, ktorych prvy let sa uskutocnil
            // od roku 1964
            //var minUnitsBuiltOfFirst10AircraftsFrom1964 = TODO: your query goes here 

            //LinqHelperMethods.WriteResult(minUnitsBuiltOfFirst10AircraftsFrom1964, "Minimal units built of first 10 aircrafts from 1964");



            // zoradte nazvy firiem podla abecedy zostupne, nasledne vypiste typy prvych 10 lietadiel zoradenych
            // podla abecedy vzostupne
            //var aircraftCodesFrom10LastManufacturers = TODO: your query goes here 

            //LinqHelperMethods.WriteResult(aircraftCodesFrom10LastManufacturers, "Aircraft codes from 10 last manufacturers");



            // vypiste vsechny lokace, kde havarovalo nejake letadlo od vyrobce Boeing
            //var boeingAircrashLocations = TODO: your query goes here

            //LinqHelperMethods.WriteResult(boeingAircrashLocations, "Boeing aircrash locations");



            // vypiste pocet obeti a plne nazvy dopravcu u 10
            // nejhorsich leteckych nehod (majici nejvetsi pocet obeti)
            //var worstAirCrashes = TODO: your query goes here 

            //LinqHelperMethods.WriteResult(worstAirCrashes, "Worst 10 air crashes");



            // vypiste vyrobce letadel, ktera havarovala s vice
            // jak 100 lidmi na palube, nezapomente odfiltrovat duplicity
            //var manufacturersInvolvedInSevereAirCrashes = TODO: your query goes here

            //LinqHelperMethods.WriteResult(manufacturersInvolvedInSevereAirCrashes, "Manufacturers involved in tragic air crashes");
        }

        public static void Task04()
        {
            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji alespon jedno z 5 nejbeznejsich letadel
            // ne vsechny spolecnosti musi nutne 
            // (cili kterych je nejvice vyrobeno, vsechny typy
            // nemusi byt vyuzivany vsemi spolecnostmi)
            //var carriersWithCommonAircrafts = TODO: your query goes here

            //LinqHelperMethods.WriteResult(carriersWithCommonAircrafts, "Carriers with 5 common aircrafts ");



            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji alespon jedno z 5 nejbeznejsich letadel
            //  + vypiste i 5 nejpouzivanejsich letadel
            //var carriersAndCommonAircrafts = TODO: your query goes here

            //LinqHelperMethods.WriteResult(carriersAndCommonAircrafts, "Carriers and 5 common aircrafts ");



            // zjistete kolik procent lidi prezilo v ramci evidovanych dat
            //var aggregatedAirCrash = TODO: your query goes here

            //var survivalPercentage = TODO: your code goes here

            //LinqHelperMethods.WriteResult(survivalPercentage, "Survival percentage is ");



            // naleznete letecke nehody pro 5 nejcastejsich
            // typu letadel (dle poctu vyrobenych kusu)
            //var airCrashesAccordingTo5CommonAircraftTypes = TODO: your query goes here

            //LinqHelperMethods.WriteResult(airCrashesAccordingTo5CommonAircraftTypes, "Air crashes according To 5 common aircraft types");
        }

        public static void Task05()
        {
            // pro kazdy typ letadla (v leteckych nehodach) spocitejte
            // celkovy pocet obeti, vysledek ulozte do vhodne datove 
            // struktury, seradte dle poctu obeti a vypiste prvnich
            // 50 typu letadel a celkovy pocet obeti
            var fatalitiesPerAircraftType = new Dictionary<string, int>();
            //var planeTypes = TODO: your query goes here

            //var worst50 = TODO: your query goes here 

            //LinqHelperMethods.WriteResult(worst50, "All fatalities according to plane type greater than 100");



            // u worst50 overte, zda vsechny zaznamy maji vice nez 100 obeti
            //var hasMoreThan100 = TODO: your query goes here              

            //LinqHelperMethods.WriteResult(hasMoreThan100, "Are all fatalities according to plane type greater than 100: ");



            // z worst50 vyberte BEZ pouziti Where() ty zaznamy, ktere maji mene nez 2000 obeti
            //var specificRange = TODO: your query goes here

            //LinqHelperMethods.WriteResult(specificRange, "Fatalities (less than 2000) according to plane type");



            // z worst50 vyberte kazdy treti typ letadla (zacnete prvnim prvkem)
            //var everyThird = TODO: your query goes here

            //LinqHelperMethods.WriteResult(everyThird, "Every third record according to plane type");



            // z worst50 vyberte zaznam, na nemz se pocet obeti nejvice blizi cislu 2000
            //var closestTo2000 = TODO: your query goes here

            //LinqHelperMethods.WriteResult(closestTo2000, "Fatalities according to plane type with fatalities closest to 2000: ");



            // z worst50 odeberte vsechny zaznamy letadel typu Douglas
            //var worst50WithoutDouglas = TODO: your query goes here

            //LinqHelperMethods.WriteResult(worst50WithoutDouglas, "Worst 50 fatalities according to plane type without all Douglas planes");
        }

        public static void Task06()
        {
            // naleznete rok, ve kterem se stalo nejvice leteckych nehod
            //var yearWithMostAirCrashes = TODO: your query goes here

            //LinqHelperMethods.WriteResult(yearWithMostAirCrashes, "Year with most air crashes: ");



            //pro nalezeny rok zjistete, kolik stroju od vyrobce Douglas melo nehodu
            //var douglasAirCrashes = TODO: your query goes here

            //LinqHelperMethods.WriteResult(douglasAirCrashes, $"Douglas air crashes in {yearWithMostAirCrashes}:");



            // naleznete nejtragictejsi rok (vzhledem k poctu obeti)
            //var mostTragicYear = TODO: your query goes here

            //LinqHelperMethods.WriteResult(mostTragicYear, "Most tragic year is: ");



            // vypiste plne nazvy leteckych spolecnosti, ktere 
            // pouzivaji letadla od spolecnosti Boeing a Airbus
            // (respektive se u nich eviduje havarie stroje u obou
            // vyse uvedenych vyrobcu)
            // Tip: Dotaz lze vhodne rozdelit na vice dilcich dotazu
            //var carriersUsingAirbusAndBoeingAircrafts = TODO: your query goes here


            //LinqHelperMethods.WriteResult(carriersUsingAirbusAndBoeingAircrafts, "Carriers using Airbus and Boeing aircrafts");
        }
    }
}
