using System;

namespace Internet_bank_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            double[][] accountmoney = new double[5][];
            accountmoney[0] = new double[3] { 400, 500, 600 };
            accountmoney[1] = new double[2] { 500, 600 };
            accountmoney[2] = new double[2] { 600, 700 };
            accountmoney[3] = new double[3] { 700, 800, 600 };
            accountmoney[4] = new double[2] { 800, 900 };


            Console.WriteLine("Välkommen till banken");

            string[,] accounts = Users();
            int LoginAttempt = Login(accounts);
            Console.Clear();
            Menu();
            do
            {

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AccountCheck(accountmoney[LoginAttempt]);
                            Menu();
                            break;

                        case 2:
                            AccountCheck(accountmoney[LoginAttempt]);
                            Transfer(accountmoney[LoginAttempt]);


                            break;

                        case 3:
                            AccountCheck(accountmoney[LoginAttempt]);
                            TakeOutCash(accountmoney[LoginAttempt]);
                        
                            break;

                        case 4:
                            Console.Clear();
                            LoginAttempt = Login(accounts);
                            Menu();
                            break;

                    }
                }
                catch (FormatException)
                {

                }
            } while (true);




        }
        public static string[,] Users()
        {
            String[,] User = new string[5, 2];
            User[0, 0] = "user1"; User[0, 1] = "1111";
            User[1, 0] = "user2"; User[1, 1] = "2222";
            User[2, 0] = "user3"; User[2, 1] = "3333";
            User[3, 0] = "user4"; User[3, 1] = "4444";
            User[4, 0] = "user5"; User[4, 1] = "5555";
            return User;
        }
        public static int Login(string[,] Users)
        {


            bool check = false;
            int counter = 0;
            for (int Tries = 0; Tries < 3; Tries++)
            {
                Console.WriteLine("Ange ditt användarnamn");
                string name = Console.ReadLine();
                Console.WriteLine("Ange din pinkod");
                string pincode = Console.ReadLine();

                for (counter = 0; counter <= 4; counter++)
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
            }
            return -2;
        }

            private static void AccountCheck(double[] MoneyAccount)
            {
                Console.Clear();

                if (MoneyAccount.Length == 1)
                {
                    Console.WriteLine($"[1] Lönekonto: {MoneyAccount[0]} kr");
                }

                if (MoneyAccount.Length == 2)
                {
                    Console.WriteLine($"[1] Lönekonto: {MoneyAccount[0]} kr");
                    Console.WriteLine($"[2] Investeringkonto {MoneyAccount[1]} kr");
                }

                if (MoneyAccount.Length == 3)
                {
                    Console.WriteLine($"[1] Lönekonto: {MoneyAccount[0]} kr");
                    Console.WriteLine($"[2] Investeringkonto {MoneyAccount[1]} kr");
                    Console.WriteLine($"[3] Sparkonto: {MoneyAccount[2]} kr");
                }
            }

        private static void Transfer(double[] MoneyAccount)
        {
            Console.WriteLine("Välj kontot du vill överföra från");

            double x = Convert.ToDouble(Console.ReadLine());

            

            if(x == 1)
            {
                Console.WriteLine("Välj kontot du vill överföra till");

                double y = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Hur mycket vill du överföra");

                double TransferMoney = Convert.ToDouble(Console.ReadLine());

                if (y == 1)
                {
                    Console.WriteLine("Du kan inte överföra till samma konto");
                    Environment.Exit(0);
                }
                if (y == 2)
                {
                    double NewBalance2 = MoneyAccount[1] + TransferMoney;
                    Console.WriteLine($"Ditt Investeringskonto har nu {NewBalance2} kr");
                }
                if (y == 3)
                {
                    double NewBalance2 = MoneyAccount[2] + TransferMoney;

                    Console.WriteLine($"Ditt Sparkonto har nu {NewBalance2} kr");
                }

                double NewBalance = MoneyAccount[0] - TransferMoney;

                Console.WriteLine($"Ditt Lönekonto har nu {NewBalance} kr");

                Console.ReadKey();
                Console.Clear();
                Menu();


            }

            if(x == 2)
            {
                Console.WriteLine("Välj kontot du vill överföra till");

                double y = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Hur mycket vill du överföra");

                double TransferMoney = Convert.ToDouble(Console.ReadLine());



                if (y == 1)
                {
                    double NewBalance2 = MoneyAccount[0] + TransferMoney;
                    Console.WriteLine($"Ditt Lönekonto har nu {NewBalance2} kr");
                }
                if (y == 2)
                {
                    Console.WriteLine("Du kan inte överföra till samma konto");
                    Environment.Exit(0);
                }
                if (y == 3)
                {
                    double NewBalance2 = MoneyAccount[2] + TransferMoney;
                    Console.WriteLine($"Ditt Sparkonto har nu {NewBalance2} kr");
                }

                double NewBalance = MoneyAccount[1] - TransferMoney;

                Console.WriteLine($"Ditt Investeringskonto har nu {NewBalance} kr");

                Console.ReadKey();
                Console.Clear();
                Menu();
            }

            if(x == 3)
            {
                Console.WriteLine("Välj kontot du vill överföra till");

                double y = Convert.ToDouble(Console.ReadLine());

                

                Console.WriteLine("Hur mycket vill du överföra");

                double TransferMoney = Convert.ToDouble(Console.ReadLine());

                if (y == 1)
                {
                    double NewBalance2 = MoneyAccount[0] + TransferMoney;
                    Console.WriteLine($"Ditt Lönekonto har nu {NewBalance2} kr");
                }
                if (y == 2)
                {
                    double NewBalance2 = MoneyAccount[1] + TransferMoney;
                    Console.WriteLine($"Ditt Investeringskonto har nu {NewBalance2} kr");
                }
                if (y == 3)
                {
                    Console.WriteLine("Du kan inte överföra till samma konto");
                    Environment.Exit(0);
                }

                double NewBalance = MoneyAccount[2] - TransferMoney;

                Console.WriteLine($"Ditt sparkonto har nu {NewBalance} kr");

                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            
            
        }

        private static void TakeOutCash(double[] MoneyAccount)
        {
            Console.WriteLine("Välj vilket konto du vill ta ut pengar från");

            int x = Convert.ToInt32(Console.ReadLine());

            if (x == 1)
            {
                Console.WriteLine("Hur mycket pengar vill du ta ut?");

                double y = Convert.ToDouble(Console.ReadLine());

                if (y > MoneyAccount[0])
                {
                    Console.WriteLine("Ogiltig Summa");
                    Environment.Exit(0);

                }
                if (MoneyAccount[0] > y)
                {
                    double NewBalance = MoneyAccount[0] - y;

                    //NewBalance = MoneyAccount[0];

                    Console.WriteLine($"Ditt Lönekonto har nu {NewBalance} kr");

                    
                    Menu();
                }
            }

            if (x == 2)
            {
                    Console.WriteLine("Hur mycket pengar vill du ta ut?");

                    double a = Convert.ToDouble(Console.ReadLine());

                    if (a > MoneyAccount[1])
                    {
                        Console.WriteLine("Ogiltig Summa");
                        Environment.Exit(0);

                    }
                    if (MoneyAccount[0] > a)
                    {
                        double NewBalance = MoneyAccount[1] - a;



                        Console.WriteLine($"Ditt Investeringskonto har nu {NewBalance} kr");

                    

                    Menu();
                }
            }

            if (x == 3)
            {
                    Console.WriteLine("Hur mycket pengar vill du ta ut?");

                    double b = Convert.ToDouble(Console.ReadLine());

                    if (b > MoneyAccount[2])
                    {
                        Console.WriteLine("Ogiltig Summa");
                        Environment.Exit(0);

                    }
                    if (MoneyAccount[2] > b)
                    {
                        double NewBalance = MoneyAccount[2] - b;

                        //NewBalance = MoneyAccount[0];

                        Console.WriteLine($"Ditt Sparkonto har nu {NewBalance} kr");

                    
                    Menu();
                    }
                
            }
        }

        
             

            


        
        public static void Menu()
        {
            Console.WriteLine("             Välkommen till banken.           ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|    [1.]  Se dina konton och saldo");
            Console.WriteLine("|    [2.]  Överför mellan konton");
            Console.WriteLine("|    [3.]  Ta ut pengar");
            Console.WriteLine("|    [4.]  Logga ut");
            Console.WriteLine("--------------------------------------");
        }
    }    
}

