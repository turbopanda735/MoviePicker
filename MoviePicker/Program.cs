using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

namespace MoviePicker
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("We are going to get some choices for movie night!");
            var utilities = new Utilities();
            var movieList = Utilities.GetAllMovies();
            var filteredList = utilities.FindMovieLoop(movieList);
            Utilities.ListMovies(filteredList);
        }
    }
}