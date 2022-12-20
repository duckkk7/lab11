using System;
namespace TestConsole
{     
    class Program
    {    static void Main(string[] args)
        {
            /*Person pers1 = new Person();
            Person pers2 = new Person("Ann", "Belyaeva", new DateTime(1999, 10, 12));

            var pers = pers1.DeepCopy();
            Person pers3 = pers as Person;

            int hash = pers1.GetHashCode();
            Console.WriteLine("Hashcode pers1 = " + hash);
            hash = pers2.GetHashCode();
            Console.WriteLine("Hashcode pers2 = " + hash);
            hash = pers3.GetHashCode();
            Console.WriteLine("Hashcode pers3 = " + hash);

            Console.WriteLine("pers1 == pers2 " + (pers1 == pers2)); //False
            Console.WriteLine("pers1 == pers3 " + (pers1 == pers3)); //True

            Console.WriteLine("pers1 != pers2 " + (pers1 != pers2)); //True
            Console.WriteLine("pers1 != pers3 " + (pers1 != pers3)); //False
 
            Console.WriteLine("pers1 equals pers2 " + pers1.Equals(pers2)); //False
            Console.WriteLine("pers1 equals pers2 " + pers1.Equals(pers3)); //True

            pers1.Name = "Ivan";
            hash = pers1.GetHashCode();
            Console.WriteLine("Hashcode pers1 = " + hash);
            hash = pers3.GetHashCode();
            Console.WriteLine("Hashcode pers3 = " + hash);

            Team t1 = new Team("SSO", 123321);
            Team t2 = new Team("SSO", 123321);
            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(t1==t2);
            Console.WriteLine((string.Format("Team1: {0}, Team2: {1} ", t1.GetHashCode(),t2.GetHashCode())));

            try
            {
                t2.RegNum = -123;
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                Console.WriteLine(outOfRangeException.Message);
            }
            
            ResearchTeam CoolGuys = new ResearchTeam("Really Cool", "Cool guys", 1543264, TimeFrame.Year);

            Person CG1 = new Person("Vlada", "Eliseeva", new DateTime(2003, 05, 31));
            Person CG2 = new Person();
            Paper PCG1 = new Paper("Information about myself","Vlada Eliseeva", new DateTime(2022, 06, 12));
            Paper PCG2 = new Paper();
            CoolGuys.AddMembers(new Person[2] {CG1, CG2});
            CoolGuys.AddPapers(new Paper[2] {PCG1, PCG2});
            //CoolGuys.ToShortString();
            Console.WriteLine(CoolGuys.ToString());
            Console.WriteLine(CoolGuys.getTeamType.ToString());

            ResearchTeam CoolGuysCopy = (ResearchTeam)CoolGuys.DeepCopy();
            CoolGuys.Organization = "Roga i kopyta";
            CoolGuys.RegNum = 777;

            Console.WriteLine(CoolGuysCopy.ToShortString());
            Console.WriteLine(CoolGuys.ToShortString());


            Console.WriteLine("*****Persons without publications: *****");
            foreach (Person p in CoolGuysCopy.GetPersonsWithoutP())
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("*****Last publications: *****");
            foreach (Paper p in CoolGuysCopy.LastPublications(2))
            {
                Console.WriteLine(p);
            }*/




            /*ResearchTeamCollection rr = new ResearchTeamCollection();
            rr.AddDefaults();
            Console.WriteLine("\n*****Первый объект ResearchTeamCollection: *****");
            Console.WriteLine(rr.ToString());

            rr.OrderByRegNum();
            Console.WriteLine("Сортировка по регистрационному номеру: ");
            Console.WriteLine(rr.ToShortString());

            rr.OrderByTheme();
            Console.WriteLine("Сортировка по теме: ");
            Console.WriteLine(rr.ToShortString());

            rr.OrderByPubclicationsCount();
            Console.WriteLine("Сортировка по количеству публикаций: ");
            Console.WriteLine(rr.ToShortString());

            Console.WriteLine("Минимальный регистрационный номер: " + rr.MinRegNum);
            Console.WriteLine("Исследования с длительностью 2 года: ");
            foreach(ResearchTeam rt in rr.TwoYearsDuration)
            {
                Console.WriteLine(rt);
            }
            Console.WriteLine("Исследования с количеством участников = 2: ");
            foreach (ResearchTeam rt in rr.NGroup(2))
            {
                Console.WriteLine(rt);
            }


            int value = 0;
            do
            {
                Console.Write("Введите число элементов в коллекциях: ");
                try 
                {
                    value = int.Parse(Console.ReadLine());
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException("Value must be more than 0 ");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (value <= 0);
            

            TestCollections FirstTestCollection = new TestCollections(value);
            
            Console.WriteLine("*****Поиск первого элемента во всех коллекциях*****");
            FirstTestCollection.TickC(TestCollections.Generate(0));

            Console.WriteLine("\n*****Поиск центрального элемента во всех коллекциях*****");
            FirstTestCollection.TickC(TestCollections.Generate(value/2));

            Console.WriteLine("\n*****Поиск последнего элемента во всех коллекциях*****");
            FirstTestCollection.TickC(TestCollections.Generate(value-1));

            Console.WriteLine("\n*****Поиск несуществующего элемента во всех коллекциях*****");
            FirstTestCollection.TickC(TestCollections.Generate(6666666));*/

            ResearchTeamCollection coll1 = new ResearchTeamCollection();
            ResearchTeamCollection coll2 = new ResearchTeamCollection();
            TeamsJournal tj1 = new TeamsJournal();
            TeamsJournal tj2 = new TeamsJournal();
            coll1.ResearchTeamAdded += tj1.TeamEventHandler;
            coll1.ResearchTeamInserted += tj1.TeamEventHandler;

            coll1.ResearchTeamAdded += tj2.TeamEventHandler;
            coll1.ResearchTeamInserted += tj2.TeamEventHandler;
            coll2.ResearchTeamAdded += tj2.TeamEventHandler;
            coll2.ResearchTeamInserted += tj2.TeamEventHandler;

            coll1.AddDefaults();
            coll1.InsertAt(0, new ResearchTeam());
            coll1.InsertAt(9, new ResearchTeam());

            coll2.AddDefaults();
            coll2.InsertAt(1, new ResearchTeam());
            coll2.InsertAt(7, new ResearchTeam());

            Console.WriteLine("TeamJournal1: " + tj1.ToString());
            Console.WriteLine("TeamJournal2: " + tj2.ToString());
        }
        
        

