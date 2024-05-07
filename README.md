# Term Deposit Calculator


The Term Deposit Calculator is a simple console application that calculates the final balance of a term deposit given a principal amount, an annual interest rate, the term in years, and the compounding frequency. The application handles different compounding frequencies including monthly, quarterly, annually, and at maturity.


## How to Run the Code


### Prerequisites
- **.NET SDK (Version 7.0 or later)**
  
### Running the Application

1. **Open your command line interface (CLI).**
2. **Navigate to the project directory.**
3. **Build the project:** `dotnet build`
4. **Run the application:** `dotnet run --project TermDepositCalculator`


### Running the Tests

1. **To run the unit tests, use the following command in the CLI:**
      `dotnet test`

## Assumptions

- Input values (principal, rate, term) are provided by the user and are assumed to be valid numeric values.
- Interest rates are entered as percentages (e.g., 5 for 5%).

## Trade-offs and Design Decisions

- **Simplicity over Complexity**: The application uses a simple console interface to maximize ease of use and understandability.
- **Flexibility in Compounding Options**: Supports various compounding frequencies to demonstrate flexibility in financial calculations.
- **Error Handling**: Basic error handling is implemented to manage non-numeric inputs.

  
## Key Components

- `Program.cs`: Entry point of the application, handles user interaction.
- `TermDepositService.cs`: Contains the core logic for calculating the final amount of the term deposit.
- `TermDepositCalculatorTests.cs`: Contains unit tests for testing the logic in `TermDepositService`.
