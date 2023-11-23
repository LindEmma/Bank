# README **Foxbank**

## **Foxbank**-programmet program is comprised of 14 classes.


***-Program.cs*** creates a new Foxbank object and initiates the program.

***-App.cs*** contains the methods **'Run()'**, **'QuitApp()'** and **'LogOut()'**. The logic for the menu's are within the **'Run()'**-method.

***-Menu.cs*** includes various menus displayed to the user and minor features. **'MenuTitle()'**, **'PrintStartMenu()'**, **'PrintCustomerMenu()'**, **'PrintAdminMenu()'**, **'PressKey()'** and **'ClearTitle()'**.

***-ParseMethods.cs*** is used to read integers/decimal numbers, **'ReadInt()'** or **'ReadDecimal()'**.

***-LoginUser.cs*** is used to create new users. There are already 4 users stored in a list of LoginUsers: "Frida" (Admin), "Tom", "Emma" and "Gustav". Password for all: "Vinter2023".

***-LoginManager.cs*** manages the login with **'Login()'** and **'HandleLogin()'** and checks whether the user is an admin or not, **'isAdmin()'**.

***-AdminMethods.cs*** has a method **'CreateUser()'** that creates new user accounts/LoginUsers.

***-CustomerMethods.cs*** has a method **'CreateAccount()'** that creates new bank accounts. It also contains **'PrintAccountInfo()'** and **'PrintAccountNames()'** methods.

***-BankAccount.cs*** is used to create new bank accounts. It includes the methods **'PrintAccountInfo()'**, **'PrintAccountName()'** and **'HasLoans()'**.

***-Transfer.cs*** allows transferring money between accounts using the method **'TransferOwnAccounts()'**. It also enables viewing transfer history with **'TransferHistory()'**.

***-Loan.cs***

***-TakeLoan.cs*** is used to take loans from the bank using the method **'TakeLoanToAccount()'**. It also includes a method to display the loan, **'PrintLoan()'**.

***-EuroAccount.cs*** inherits from the ***BankAccount*** class. It overrides methods **'PrintAccountInfo()'** and **'PrintAccountName()'**.

***-SavingsAccount.cs*** also inherits from the ***BankAccount*** class. It overrides methods **'PrintAccountInfo()'** and **'PrintAccountName()'**. **'ShowInterest()'** is added to show interest on the savings.