        /*
        private static void Task1()
        {
            for (int i = 14; i < 100; i++) 
            {
                if (((i%10)*(i%10) + (i/10)*(i/10)) % 17 == 0) 
                Console.Write(i + " ");
            }
        }

        private static void Task2()
        {
            Console.WriteLine("\n\n   x    |    y   ");
            Console.WriteLine("-------------------");
            int dx = 2;
            double y, y1, y2, x1, x2, x=-4;
            while (x < 10) 
            {
                if (x <= -2 && x >= -4)
                {
                    y1 = -1.0; y2 = 1; x1 = -4; x2 = -2;
                    y = (y2 - y1)/(x2 - x1)*(x - x1) + y1;
                    //Console.WriteLine(x +" | "+ y);
                    string s1 = string.Format("{0, 7} | ", x); 
                    string s2 = string.Format("{0, 7}", y);
                    Console.WriteLine(s1 + s2);

                }
                else if (x >= -2 && x <= 4)
                {
                    y1 = 1; y2 = -2; x1 = -2; x2 = 4;
                    y = (y2 - y1)/(x2 - x1)*(x - x1) + y1;
                    string s1 = string.Format("{0, 7} | ", x); 
                    string s2 = string.Format("{0, 7}", y);
                    Console.WriteLine(s1 + s2);
                }
                else if (x >= 4 && x <= 6)
                {
                    y1 = -2; y2 = -2; x1 = 4; x2 = 6;
                    y = (y2 - y1)/(x2 - x1)*(x - x1) + y1;
                    string s1 = string.Format("{0, 7} | ", x); 
                    string s2 = string.Format("{0, 7}", y);
                    Console.WriteLine(s1 + s2);
                }
                else if (x >= 6 && x <= 10)
                {
                    double r = 2;
                    y1 = -2; x1 = 8;
                    y = Math.Sqrt(r*r - (x - x1)) + y1;
                    string s1 = string.Format("{0, 7} | ", x); 
                    string s2 = string.Format("{0, 7}", y);
                    Console.WriteLine(s1 + s2);
                }
                x += dx;
            }

        }

        private static void Task3()
        {
            int n = 6;
            int[] a =  new int[n];
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            a[i] = rand.Next(-10, 10); 
            Console.WriteLine("[{0}]", string.Join(", ", a));

            int mn = 100;
            int index = 0; int flag = -1;
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < mn && a[i] >= 0)
                {
                    mn = a[i]; 
                    index = i;
                }
                if (a[i] < 0 && flag == -1) flag = i;
            }
            Console.WriteLine("Номер минимального положительного элемента: " + (index + 1));
            int flag2 = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] < 0) 
                {
                    flag2 = i;   
                    break;
                }        
            }
            double k = 0;
            for (int i = flag + 1; i <= flag2 - 1; i++) 
            {
                sum += a[i];
                k ++;
            }
            Console.WriteLine("Ср. арифметическое между крайними отрицательными: " + sum/k);      
        }

        private static void Task4()
        {
            int[,] a = new int[5, 10];                                      
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    a[i, j] = random.Next(-10, 10);
                    Console.Write("{0,4}", a[i, j]);
                }
                Console.WriteLine();
            }
            double max = 5;
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                double sum = 0;
                for (int j = 0; j < 10; j++)
                {
                    sum += a[i, j];
                }
                if (sum/10 < max) k++;
            }
            for (int i = 0; i < 5; i++)
            {
                int tmp = 0;
                tmp = a[i, 0];
                a[i, 0] = a[i, 9];
                a[i, 9] = tmp;
            }
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0,4}", a[i, j]);
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("k = " + k);
        }

        private static void Task5()
        {
            int[][] a = new int[5][];   // память под ссылки на 3 строки
            a[0] = new int[5];     // память под 0-ю строку (5 эл-в)
            a[1] = new int[3];     // память под 1-ю строку (3 эл-та)
            a[2] = new int[8];     // память под 2-ю строку (4 эл-та)
            a[3] = new int[4];
            a[4] = new int[6];
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j]= random.Next(-500, 500);
                    Console.Write("{0,7}", a[i][j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < a.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < a[i].Length; j++)
                {
                    sum += a[i][j];
                }
                Console.WriteLine("Сумма эл-тов " + i + " строки = " + sum);
            }
        }
        */
    }
}
