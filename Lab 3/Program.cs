using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var ex1 = new Exercice1();
            var ex2 = new ThreadExercice();
            
            ex1.Run();
            ex2.Run();


            

        }
    }
}