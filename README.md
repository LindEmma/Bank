# README **Foxbank**

## The **Foxbank** program is comprised of 12 classes.


***-Program.cs*** creates a new Foxbank object and initiates the program.

***-App.cs*** contains the methods **'Run()'**, **'QuitApp()'** and **'LogOut()'**. The logic for the menu's are within the **'Run()'**-method.

***-Menu.cs*** includes various menus displayed to the user and minor features. **'MenuTitle()'**, **'PrintStartMenu()'**, **'PrintCustomerMenu()'**, **'PrintAdminMenu()'**, **'PressKey()'** and **'ClearTitle()'**.

***-ParseMethods.cs*** is used to read integers/decimal numbers, **'ReadInt()'** or **'ReadDecimal()'**.

***-LoginUser.cs*** is used to create new users. There are already 4 users stored in a list of LoginUsers: "Frida" (Admin), "Tom", "Emma" and "Gustav". Password for all: "Vinter2023".

***-LoginManager.cs*** manages the login with **'Login()'** and **'HandleLogin()'** and checks whether the user is an admin or not, **'isAdmin()'**.

***-AdminMethods.cs*** has a method **'CreateUser()'** that creates new user accounts/LoginUsers.

***-OpenAccount.cs*** has a method **'OpenCheckingsAccount()'** that creates the users main bank account. After the first account is made, new savings accounts can be made with method **'OpenSavingsAccount'**. The class also contains **'PrintAccountInfo()'** and **'PrintAccountNames()'** methods.

***-BankAccount.cs*** is used to create new bank accounts. It includes the methods **'PrintAccountInfo()'**, **'PrintAccountName()'** and **'HasLoans()'**.

***-Transfer.cs*** allows transferring money between accounts using the method **'TransferOwnAccounts()'**. It also enables viewing transfer history with **'TransferHistory()'**.

***-Loan.cs*** is used to create new loans.

***-TakeLoan.cs*** is used to take loans from the bank using the method **'TakeLoanToAccount()'**. It also includes a method to display the loan, **'PrintLoan()'**.
