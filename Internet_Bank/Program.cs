using System;
using System.Text;

namespace Internet_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            int Users = 0;

            // Jagged Array with the users money accounts
            double[][] accountmoney = new double[5][];
            accountmoney[0] = new double[3] { 390.23, 22320.33, 1023220.43 };
            accountmoney[1] = new double[2] { 2334.44, 434542.65 };
            accountmoney[2] = new double[2] { 5443.32, 10000 };
            accountmoney[3] = new double[3] { 2934.48, 12374.94, 74323.20 };
            accountmoney[4] = new double[2] { 1232.46, 187364.24 };

            // Array that saves user input that is being used in different methods.
            string[] ChoiceSaver = { "", "", "" };

            for (int phase = 0; phase <= 2; phase++) // tracks what phase in the bank we are in
            {
                if (phase != -1 && Users != -2) // checker to see if the user is allowed in the bank
                {
                    switch (phase)
                    {
                        case 0:
                            welcome();
                            break;
                        case 1:
                            string[,] accounts = users();
                            Users = login(accounts);
                            break;
                        case 2:
                            int pick = Menu(Users);
                            switch (pick)
                            {
                                case 1:
                                    AccountCheck(accountmoney[Users]);
                                    phase = MenuReturn();
                                    break;
                                case 2:
                                    AccountCheck(accountmoney[Users]);
                                    (phase, ChoiceSaver[0]) = From(accountmoney[Users], 1);
                                    if (phase == -2) { break; }
                                    (phase, ChoiceSaver[1]) = To(accountmoney[Users], ChoiceSaver);
                                    if (phase == -2) { break; }
                                    (phase, ChoiceSaver[2]) = Amount(accountmoney[Users], ChoiceSaver, 1);
                                    if (phase == -2) { break; }
                                    Message(accountmoney[Users], ChoiceSaver, 1);
                                    (phase) = PinCode(Users);
                                    if (phase == -2) { break; }
                                    ValueUpdater(accountmoney[Users], ChoiceSaver, 1);
                                    AccountCheck(accountmoney[Users]); phase = MenuReturn();
                                    break;
                                case 3:
                                    AccountCheck(accountmoney[Users]);
                                    (phase, ChoiceSaver[0]) = From(accountmoney[Users], 2);
                                    if (phase == -2) { break; }
                                    (phase, ChoiceSaver[2]) = Amount(accountmoney[Users], ChoiceSaver, 2);
                                    if (phase == -2) { break; }
                                    Message(accountmoney[Users], ChoiceSaver, 2);
                                    (phase) = PinCode(Users);
                                    if (phase == -2) { break; }
                                    ValueUpdater(accountmoney[Users], ChoiceSaver, 2);
                                    AccountCheck(accountmoney[Users]); phase = MenuReturn();
                                    break;
                                case 4:
                                    Console.Clear();
                                    phase = -1;
                                    break;
                            }
                            break;
                    }
                }
                else // Throws the user out of the bank.
                {
                    break;
                }
            }
        }
        public static void welcome() //Writes out a welcome message to the bank
        {
            Console.WriteLine("Välkommen till banken");
        }

        public static string[,] users() // Stores the accounts in a 2d string array
        {
            String[,] Users = new string[5, 2];
            Users[0, 0] = "user1"; Users[0, 1] = "1111";
            Users[1, 0] = "user2"; Users[1, 1] = "2222";
            Users[2, 0] = "user3"; Users[2, 1] = "3333";
            Users[3, 0] = "user4"; Users[3, 1] = "4444";
            Users[4, 0] = "user5"; Users[4, 1] = "5555";
            return Users;
        }

        public static int login(string[,] Users) // Login method for the users if it is succesful it returns the user position in the array if unsuccesful it returns -1
        {
            try
            {
                bool check = false;
                int counter = 0;
                for (int Tries = 0; Tries < 3; Tries++) // counter for how many times the user has tried to login
                {
                    Console.WriteLine("Ange ditt användarnamn:");
                    var name = Console.ReadLine().ToLower();
                    Console.WriteLine("Ange din pinkod");
                    var pincode = Console.ReadLine();

                    for (counter = 0; counter <= 4; counter++) // Loop that goes through all the accounts and tries to find one that match with the users input
                    {
                        check = (name == Users[counter, 0] && pincode == Users[counter, 1]) ? true : false;
                        if (check == true)
                        {
                            int user = counter;
                            return counter;
                        }
                        else if (counter == 4 && check == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Fel användarnamn eller pinkod");
                        }
                    }
                    if (Tries == 2 && check == false) // if the user fails to login in 3 tries it returns the value -1
                    {
                        Console.WriteLine("Du har försökt logga in för många gånger!");
                        return -2; //return -2 because the loop adds 1 value
                    }
                }
                return -2; // any other exception is taken here
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2; // any other exception is taken here
            }
        }
        public static int Menu(int users) // Lists the 4 diffrent menus and lets the user choose an option
        {
            for (int WelcomeMessage = 0; WelcomeMessage < 1; WelcomeMessage++)
            {
                Console.Clear();
                switch (users)
                {
                    case 0:
                        Console.WriteLine("Välkommen till banken user1!");
                        break;
                    case 1:
                        Console.WriteLine("Välkommen till banken user2");
                        break;
                    case 2:
                        Console.WriteLine("Välkommen till banken user3");
                        break;
                    case 3:
                        Console.WriteLine("Välkommen till banken user4");
                        break;
                    case 4:
                        Console.WriteLine("Välkommen till banken user5");
                        break;
                }
            }
            string[] bankMenu = { "\n1. Se dina konton och saldo", "2. Överföring mellan konto", "3.Ta ut pengar", "4. Logga ut\n" };
            foreach (string list in bankMenu) Console.WriteLine(list);

            for (int Tries = 0; Tries <3; Tries++) // counter for how many times the user has tried to login
            {
                string choice = Console.ReadLine();
                for (int counter = 0; counter <1; counter++) // Loop that checks if the user input matches with any of the options
                {

                    try
                    {
                        if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                        {
                            return int.Parse(choice);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val!\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return -2; // any other exception is taken here
                    }
                }
                if (Tries == 2)
                {
                    Console.WriteLine("Du har försökt för många gånger");
                    return -2;
                }
            }
            return -2; // any other exception is taken here
        }
        private static void AccountCheck(double[] MoneyAccount) // Writes out a specific users accounts depending on how many accounts they have.
        {
            Console.Clear();
            if (MoneyAccount.Length == 1) // If the user has 1 account.
            {
                StringBuilder user0 = new StringBuilder("[1] Lönekonto: ");
                user0.AppendFormat("{0:C}", MoneyAccount[0]);
                Console.WriteLine(user0.ToString());
            }
            if (MoneyAccount.Length == 2) // If the user has 2 accounts.
            {
                StringBuilder user0 = new StringBuilder("[1] Lönekonto: ");
                user0.AppendFormat("{0:C}", MoneyAccount[0]);
                Console.WriteLine(user0.ToString());
                StringBuilder user00 = new StringBuilder("[2] Investeringssparkonto: ");
                user00.AppendFormat("{0:C}", MoneyAccount[1]);
                Console.WriteLine(user00.ToString());
            }
            if (MoneyAccount.Length == 3) // If the user has 3 accounts.
            {
                StringBuilder user0 = new StringBuilder("[1] Lönekonto: ");
                user0.AppendFormat("{0:C}", MoneyAccount[0]);
                Console.WriteLine(user0.ToString());
                StringBuilder user00 = new StringBuilder("[2] Investeringssparkonto: ");
                user00.AppendFormat("{0:C}", MoneyAccount[1]);
                Console.WriteLine(user00.ToString());
                StringBuilder user000 = new StringBuilder("[3] Sparkonto: ");
                user000.AppendFormat("{0:C}", MoneyAccount[2]);
                Console.WriteLine(user000.ToString());
            }

        }
        public static int MenuReturn()
        {
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn:");
            for (int Tries = 0; Tries < 3; Tries++) // Loop taht returns the user to the menu if enter is pressed, if wrong input is typed more then 3 times the user is thrown back out of the bank.
            {
                try
                {
                    if (Console.ReadLine() == "")
                    {
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Ogilltigt val!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -2; // Anny extra exception is captured here.
                }
                if (Tries == 2)
                {
                    Console.WriteLine("För många försök!");
                    return -2;
                }
            }
            return -2; // Anny extra exception is captured here.
        }
        public static (int, string) From(double[] MoneyAccount, int Decider) // Takes the user input on witch account they want to Transfer or Withdraw from.
        {
            int From1 = 0;
            int error = 0;
            int error2 = 0;
            string[] PickSaver = { "" };

            for (int attempt = 0; attempt <= 2; attempt++)
            {
                try
                {
                    if (Decider == 1) { Console.Write("\nÖverför från:"); }
                    else { Console.Write("\nTa ut från:"); }
                    From1 = int.Parse(Console.ReadLine());
                    error2 = 0;
                    if (error == 3)
                    {
                        return (-2, PickSaver[0]);
                    }
                }
                catch
                {
                    if (attempt != 2)
                    {
                        Console.WriteLine("Ogilltig summa!");
                        error++;
                        error2++;
                    }
                }
                if (From1 > 0 && From1 <= MoneyAccount.Length)
                {
                    PickSaver[0] = From1.ToString();
                    return (0, PickSaver[0]);
                }
                else if (attempt == 2)
                {
                    Console.WriteLine("För många försök!");
                    return (-2, PickSaver[0]);
                }
                else
                {
                    if (error2 < 1)
                    {
                        Console.WriteLine("Ogilltigt konto!");
                    }
                }
            }
            return (-2, PickSaver[0]); // Anny extra exception is captured here.
        }
        public static (int, string) To(double[] MoneyAccount, string[] ChoiceSaver) // Takes the user input on witch account they want to Transfer to.
        {
            int From = int.Parse(ChoiceSaver[0]);
            int To = 0;
            int error = 0;
            int error2 = 0;

            for (int attempt = 0; attempt <= 2; attempt++)
            {
                try
                {
                    Console.Write("\nÖverför till:");
                    To = int.Parse(Console.ReadLine());
                    error2 = 0;
                    if (error == 3)
                    {
                        return (-2, ChoiceSaver[1]);
                    }
                }
                catch
                {
                    if (attempt != 2)
                    {
                        Console.WriteLine("Ogilltigt konto!");
                        error++;
                        error2++;
                    }
                }
                if (To > 0 && To <= MoneyAccount.Length && To != From)
                {
                    ChoiceSaver[1] = To.ToString();
                    return (0, ChoiceSaver[1]);
                }
                else if (attempt == 2)
                {
                    Console.WriteLine("För många försök!");
                    return (-2, ChoiceSaver[1]);
                }
                else
                {
                    if (error2 < 1)
                    {
                        Console.WriteLine("Ogilltigt konto!");
                    }
                }
            }
            return (-2, ChoiceSaver[1]); // Anny extra exception is captured here.
        }
        public static (int, string) Amount(double[] MoneyAccount, string[] PickSaver, int Decider) // Takes the user input on the amount that is getting Transfered or Withdrawn.
        {
            int From = int.Parse(PickSaver[0]);
            if (Decider == 1) { int To = int.Parse(PickSaver[1]); }
            double amount = Math.Round(0.00, 2);
            int error = 0;
            int error2 = 0;

            for (int attempt = 0; attempt <= 2; attempt++)
            {
                try
                {
                    Console.Write("\nAmount: ");
                    amount = Math.Round(double.Parse(Console.ReadLine()), 2);
                    error2 = 0;
                    if (error == 3)
                    {
                        return (-2, PickSaver[2]);
                    }
                }
                catch
                {
                    if (attempt != 2)
                    {
                        Console.WriteLine("Ogilltig summa!");
                        error++;
                        error2++;
                    }

                }
                switch (From)
                {
                    case 1:
                        if (amount < MoneyAccount[0] && amount > 0)
                        {
                            PickSaver[2] = amount.ToString();
                            return (2, PickSaver[2]);
                        }
                        break;
                    case 2:
                        if (amount < MoneyAccount[1] && amount > 0)
                        {
                            PickSaver[2] = amount.ToString();
                            return (2, PickSaver[2]);
                        }
                        break;
                    case 3:
                        if (amount < MoneyAccount[2] && amount > 0)
                        {
                            PickSaver[2] = amount.ToString();
                            return (2, PickSaver[2]);
                        }
                        break;
                }
                if (error2 < 1)
                {
                    Console.WriteLine("Ogilltig summa!");
                }
                else if (attempt == 2)
                {
                    Console.WriteLine("För många försök!");
                    return (-2, PickSaver[2]);
                }
            }
            return (-2, PickSaver[2]); // Anny extra exception is captured here.
        }

        public static void Message(double[] MoneyAccount, string[] PickSaver, int Decider) // Writes a message that tells the user what is about to happen based on the users earlier inputs. 
        {
            int From = int.Parse(PickSaver[0]);
            double amount = double.Parse(PickSaver[2]);

            if (Decider == 1)
            {
                int To = int.Parse(PickSaver[1]);
                StringBuilder user0 = new StringBuilder("Du kommer överföra ");
                user0.AppendFormat("{0:C}", amount);
                user0.AppendFormat(" till {0}", To);
                Console.WriteLine(user0.ToString());
            }
            else
            {
                StringBuilder user0 = new StringBuilder("Du kommer ta ut ");
                user0.AppendFormat("{0:C}", amount);
                user0.AppendFormat(" från {0}", From);
                Console.WriteLine(user0.ToString());
            }
        }
        public static int PinCode(int Users) // The user needs to enter their pincode to confirm the change. 
        {
            for (int Tries = 0; Tries <= 2; Tries++)
            {
                int pin = 0;
                int error = 0;
                int error2 = 0;

                try
                {
                    Console.WriteLine("Bekräfta genom att ange din pinkod:");
                    pin = int.Parse(Console.ReadLine());
                    error2 = 0;
                    if (error == 3)
                    {
                        return -2;
                    }
                }
                catch
                {
                    if (Tries != 2)
                    {
                        Console.WriteLine("Ogilltigt format!");
                        error++;
                        error2++;
                    }
                }

                switch (Users)
                {
                    case 0:
                        if (pin == 1111) { Console.Clear(); Console.WriteLine("Lyckad ändring!"); return 2; }
                        break;
                    case 1:
                        if (pin == 2222) { Console.Clear(); Console.WriteLine("Lyckad ändring!"); return 2; }
                        break;
                    case 2:
                        if (pin == 3333) { Console.Clear(); Console.WriteLine("Lyckad ändring!"); return 2; }
                        break;
                    case 3:
                        if (pin == 4444) { Console.Clear(); Console.WriteLine("Lyckad ändring!"); return 2; }
                        break;
                    case 4:
                        if (pin == 5555) { Console.Clear(); Console.WriteLine("Lyckad ändring!"); return 2; }
                        break;
                }
                if (error2 < 1)
                {
                    Console.WriteLine("Ogilltig pinkod!");
                }
                else if (Tries == 2)
                {
                    Console.WriteLine("För många försök!");
                    return -2;
                }
            }
            return -2;
        }
        public static void ValueUpdater(double[] MoneyAccount, string[] PickSaver, int Decider) // Updates the values, Decider == 1 is if you Transfered and Decider == 2 is if you Withdrawed.
        {
            int From = int.Parse(PickSaver[0]);
            double amount = double.Parse(PickSaver[2]);

            if (Decider == 1)
            {
                int To = int.Parse(PickSaver[1]);
                MoneyAccount[From - 1] = MoneyAccount[From - 1] - amount;
                Console.WriteLine(MoneyAccount[From - 1]);
                MoneyAccount[To - 1] = MoneyAccount[To - 1] + amount;
                Console.WriteLine(MoneyAccount[To - 1]);
            }
            else
            {
                MoneyAccount[From - 1] = MoneyAccount[From - 1] - amount;
                Console.WriteLine(MoneyAccount[From - 1]);
            }
        }
    }
}

    

