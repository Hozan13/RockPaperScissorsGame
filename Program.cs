using System;

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;
            int computerScore = 0;
            int draws = 0;

            Random random = new Random();
            Console.WriteLine("--- Rock-Paper-Scissors Game ---");
            Console.WriteLine("Instructions:");
            Console.WriteLine("Type 'rock', 'paper', or 'scissors' to play.");
            Console.WriteLine("Type 'exit' to quit the game.");
            Console.WriteLine("--------------------------------------");

            while (true)
            {
                Console.WriteLine("\nYour choice (rock, paper, scissors): ");
                string userChoice = Console.ReadLine()?.ToLower();

                if (userChoice == "exit")
                {
                    Console.WriteLine("\n--- Final Score ---");
                    Console.WriteLine($"User: {userScore}, Computer: {computerScore}, Draws: {draws}");

                    if (userScore > computerScore)
                        Console.WriteLine("Congratulations! You won the game!");
                    else if (userScore < computerScore)
                        Console.WriteLine("Computer wins the game! Better luck next time.");
                    else
                        Console.WriteLine("It's a tie! Well played.");

                    Console.WriteLine("Thank you for playing! Goodbye!");
                    break;
                }

                if (!IsValidChoice(userChoice))
                {
                    Console.WriteLine($"'{userChoice}' is not a valid choice. Please type 'rock', 'paper', 'scissors', or 'exit'.");
                    continue;
                }


                string computerChoice = GetComputerChoice(random);
                Console.WriteLine($"Computer chose: {computerChoice}");

                if (userChoice == computerChoice)
                {
                    Console.WriteLine("It's a draw!");
                    draws++;
                }
                else if (IsUserWinner(userChoice, computerChoice))
                {
                    Console.WriteLine("You win!");
                    userScore++;
                }
                else
                {
                    Console.WriteLine("Computer wins!");
                    computerScore++;
                }

                Console.WriteLine("\n--- Current Score ---");
                Console.WriteLine($"User: {userScore} | Computer: {computerScore} | Draws: {draws}");
                Console.WriteLine("----------------------");
            }
        }

        static bool IsValidChoice(string choice)
        {
            return choice == "rock" || choice == "paper" || choice == "scissors";
        }

        static string GetComputerChoice(Random random)
        {
            int computerChoiceIndex = random.Next(3);
            if (computerChoiceIndex == 0)
                return "rock";
            else if (computerChoiceIndex == 1)
                return "paper";
            else
                return "scissors";
        }


        static bool IsUserWinner(string userChoice, string computerChoice)
        {
            return (userChoice == "rock" && computerChoice == "scissors") ||
                   (userChoice == "scissors" && computerChoice == "paper") ||
                   (userChoice == "paper" && computerChoice == "rock");
        }
    }
}
