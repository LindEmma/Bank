# README **Foxbank**

## **Foxbank**-programmet är uppbygt av 14 klasser.


***Program.cs*** skapar ett nytt Foxbank-objekt och startar programmet.

**App.cs** innehåller metoderna **Run()**, **QuitApp()** och **LogOut()**.

**Menu.cs** innehåller olika menyer som skrivs ut till användaren. **MenuTitle()**, **PrintStartMenu()**, **PrintCustomerMenu()**, **PrintAdminMenu()**, **PressKey()** och **ClearTitle()**.

**ParseMethods.cs** används för att läsa av hel/decimaltal, **ReadInt()** eller **ReadDecimal()**.

**LoginUser.cs** används för att skapa nya användare. Det finns 4 användare redan sparade i en lista av LoginUsers: "Frida" (Admin), "Tom", "Emma" och "Gustav". Lösenord för samtliga: "Vinter2023".

**LoginManager.cs** sköter inloggningen med **Login()** och **HandleLogin()** och kollar om användaren är admin eller inte, **isAdmin()**.

**AdminMethods.cs** har en metod **CreateUser()** som skapar nya LoginUsers.

**CustomerMethods.cs** har en metod **CreateAccount()** som skapar nya nya bank-konton. Det finns även **PrintAccountInfo()** och **PrintAccountNames()** i denna klass.

**BankAccount.cs** används för att skapa nya bank-konton. Där finns metoderna **PrintAccountInfo()**, **PrintAccountName()** samt **HasLoans()**.

**Transfer.cs** gör det möjligt att föra över pengar mellan konton med hjälp av metoden **TransferOwnAccounts()**. Man kan även visa överföringshistorik med **TransferHistory()**.

**Loan.cs**

**TakeLoan.cs**

**SavingsAccount.cs**

**EuroAccount.cs**

