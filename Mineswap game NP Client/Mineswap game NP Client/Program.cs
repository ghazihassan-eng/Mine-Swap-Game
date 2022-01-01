using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Mineswap_game_NP_Client
{
    class Program
    {
        public int place() { int i = Convert.ToInt16(Console.ReadLine()); return i; }
        static void Main(string[] args)
        {
           

            //start
            Console.WriteLine("This is client");
            

            try
            {

                TcpClient client = new TcpClient("192.168.43.25", 8080);
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());



                //Console.WriteLine(bomb);

                Console.WriteLine("GAME START");
                Console.WriteLine("************************************************************");
                Console.WriteLine("SERVER PLACE A BOMB ");
                Console.WriteLine("GUESS THE BLOCK WHERE BOMB HAS BEEN PLACED");
                Console.WriteLine("************************************************************");
                Console.WriteLine("TOTAL BLOCKS 1/2/3/4/5/6/7/8/9");
                Console.WriteLine("================================");

                int clientPoints = 0;

                while (clientPoints < 5)
                {
                    string bomb = reader.ReadLine();

                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine("SERVER PLACED A BOMB , GUESS THE BLOCK  --- TOTAL ATTEMPS 3");
                        Console.WriteLine("ATTEMP NUMBER --> " + i);
                        
                        Console.WriteLine("     1    |   2   |    3");
                        Console.WriteLine("     4    |   5   |    6");
                        Console.WriteLine("     7    |   8   |    9");

                        Console.WriteLine("GUESS..");
                        string guessBomb = Console.ReadLine();
                        if (guessBomb != "1" || guessBomb != "2" || guessBomb != "3" || guessBomb != "4" || guessBomb != "5" || guessBomb != "6" || guessBomb != "7" || guessBomb != "8" || guessBomb != "9" || guessBomb != "10")
                        {
                            Console.WriteLine("Wrong Input, Select from 1-9");
                        }
                        if (guessBomb == bomb)
                        {
                            Console.WriteLine("-----------BOMB DIFFUSED SUCCESFULLY-----------");
                            clientPoints++;
                            //Console.WriteLine("-----------CLIENT-----------"+clientPoints);
                            break;
                        }
                    }

                    Console.WriteLine("-----------CLIENT-----------" + clientPoints);
                    if (clientPoints == 5)
                    {
                        Console.WriteLine("////////client win\\\\\\\\");
                        break;
                    }

                    Console.WriteLine("place bomb in any BLOCK 1/2/3/4/5/6/7/8/9");
                    Console.WriteLine("     1    |   2   |    3");
                    Console.WriteLine("     4    |   5   |    6");
                    Console.WriteLine("     7    |   8   |    9");
                    Console.WriteLine("");
                    Console.WriteLine("             Note:PLACE BOMB FROM ANY ABOVE BLOCKS OTHERWISE SERVER GET ITS TURN ");
                    Console.WriteLine("PLACE A BOMB");
                    string placeBomb = "";
                    placeBomb = Console.ReadLine();
                    

                    if (placeBomb == "1" || placeBomb == "2" || placeBomb == "3" || placeBomb == "4" || placeBomb == "5" || placeBomb == "6" || placeBomb == "7" || placeBomb == "8" || placeBomb == "9")
                    {
                        Console.WriteLine("BOMB HAS BEEN PLACED AT BLOCK : " + placeBomb);

                        writer.WriteLine(placeBomb);
                        writer.Flush();
                    }
                    else
                    {
                        Console.WriteLine(" Invalid Input ");
                        writer.WriteLine("none");
                        writer.Flush();
                    }
                }





                Console.ReadLine();
                
                reader.Close();
                writer.Close();
                client.Close();
            }
            

            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            

            //end
        }

       
    }
   
}

