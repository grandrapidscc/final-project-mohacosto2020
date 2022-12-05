using static System.Net.Mime.MediaTypeNames;

namespace Wizert
{
    internal class Program
    {
        static int getChoice(int min, int max)
        {
            bool okay = false;
            int choice = -1;
            while (!okay)
            {
                Console.Write("Enter choice (" + min + " - " + max + "): ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= min && choice <= max)
                        okay = true;
                }
            }
            return choice;
        }

        static Cell[][] initDungeon()
        {
            Cell[][] dungeon = new Cell[5][];
            int count = 0;
            int next = 0;
            int nextp = 0;
            for (int i = 0; i < 5; i++)
            {
                dungeon[i] = new Cell[5];
                for (int j = 0; j < 5; j++)
                {
                    dungeon[i][j] = new Cell("A cell in the dungeon");
                    count++;
                    if (count % 2 == 0)
                    {
                        if (next == 0)
                        {
                            dungeon[i][j].Enemy = new Banshee();
                        }
                        else if (next == 1)
                        {
                            dungeon[i][j].Enemy = new Orc();
                        }
                        else if (next == 2)
                        {
                            dungeon[i][j].Enemy = new Goblin();
                        }
                        next++;
                        if (next > 2)
                            next = 0;
                    }
                    if (count % 3 == 0)
                    {
                        if (next == 0)
                        {
                            dungeon[i][j].Potion = new HealthPotion();
                            next = 1;
                        }
                        else
                        {
                            dungeon[i][j].Potion = new MagickaPotion();
                            next = 0;
                        }
                    }
                }
            }


            return dungeon;
        }

        static void Main(string[] args)
        {
            Cell[][] dungeon = initDungeon();
            Console.WriteLine("Welcome to the dungeon");
            bool done = false;
            Random rand = new Random();
            int choice;
            while (!done)
            {
                Wizert wizert = new Wizert();
                Location loc = new Location(rand.Next(5), rand.Next(5));
                Location end = new Location(rand.Next(5), rand.Next(5));
                Console.WriteLine("Hurry and get out of the dungeon before the monsters get you");
                while (wizert.isAlive())
                {
                    Console.WriteLine();
                    wizert.displayInfo();
                    Console.WriteLine("");
                    Cell cell = dungeon[loc.X][loc.Y];
                    Console.WriteLine("Your current Location: ");
                    cell.displayInfo();

                    if (cell.HasEnemy)
                    {
                        Console.WriteLine("1. Attack with Fireball");
                        Console.WriteLine("2. Heal");
                        Console.WriteLine("3. Flee");
                        choice = getChoice(1, 3);
                        if (choice == 1)
                        {
                            int damage = wizert.FireBall();
                            cell.Enemy.receiveDamage(damage);
                            Console.WriteLine(cell.Enemy.getName() + " now has " + cell.Enemy.getHealth() + " hp");
                            if (cell.Enemy.isAlive())
                            {
                                damage = cell.Enemy.attack();
                                wizert.takeDamage(damage);
                                Console.WriteLine(cell.Enemy.getName() + " attacks dealing " + damage + " worth of damage");
                            }
                            else
                            {
                                Console.WriteLine("The enemy is defeated");
                            }
                        }
                        else if (choice == 2)
                        {
                            wizert.Heal();
                            int damage = cell.Enemy.attack();
                            wizert.takeDamage(damage);
                            Console.WriteLine(cell.Enemy.getName() + " attacks dealing " + damage + " worth of damage");
                        }
                        else
                        {
                            if (rand.Next(10) > 5)
                            {
                                Console.WriteLine("You were not fast enough");
                                int damage = cell.Enemy.attack();
                                wizert.takeDamage(damage);
                                Console.WriteLine(cell.Enemy.getName() + " attacks dealing " + damage + " worth of damage");
                            }
                            else
                            {
                                Console.WriteLine("Wizert successfully escaped");
                                Console.WriteLine("1. Go North");
                                Console.WriteLine("2. Go South");
                                Console.WriteLine("3. Go East");
                                Console.WriteLine("4. Go West");
                                choice = getChoice(1, 4);
                                loc.Move(choice);
                            }
                        }

                    }
                    else
                    {
                        if (cell.HasPotion)
                        {
                            if (cell.Potion.Type == PotionType.HEALTH)
                            {
                                int val = cell.Potion.Value;
                                wizert.Hp += cell.Potion.usePotion();
                                Console.WriteLine("You have gained " + val + " health points after using health potion");
                            }
                            else
                            {
                                int val = cell.Potion.Value;
                                wizert.Mp += cell.Potion.usePotion();
                                Console.WriteLine("You have gained " + val + " Magicka points after using Magicka potion");
                            }
                        }
                        Console.WriteLine("1. Go North");
                        Console.WriteLine("2. Go South");
                        Console.WriteLine("3. Go East");
                        Console.WriteLine("4. Go West");
                        choice = getChoice(1, 4);
                        loc.Move(choice);

                    }


                    if (loc.X == end.X && loc.Y == end.Y)
                        break;
                }


                if (wizert.isAlive())
                    Console.WriteLine("Congratulations! You made it out of the Dungeon");
                else
                    Console.WriteLine("You ran out of HP.");
                Console.WriteLine("Do you want to play again?\n1. Yes\n2. No");
                choice = getChoice(1, 2);
                if (choice == 2)
                    done = true;
            }

        }
    }

    class Location
    {
        int x;
        int y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        bool GoNorth()
        {
            if (X - 1 >= 0)
            {
                x -= 1;
                return true;
            }
            return false;
        }

        bool GoSouth()
        {
            if (X + 1 < 5)
            {
                x += 1;
                return true;
            }
            return false;
        }

        bool GoEast()
        {
            if (Y + 1 < 5)
            {
                y += 1;
                return true;
            }
            return false;
        }

        bool GoWest()
        {
            if (y - 1 >= 0)
            {
                y -= 1;
                return true;
            }
            return false;
        }

        public void Move(int side)
        {
            switch (side)
            {
                case 1:
                    if (!GoNorth())
                        goto default;
                    break;
                case 2:
                    if (!GoSouth())
                        goto default;
                    break;
                case 3:
                    if (!GoEast())
                        goto default;
                    break;
                case 4:
                    if (!GoWest())
                        goto default;
                    break;
                default:
                    Console.WriteLine("Location is out of bounds");
                    break;


            }
        }
    }
}