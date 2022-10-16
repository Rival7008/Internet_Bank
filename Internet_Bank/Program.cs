using System;

namespace Internet_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static string[,] users()
        {
            String[,] Users = new string[5, 2];
            Users[0, 0] = "user1"; Users[0, 1] = "1111";
            Users[1, 0] = "user2"; Users[1, 1] = "2222";
            Users[2, 0] = "user3"; Users[2, 1] = "3333";
            Users[3, 0] = "user4"; Users[3, 1] = "4444";
            Users[4, 0] = "user5"; Users[4, 1] = "5555";
            return Users;
        }
    }
}
