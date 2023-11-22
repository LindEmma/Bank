README Bank

Foxbank-programmet är uppbygt av 11 klasser.
Program.cs startar programmet.
App.cs innehåller metoderna QuitApp(), LogOut() och Run().
LoginUser.cs används för att skapa nya användare. Det finns 4 användare redan sparade i en lista av LoginUsers: "Frida" (Admin), "Tom", "Emma" och "Gustav". Lösenord för samtliga: "Vinter2023".
LoginManager.cs sköter inloggningen med Login() och HandleLogin() och kollar om användaren är admin eller inte, isAdmin().
AdminMethods.cs har en metod CreateUser() som skapar nya LoginUsers.
CustomerMethods.cs har en metod som skapar nya
