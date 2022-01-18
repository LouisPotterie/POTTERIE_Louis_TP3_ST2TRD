using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab_3
{
    public class Exercice1
    {
        public void Run()
        {
            
            var movieCollection = new MovieCollection();
            
            var oldestTitle = movieCollection.Movies.OrderBy(disneyMovies => disneyMovies.ReleaseDate);
            Console.WriteLine("Display the title of the oldest movie : {0} ",  oldestTitle.First().Title);

            var moviesCount = movieCollection.Movies.Count;
            Console.WriteLine("Count all movies : {0}", moviesCount);

            var numQuery = (from num in movieCollection.Movies where num.Title.Contains("e") select num.Title ).Count() ;
            Console.WriteLine("Count all movies with the letter e. at least once in the title : {0}", numQuery);

            var numQuery2 = from num in movieCollection.Movies where num.Title.Contains("f") select num.Title;
            var countF = 0;
            foreach (var num in numQuery2)
            {
                countF += num.Split('f').Length - 1;
            }
            Console.WriteLine("Count how many time the letter f is in all the titles from this list : {0}", countF);
            
            var budgetCollection = movieCollection.Movies.OrderBy(disneyMovies => disneyMovies.Budget);
            Console.WriteLine("Display the title of the film with the higher budget : {0} ", budgetCollection.Last().Title);

            var lowestBoxOffice = movieCollection.Movies.OrderBy(disneyMovies => disneyMovies.BoxOffice);
            Console.WriteLine("Display the title of the movie with the lowest box office : {0} ", lowestBoxOffice.First().Title);
            
            var reversedAlphabetical = movieCollection.Movies.OrderByDescending(disneyMovies => disneyMovies.Title);
            var reversedA = reversedAlphabetical.Take(11);
            Console.WriteLine("Order the movies by reversed alphabetical order and print the first 11 of the list : ");

            foreach (var movie in reversedA)
            {
                Console.WriteLine(movie.Title);
            }

            var numQuery1980 = (from num in movieCollection.Movies where num.ReleaseDate.Year < 1980 select num.Title).Count();
            Console.WriteLine("Count all the movies made before 1980 : {0} ", numQuery1980);
            
            
            var numQueryVowel = (from num in movieCollection.Movies
                where num.Title[0].Equals('A') || num.Title[0].Equals('E') || num.Title[0].Equals('I') ||
                      num.Title[0].Equals('O') || num.Title[0].Equals('U')
                select num.RunningTime);

            Console.WriteLine("Display the average running time of movies having a vowel as the first letter : {0} ", numQueryVowel.Average());
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Print all movies with the letter H or W in the title, but not the letter I or T.");
            var numQueryMoviesHW = (from num in movieCollection.Movies
                where (num.Title.Contains('H') || num.Title.Contains('W') || num.Title.Contains('h') || num.Title.Contains('w')) && !(num.Title.Contains('i') && num.Title.Contains('t') && num.Title.Contains('I') && num.Title.Contains('T')) select num.Title);
            
            foreach (var movie in numQueryMoviesHW)
            {
                Console.WriteLine(movie);
            }
            
            var numQueryBudgetBox = (from num in movieCollection.Movies select num.Budget/num.BoxOffice);
            var meanBudgetBoxOffice = numQueryBudgetBox.Average();
            Console.WriteLine("Calculate the mean of all Budget / Box Office of every movie ever :  {0} ", meanBudgetBoxOffice);
            Console.WriteLine("Seems to have an absurd value in the result and false the result");
            
            Console.WriteLine("------------------------------------------------");

        }
    }
}