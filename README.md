# README **Foxbank**

## **Foxbank**-programmet är uppbygt av 14 klasser.


***-Program.cs** creates a new Foxbank object and initiates the program.

***-App.cs*** contains the mothods **'Run()'**, **'QuitApp()'** and **'LogOut()'**.

***-Menu.cs*** includes various menus displayed to the user. **'MenuTitle()'**, **'PrintStartMenu()'**, **'PrintCustomerMenu()'**, **'PrintAdminMenu()'**, **'PressKey()'** and **'ClearTitle()'**.

***-ParseMethods.cs*** is used to read integers/decimal numbers, **'ReadInt()'** or **'ReadDecimal()'**.

***-LoginUser.cs*** is used to create new users. There are already 4 users stored in a list of LoginUsers: "Frida" (Admin), "Tom", "Emma" and "Gustav". Password for all: "Vinter2023".

***-LoginManager.cs*** manages the login with **'Login()'** and **'HandleLogin()'** and checks whether the user is an admin or not, **'isAdmin()'**.

***-AdminMethods.cs*** has a method **'CreateUser()'** that creates new LoginUsers.

***-CustomerMethods.cs*** has a method **'CreateAccount()'** that creates new bank accounts. It also contains **'PrintAccountInfo()'** and **'PrintAccountNames()'** methods.

***-BankAccount.cs*** is used to create new bank accounts. It includes the methods **'PrintAccountInfo()'**, **'PrintAccountName()'** and **'HasLoans()'**.

***-Transfer.cs*** allows transferring money between accounts using the method **'TransferOwnAccounts()'**. It also enables viewing transfer history with **'TransferHistory()'**.

***-Loan.cs***

***-TakeLoan.cs***

***-SavingsAccount.cs***

***-EuroAccount.cs***

