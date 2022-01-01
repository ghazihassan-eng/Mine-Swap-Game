using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Mineswap_game_NP_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            //start
            Console.WriteLine("This is server");

            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("192.168.43.25"), 8080);
                listener.Start();
                
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());

                    int serverPoints = 0;
                    
                    while (serverPoints < 5)
                    {

                        Console.WriteLine("place bomb in any BLOCK 1/2/3/4/5/6/7/8/9");
                        Console.WriteLine(" ");
                        Console.WriteLine("     1    |   2   |    3");
                        Console.WriteLine("     4    |   5   |    6");
                        Console.WriteLine("     7    |   8   |    9");

                        Console.WriteLine("PLACE A BOMB");
                        string placeBomb = Console.ReadLine();
                        if (placeBomb == "1" || placeBomb == "2" || placeBomb == "3" || placeBomb == "4" || placeBomb == "5" || placeBomb == "6" || placeBomb == "7" || placeBomb == "8" || placeBomb == "9")
                        {


                            Console.WriteLine("BOMB HAS BEEN PLACED AT BLOCK : " + placeBomb);
                            writer.WriteLine(placeBomb);
                            writer.Flush();

                            string bomb = reader.ReadLine();
                            if (bomb != "none")
                            {
                                for (int i = 1; i < 4; i++)
                                {
                                    Console.WriteLine("CLIENT PLACED A BOMB , GUESS THE BLOCK  --- TOTAL ATTEMPS 3");
                                    Console.WriteLine("ATTEMP NUMBER --> " + i);

                                    Console.WriteLine("     1    |   2   |    3");
                                    Console.WriteLine("     4    |   5   |    6");
                                    Console.WriteLine("     7    |   8   |    9");

                                    Console.WriteLine("GUESS...");
                                    string guessBomb = Console.ReadLine();

                                    if(guessBomb != "1" || guessBomb != "2" || guessBomb != "3" || guessBomb != "4" || guessBomb != "5" || guessBomb != "6" || guessBomb != "7" || guessBomb != "8" || guessBomb != "9" || guessBomb != "10")
                                    {
                                        Console.WriteLine("Wrong Input, Select from 1-9");
                                    }
                                    if (guessBomb == bomb)
                                    {
                                        Console.WriteLine("-----------BOMB DIFFUSED SUCCESFULLY-----------");
                                        serverPoints++;
                                        //Console.WriteLine("-----------SERVER ----------"+serverPoints);
                                        break;
                                    }
                                }
                            }
                            Console.WriteLine("-----------SERVER ----------" + serverPoints);
                            if (serverPoints == 5)
                            {
                                Console.WriteLine("////////server win\\\\\\\\");
                                break;
                            }
                        }
                        else { Console.WriteLine("Invalid Input"); }
                    }




                    reader.Close();
                    writer.Close();
                    client.Close();
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }






            //end
        }
    }
}
