using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker
{
    public class Movie
    {
        public string Title {get; set;}
        public string Genre {get; set;}
        public int Year {get; set;}
        public int CriticScorePercentage {get; set;}
        public int AudienceScorePercentage { get; set; }
        public void PrintDetails()
        {
            Console.WriteLine($"Your movie is ready. You can watch --{Title} ({Year})--");
            Console.WriteLine($"It's a {Genre.ToUpper()} movie that got a {CriticScorePercentage}% from critics" +
                $" and a {AudienceScorePercentage}% from the audience");
            Console.WriteLine();
        }
    }
}
