class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Term Deposit Calculator");
        TermDepositService service = new TermDepositService();

        try
        {
            double principal = service.ReadDouble("Enter the start deposit amount ($): ");
            double annualRate = service.ReadDouble("Enter the annual interest rate (%): ") / 100;
            int termYears = service.ReadInt("Enter the investment term (years): ");

            string frequency = service.ReadFrequency();

            double finalAmount = service.CalculateFinalAmount(principal, annualRate, termYears, frequency);
            Console.WriteLine($"The final balance would be: ${finalAmount}, interest paid {frequency}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}