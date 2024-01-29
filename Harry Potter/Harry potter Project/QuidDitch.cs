using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Harry_potter_Project
{
    public class QuidDitch
    {


        public Galtvort galtvort { get; set; }
        public List<character> AwayTeam { get; set; }
        public List<character> HomeTeam { get; set; }

        private int HomeTeamScore { get; set; }

        private int awayTeamScore { get; set; }

        public QuidDitch(Galtvort Galtvort)
        {
            galtvort = Galtvort;
            AwayTeam = new List<character>();
            HomeTeam = galtvort.characters;
            HomeTeamScore = 0;
            awayTeamScore = 0;
            createTeam();

        }

        List<character> createTeam()
        {
            AwayTeam.Add(new character("Didrik", "Gryffindor", "Seeker"));
            AwayTeam.Add(new character("olav", "Gryffindor", "Keeper"));
            AwayTeam.Add(new character("Nils", "Gryffindor", "chaser"));
            AwayTeam.Add(new character("Sile", "Gryffindor", "chaser"));
            AwayTeam.Add(new character("Jan", "Gryffindor", "chaser"));
            AwayTeam.Add(new character("Hannah", "Gryffindor", "beater"));
            AwayTeam.Add(new character("Fiber", "Gryffindor", "beater"));
            return AwayTeam;
        }

        public void PlayGame()
        {
            var Mainrole = HomeTeam.Find(x => x.Role == "Seeker");
            Console.WriteLine("QuidDitch Match");
            Console.WriteLine($"Your role is {Mainrole.Role} and you are now playing as {Mainrole.Name}");
            Console.WriteLine();
            Match(this,this);
        }




        void Match(QuidDitch team1, QuidDitch team2)
        {
            while (!team1.WonMatch() || !team2.WonMatch())
            {
                Console.WriteLine("1. Try To score goal");
                var userinput = Console.ReadLine();
                if (userinput == "1")
                {
                    team1.TryToScoreGoal(IsSuccessful(5));
                }
                else
                {
                    Console.WriteLine("WrongMove");
                }

                team2.TryToScoreGoal(IsSuccessful(5));
                team1.TryToCatchSnitch(IsSuccessful(10));
                team2.TryToCatchSnitch(IsSuccessful(10));
           

               

                PrintScore(team1, team2);
            }
        }

        bool IsSuccessful(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(0, maxValue) == 2;

        }


        bool WonMatch()
        {
                return HomeTeamScore >= 100 || awayTeamScore >= 100;
        }




        void PrintScore(QuidDitch team1, QuidDitch team2)
        {
            Console.WriteLine($"HomeTeam Score: {team1.HomeTeamScore}, AwayTeam Score: {team2.awayTeamScore}");
            Console.WriteLine();
        }


        void TryToCatchSnitch(bool isSuccessful)
        {
            var HomeTeamSeeker = HomeTeam.Find(x => x.Role == "Seeker");
            var awayTeamSeeker = AwayTeam.Find(x => x.Role == "Seeker");
            if (isSuccessful)
            {
                if (HomeTeamSeeker != null)
                {
                    HomeTeamScore += 100;
                    Console.WriteLine();
                    Console.WriteLine($"Name: {HomeTeamSeeker.Name} Role: {HomeTeamSeeker.Role} tried too catch snitch and Scored a Goal");
                    Console.WriteLine($"HomeTeam score: {HomeTeamScore}");
                    Console.WriteLine($"HomeTeam wins the game!");
                 
                }

                if (awayTeamSeeker != null)
                {
                    awayTeamScore += 100;
                    Console.WriteLine();
                    Console.WriteLine($"Name: {awayTeamSeeker.Name} Role: {awayTeamSeeker.Role} tried too catch snitch and  Scored a Goal");
                    Console.WriteLine($"AwayTeam score: {awayTeamScore}");
                    Console.WriteLine($"AwayTeam wins the game!");
                }
            }
        }





        void TryToScoreGoal(bool isSuccessful)
            {
                 Random rand = new Random();
                 var randomScoreHomeTeam = rand.Next(1, 5);
                 var RandomScoreAwayTeam = rand.Next(1, 5);
                 var HomeTeamSeeker = HomeTeam.Find(x => x.Role == "Seeker");
                 var awayTeamSeeker = AwayTeam.Find(x => x.Role == "Seeker");
                if (isSuccessful)
                {
                    if (HomeTeamSeeker != null)
                    {
                         HomeTeamScore += randomScoreHomeTeam;
                         Console.WriteLine($"Name: {HomeTeamSeeker.Name} Role: {HomeTeamSeeker.Role} Tried too score a Goal");
                         Console.WriteLine($"HomeTeam Score {HomeTeamScore}");
                    }

                    if (awayTeamSeeker != null)
                    {
                        awayTeamScore += RandomScoreAwayTeam;
                        Console.WriteLine($"Name: {awayTeamSeeker.Name} Role: {awayTeamSeeker.Role} Tried too score a Goal");
                        Console.WriteLine($"AwayTeam Score: {awayTeamScore}");
                    }
                }

                if (isSuccessful == false)
                {
                    if (HomeTeamSeeker != null)
                    {
                        Console.WriteLine($"HomeTeam {HomeTeamSeeker.Name} Missed the goal");
                    }

                    if (awayTeamSeeker != null)
                    {
                        Console.WriteLine($"AwayTeam {awayTeamSeeker.Name} missed the goal ");
                    }
                }
            }
        }
}




