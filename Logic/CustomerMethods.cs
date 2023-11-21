using Bank.Classes;
using Bank.Console_output;

namespace Bank.Logic
{
    internal static class CustomerMethods
    {

        // method that lets the user create a new Account. Adds it to AccountList.
        public static Account CreateAccount(List<Account> AccountList)
        {
            string AccountName = "";
            decimal Balance;

            //Handles the name of the account
            while (String.IsNullOrEmpty(AccountName) || AccountList.Exists(x => x.AccountName == AccountName))
            {
                Console.Write("Vad ska ditt konto heta? ");
                AccountName = Console.ReadLine();
                if (String.IsNullOrEmpty(AccountName))
                {
                    Console.WriteLine("Du måste mata in något\n");
                }
                else if (AccountList.Exists(x => x.AccountName == AccountName))
                {
                    Console.WriteLine("Kontonamnet finns redan, testa ett nytt namn\n");
                }
            }
            //Handles how much money the user wants to add to the account (no limit as of now)
            do
            {
                Console.Write("Hur mycket pengar vill du lägga in på kontot? (SEK) ");
                Balance = ParseMethods.ReadDecimal();
                if (Balance < 0)
                {
                    Menu.ClearTitle();
                    Console.WriteLine("Du kan inte lägga in negativa belopp på kontot, testa igen\n");
                }
            } while (Balance < 0);

            Console.WriteLine("\nKontot har skapats!");
            Menu.PressKey();
            return new Account(Balance, AccountName); //returns new Account

        }
        //Loops through the info for each account, if AccountList is empty there is a message
        public static void PrintAccountInfo(List<Account> AccountList)
        {
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Det finns inga konton");
            }
            else
            {
                int NumberOfAccounts = AccountList.Count;
                Console.WriteLine($"Antal konton: {NumberOfAccounts}\n");

                foreach (var account in AccountList)
                {
                    account.PrintAccountInfo();
                }
            }
            Menu.PressKey();
        }

        // Shows the names only of accounts in AccountLists
        public static void PrintAccountNames(List<Account> accounts)
        {
            foreach (var accountName in accounts)
            {
                accountName.PrintAccountName();
            }
            Console.WriteLine();
        }
        public static decimal TakeLoanToAccount(List<Account> AccountList) //Method that let user take loan
        {
            Console.WriteLine("Välj ett konto att ta ett lån till:");
            PrintAccountNames(AccountList); // Display the names of existing accounts
            Console.Write("Ange kontonamnet för det konto du vill ta ett lån till: "); // Ask the user to select an account
            string selectedAccountName = Console.ReadLine();
            Account selectedAccount = AccountList.Find(account => account.AccountName == selectedAccountName.ToLower());

            if (selectedAccount != null)
            {
                // Display current balance
                Console.WriteLine($"{selectedAccount.AccountName} {selectedAccount.Balance}-SEK");

                // Ask for loan details

                decimal loanAmount;

                // Limit loan to 5 times the current balance
                decimal maxLoanAmount = selectedAccount.Balance * 5;
                do
                {
                    Console.Write($"Ange beloppet du vill låna (max {maxLoanAmount:C}): ");
                    while (!decimal.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0)
                    {
                        Console.WriteLine("Ogiltig inmatning. Ange ett giltigt positivt belopp.");
                        Console.Write($"Ange beloppet du vill låna (max {maxLoanAmount:C}): ");
                    }
                    if (loanAmount > maxLoanAmount)
                    {
                        Console.WriteLine($"Du kan inte låna mer än 5 gånger ditt nuvarande saldo ({maxLoanAmount:C}).");
                    }
                }
                while (loanAmount > maxLoanAmount);

                if (loanAmount <= maxLoanAmount)
                {
                    decimal interestRate = 0.05m;
                    Console.Write("Ange syftet med lånet: ");
                    string loanPurpose = Console.ReadLine();
                    Console.Write("Ange lånetiden i månader: ");
                    int loanDurationMonths;
                    while (!int.TryParse(Console.ReadLine(), out loanDurationMonths) || loanDurationMonths <= 0) //This loop ensures that the user enters a valid positive integer for the loan duration.
                    {
                        Console.WriteLine("Ogiltig inmatning. Ange ett giltigt positivt heltal för lånetid i månader:");
                    }
                    // Create a Loan instance and add it to the selected account
                    TakeLoan loan = new TakeLoan(loanAmount, loanPurpose, loanDurationMonths);
                    selectedAccount.Balance += loanAmount;
                    selectedAccount.Loans.Add(new Loan { Amount = loanAmount, Purpose = loanPurpose, DurationMonths = loanDurationMonths });

                    Console.WriteLine("Lånet har lagts till på kontot. Tryck enter för att se lånedetaljer"); //Display information about the loan
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Lånedetaljer:");
                    Console.WriteLine("Lånekapital: " + loanAmount + "SEK");//Lånekapital
                    Console.WriteLine("Lånesyfte: " + loanPurpose);//Anledning
                    Console.WriteLine("Återbetalningstid i månader: " + loanDurationMonths);//Lånetid
                    decimal payBack = loanAmount * interestRate; //Ränta
                    Console.WriteLine("Ränta på lånet: " + payBack + "SEK"); //Skriv ut ränta på lånet
                    decimal totalPayback = loanAmount + payBack;
                    Console.WriteLine("Totalt att betala tillbaka: " + totalPayback); //Skriv ut totala återbetalningen
                    Console.WriteLine("Måndadskonstad/ " + totalPayback / loanDurationMonths + "SEK");//Månadskostnad

                    Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn");
                    Console.ReadKey();
                    return selectedAccount.Balance;
                    return totalPayback;// Return the new balance after the loan

                }
            }
            else
            {
                Console.WriteLine("Inget konto hittades med det angivna namnet.");
            }

            Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn");
            Console.ReadKey();
            return selectedAccount?.Balance ?? 0; // Assuming selectedAccount can be null

        }
        public static void PrintLoan(List<Account> AccountList) //Method that print accounts with loans
        {
            bool anyAccountHasLoans = false;
            Console.WriteLine("Lånesaldo:");
            foreach (var account in AccountList)
            {
                if (account.HasLoans())
                {
                    anyAccountHasLoans |= true;
                    account.PrintAccountInfo();
                    decimal totalOwed = account.Loans.Sum(loan => loan.Amount + (loan.Amount * 0.05m));
                    Console.WriteLine($"Betala till banken: {totalOwed} SEK");
                    Console.WriteLine("------------------------------------------------");

                }
            }
            if (!anyAccountHasLoans)
            {
                Console.WriteLine("Du har inga lån");
            }
            Console.ReadKey();
        }

    }
}
