using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker
{
    internal class Utilities
    {
        const string csvPath = "movies.csv";
        public static List<Movie> GetAllMovies()
        {
            List<Movie> movieList = new List<Movie>();
            var lines = File.ReadAllLines(csvPath);

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var splitLine = line.Split(",");
                var movie = new Movie()
                {
                    Title = splitLine[0],
                    Genre = splitLine[1],
                    Year = Convert.ToInt32(splitLine[7]),
                    AudienceScorePercentage = Convert.ToInt32(splitLine[3]),
                    CriticScorePercentage = Convert.ToInt32(splitLine[5])
                };
                movieList.Add(movie);
            }
            return movieList;
        }
        public List<Movie> FindMovies(List<Movie> movieList)
        {
            Console.WriteLine("How do you wanna filter these?");
            Console.WriteLine("You can chose to filter by GENRE or RATING...");
            do
            {
                var userInput = Console.ReadLine();
                var validInput = false;
                while (!validInput)
                {
                    if (userInput.ToLower() == "genre")
                    {
                        return FilterByGenre(movieList);
                    }
                    else if (userInput.ToLower() == "rating")
                    {
                        return FilterByRating(movieList);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Let's try again. Enter 'genre' to filter by genre or 'rating' to filter by rating.");
                        break;
                    }
                }
            } while (true);
        }
        public static void ListMovies(List<Movie> movieList)
        {
            foreach (var movie in movieList)
            {
                movie.PrintDetails();
            }
        }
        public List<Movie> FilterByGenre(List<Movie> movieList)
        {
            Console.WriteLine("Ok, let's filter by genre.");
            Console.WriteLine("We have Romance, Comedy, Drama, Animation, Fantasy and Action movies in our database...");
            bool validInput = false;
            do
            {
                while (!validInput)
                {
                    var userInput = Console.ReadLine();
                    switch (userInput.ToLower())
                    {
                        case "romance":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "romance").ToList();
                        case "comedy":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "comedy").ToList();
                        case "drama":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "drama").ToList();
                        case "animation":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "animation").ToList();
                        case "fantasy":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "fantasy").ToList();
                        case "action":
                            validInput = true;
                            return movieList.Where(x => x.Genre.ToLower() == "action").ToList();
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Ok, let's filter by genre. We have Romance, Comedy, Drama, Animation, Fantasy and Action movies in our database...");
                            validInput = false;
                            break;
                    }
                }
            } while (true);
        }
        public List<Movie> FilterByRating(List<Movie> movieList)
        {
            Console.WriteLine("Ok, let's filter by rating.");
            Console.WriteLine("Audience or critic rating?");
            do
            {
                var userInput = Console.ReadLine();
                bool validInput = false;
                string? critic = null;
                string? audience = null;

                while (!validInput)
                {
                    if (userInput.ToLower() == "critic")
                    {
                        validInput = true;
                        critic = "critic";
                    }
                    else if (userInput.ToLower() == "audience")
                    {
                        validInput = true;
                        audience = "audience";
                    }
                    else
                    {
                        validInput = false;
                        Console.WriteLine();
                        Console.WriteLine("Ok, let's try again. Put in either 'critic' to sort by critic ratings or 'audience' to sort by audience ratings.");
                        break;
                    }
                }

                if (critic == "critic")
                {
                    Console.WriteLine("Critics are always wrong. Do you want to filter by movies loved by critics, filter by movies that critics feel neutral about, or filter by movies that are universallly hated by critics?");
                    bool validInput2 = false;

                    while (!validInput2)
                    {
                        var userInput2 = Console.ReadLine();
                        switch (userInput2.ToLower())
                        {
                            case "loved":
                                validInput2 = true;
                                return movieList.Where(x => x.CriticScorePercentage >= 80).ToList();
                            case "neutral":
                                validInput2 = true;
                                return movieList.Where(x => x.CriticScorePercentage >= 50 && x.CriticScorePercentage < 80).ToList();
                            case "hated":
                                validInput = true;
                                return movieList.Where(x => x.CriticScorePercentage < 50).ToList();
                            default:
                                validInput2 = false;
                                Console.WriteLine();
                                Console.WriteLine("Ok, let's try again. Enter either 'loved' to filter by movies loved by critics,'neutral' to filter by movies that critics feel neutral about, or 'hated' to see movies that are universally hated by critics.");
                                break;
                        }
                    }
                }

                else if (audience == "audience")
                {
                    Console.WriteLine("The audience is always wrong. Do you want to filter by movies loved by the audience, filter by movies that the audience feels neutral about, or filter by movies that are universallly hated by the audience?");
                    bool validInput2 = false;

                    while (!validInput2)
                    {
                        var userInput2 = Console.ReadLine();
                        switch (userInput2.ToLower())
                        {
                            case "loved":
                                validInput2 = true;
                                return movieList.Where(x => x.CriticScorePercentage >= 80).ToList();
                            case "neutral":
                                validInput2 = true;
                                return movieList.Where(x => x.CriticScorePercentage >= 50 && x.CriticScorePercentage < 80).ToList();
                            case "hated":
                                validInput = true;
                                return movieList.Where(x => x.CriticScorePercentage < 50).ToList();
                            default:
                                validInput2 = false;
                                Console.WriteLine();
                                Console.WriteLine("Ok, let's try again. Enter either 'loved' to filter by movies loved by the audience,'neutral' to filter by movies that the audience feels neutral about, or 'hated' to see movies that are universally hated by the audience.");
                                break;
                        }
                    }
                }
            } while (true);
        }
        public List<Movie> FindMovieLoop(List<Movie> movieList)
        {
            var filteredList = FindMovies(movieList);
            var doAgain = false;
            Console.WriteLine("Would you like to filter again?");
            do
            {
                var filteredListTwo = new List<Movie>();
                var yesOrNo = Console.ReadLine();
                if (yesOrNo == "yes")
                {
                    return filteredListTwo = FindMovieLoop(filteredList);
                }
                else if (yesOrNo == "no")
                {
                    doAgain = true;
                }
                else
                {
                    Console.WriteLine("Enter yes or no...");
                }
            } while (!doAgain);
            return filteredList; 
        }
    }
}

