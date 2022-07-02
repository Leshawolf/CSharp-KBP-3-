using System;

namespace Laba21_TRPO
{
    class Program
    {
        static void Main(string[] args)
        {
            Users users1 = new Users("Антон","Антонович",32);
            users1.Show();
            Cinema cinema1 = new Cinema(32, "Биг баба бой");
            cinema1.Info_Cinema();
            File file1 = new File(32, "БД.db", "23.12.2003");
        }
    }
}
