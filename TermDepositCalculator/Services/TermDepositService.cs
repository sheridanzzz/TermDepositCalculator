using System;

public class TermDepositService
{
    public double CalculateFinalAmount(double principal, double rate, int term, string freq)
    {
        int compoundPerYear;
        int totalPeriods = 0;

        if (freq == "Monthly")
            compoundPerYear = 12;
        else if (freq == "Quarterly")
            compoundPerYear = 4;
        else if (freq == "Annually")
            compoundPerYear = 1;
        else if (freq == "At Maturity")
        {
            compoundPerYear = 1;  // Compounds once at the end of the term
            totalPeriods = 1;     // Only one compounding period at the end
        }
        else
        {
            compoundPerYear = 0;  // Handles invalid or unrecognized frequencies
            totalPeriods = 0;     // No compounding periods
        }

        if (freq != "At Maturity")
        {
            totalPeriods = term * compoundPerYear;
        }

        double compoundRate;
        if (freq == "At Maturity")
        {
            compoundRate = rate * term;  // Apply the full rate over the entire term
        }
        else
        {
            compoundRate = rate / compoundPerYear;  // Normal calculation for other frequencies
        }

        double finalAmount = principal * Math.Pow(1 + compoundRate, totalPeriods);
        return Math.Round(finalAmount);  // Round to the nearest whole number
    }

    public double ReadDouble(string prompt)
    {
        double value;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid value.");
            Console.Write(prompt);
        }
        return value;
    }

    public int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid value.");
            Console.Write(prompt);
        }
        return value;
    }

    public string ReadFrequency()
    {
        Console.WriteLine("Enter the interest payment frequency:");
        Console.WriteLine("1. Monthly");
        Console.WriteLine("2. Quarterly");
        Console.WriteLine("3. Annually");
        Console.WriteLine("4. At Maturity");
        string frequency = "Annually"; // Default value
        bool validInput = false;

        while (!validInput)
        {
            string input = ReadNonNullString("Choose an option (1-4): ");
            switch (input)
            {
                case "1":
                    frequency = "Monthly";
                    validInput = true;
                    break;
                case "2":
                    frequency = "Quarterly";
                    validInput = true;
                    break;
                case "3":
                    frequency = "Annually";
                    validInput = true;
                    break;
                case "4":
                    frequency = "At Maturity";
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    break;
            }
        }
        return frequency;
    }

    private string ReadNonNullString(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("No input provided. Please try again.");
            }
        } while (input == null);

        return input;
    }
}