using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoader.Model;
using LINQ.HelperMethods;

namespace LINQ
{
    public static class Tasks6
    {
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