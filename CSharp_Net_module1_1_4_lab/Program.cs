using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
        public enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        };


        // 2) declare struct Computer
        public struct Computer
        {
            ComputerType type;
            int memmory;
            float frequency;
            int cores;
            int hdd;


            public Computer(ComputerType type, int memmory, float frequency, int cores, int hdd)
            {
                this.type = type;
                this.memmory = memmory;
                this.frequency = frequency;
                this.cores = cores;
                this.hdd = hdd;
            }


            public int Memmory
            {
                get => memmory;
                set => memmory = value;
            }

            public float Frequency
            {
                get => frequency;
                set => frequency = value;
            }

            public int Cores
            {
                get => cores;
                set => cores = value;
            }

            public int Hdd
            {
                get => hdd;
                set => hdd = value;
            }

            public ComputerType Type
            {
                get => type;
                set => type = value;
            }


            public override string ToString()
            {
                return "PC type: " + type + "\n" +
                       "Memmory - " + memmory + "Gb" + "\n" +
                       "Cores - " + cores + " frequency - " + frequency + "HGz\n" +
                       "HDD capacity - " + hdd + "Gb";
            }
        }

        static void Main(string[] args)
        {
            // 3) declare jagged array of computers size 4 (4 departments)

            var computers = new Computer[4][];
            // 4) set the size of every array in jagged array (number of computers)
            for (int i = 0; i < computers.Length; i++)
            {
                computers[i] = new Computer[new Random().Next(1, 5)];
            }


            Random random = new Random();
            // 5) initialize array
            // Note: use loops and if-else statements
            for (int i = 0; i < computers.Length; i++)
            {
                for (int j = 0; j < computers[i].Length; j++)
                {
                    if (Enum.GetName(typeof(ComputerType), random.Next(0, 3)) == "Desktop")
                    {
                        computers[i][j] = new Computer(ComputerType.Desktop, random.Next(4, 9),
                            (float) random.NextDouble() * 10, 4, random.Next(500, 750));
                    }
                    else if (Enum.GetName(typeof(ComputerType), random.Next(0, 3)) == "Laptop")
                    {
                        computers[i][j] = new Computer(ComputerType.Laptop, random.Next(2, 5),
                            (float) random.NextDouble() * 10, 2, random.Next(250, 750));
                    }
                    else
                    {
                        computers[i][j] = new Computer(ComputerType.Server, random.Next(8, 32),
                            (float) random.NextDouble() * 10, 8, random.Next(750, 16000));
                    }
                }
            }


            // 6) count total number of every type of computers
            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)
            int desktop = 0;
            int laptop = 0;
            int servers = 0;
            int total = 0;
            for (int i = 0; i < computers.Length; i++)
            {
                for (int j = 0; j < computers[i].Length; j++)
                {
                    if (computers[i][j].Type == ComputerType.Desktop)
                    {
                        desktop++;
                    }
                    else if (computers[i][j].Type == ComputerType.Laptop)
                    {
                        laptop++;
                    }
                    else if (computers[i][j].Type == ComputerType.Server)
                    {
                        servers++;
                    }

                    total++;
                    Console.WriteLine(computers[i][j]);
                }
            }

            Console.WriteLine("We already have:\n" +
                              "Desktops - " + desktop + "\n" +
                              "Laptops - " + laptop + "\n" +
                              "Servers - " + servers + "\n" +
                              "At total we have - " + total + " Computers");

            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements

            Computer temp = new Computer(ComputerType.Desktop, 0, 0, 0, 0);
            int[] position = new int[2];
            for (int i = 0; i < computers.Length; i++)
            {
                for (int j = 0; j < computers[i].Length; j++)
                {
                    if (computers[i][j].Hdd > temp.Hdd)
                    {
                        temp = computers[i][j];
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }

            Console.WriteLine("Computer with max HDD capacity is: \n"
                              + temp + "\n" +
                              "and has position in computers array - [" + position[0] + "][" + position[1] + "]");

            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions

            Computer temp2 = new Computer(ComputerType.Desktop, 0, 0, 0, 0);
            int[] position2 = new int[2];
            for (int i = 0; i < computers.Length; i++)
            {
                for (int j = 0; j < computers[i].Length; j++)
                {
                    if (computers[i][j].Hdd > temp2.Hdd)
                    {
                        temp2 = computers[i][j];
                        position2[0] = i;
                        position2[1] = j;
                    }
                }
            }

            Console.WriteLine("Computer with the lowest productivity (CPU and memory) is: \n"
                              + temp2 + "\n" +
                              "and has position in computers array - [" + position2[0] + "][" + position2[1] + "]");
            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements
            for (int i = 0; i < computers.Length; i++)
            {
                for (int j = 0; j < computers[i].Length; j++)
                {
                    if (computers[i][j].Type == ComputerType.Desktop)
                    {
                        computers[i][j].Memmory = 8;
                    }
                }
            }
            
            Console.ReadLine();
        }
    }
}