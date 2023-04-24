using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10079848.POEPART1 {
    internal class Program {

        //Declerations
        static int num;
        static int num2;
        static int options;
        static int options2;
        static double scale;
        static Boolean delCheck = false;
        static Boolean scaleCheck = false;

        static void Main(string[] args) {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("How many ingredients are in your recipe?");
            num = Convert.ToInt32(Console.ReadLine());

            string[] name = new string[num];
            double[] quan = new double[num];
            double[] quan2 = new double[num];
            string[] meas = new string[num];

            for (int i = 0; i < num; i++) {

                int no = i + 1;

                Console.WriteLine("\nPlease write the name for ingredient number " + no);
                name[i] = Console.ReadLine();

                Console.WriteLine("\nWhat is the quantity of " + name[i]);
                quan[i] = Convert.ToDouble(Console.ReadLine());
                quan2[i] = quan[i];

                Console.WriteLine("\nWhat is the unit of measuremnt for " + name[i] + "?");
                meas[i] = Console.ReadLine();
            }

            Console.WriteLine("\nHow many steps are in your recipe?");
            num2 = Convert.ToInt32(Console.ReadLine());

            string[] desc = new string[num2];

            for (int x = 0; x < num2; x++) {

                int no = x + 1;
                Console.Write("Step " + no + ": ");
                desc[x] = Console.ReadLine();
            }

            Console.WriteLine("********RECIPE********");

            for (int y = 0; y < num; y++) {

                Console.WriteLine(quan[y] + meas[y] + " of " + name[y] + "(s)");
            }

            Console.Write("\n");

            for (int i = 0; i < num2; i++) {

                int no = i + 1;
                Console.WriteLine("Step " + no + ": " + desc[i]);
            }
            Console.WriteLine("**********************");

            while (true) {

                Console.WriteLine("\nSelect an option by number: " +
                  "\n1) Create a new recipe." +
                  "\n2) Scale amount of ingredients." +
                  "\n3) Delete recipe." +
                  "\n4) Display recipe." +
                  "\n5) Reset ingredients to original quanitity." +
                  "\n6) Exit application.");
                options = Convert.ToInt32(Console.ReadLine());

                if (options == 1) {

                    RecipeGet(name, quan, quan2, meas, desc);

                } else if (options == 2) {

                    Console.WriteLine("\nSelect a value by number you would like to scale by:" +
                                      "\n1) 0.5" +
                                      "\n2) 2" +
                                      "\n3) 3");
                    options2 = Convert.ToInt32(Console.ReadLine());

                    ScaleFactor(quan);

                } else if (options == 3) {

                    Console.WriteLine("\nAre you sure you want to clear your recipe?\nY for yes.\nN for no.");
                    string dec = Console.ReadLine();

                    if (dec.ToLower().Equals("y")) {

                        Array.Clear(quan, 0, quan.Length);
                        Array.Clear(name, 0, name.Length);
                        Array.Clear(quan2, 0, quan2.Length);
                        Array.Clear(meas, 0, meas.Length);
                        Array.Clear(desc, 0, desc.Length);

                        delCheck = true;
                        scaleCheck = true;
                    }

                } else if (options == 4) {

                    if (delCheck == true) {

                        Console.WriteLine("\nThere is no recipe to display. Please create a recipe.");

                    } else {

                        DisplayRecipe(name, quan, meas, desc);
                    }

                } else if (options == 5) {

                    if (scaleCheck == true) {

                        Console.WriteLine("\nThere are no quantities to scale. Please create a recipe.");
                    
                    } else {

                        for (int i = 0; i < num; i++) {

                            quan2[i] = quan[i];
                        }
                        Console.WriteLine("\nQuantities successfully reverted.");
                    }                   
               
                } else if (options == 6) {

                    Console.WriteLine("\nThank you for using this application!");
                    Console.Read();
                    break;

                } else {

                    Console.WriteLine("\nPlease select a valid option.");
                }
            }
        }

        static void RecipeGet(string[] name, double[] quan, double[] quan2, string[] meas, string[] desc) {

            delCheck = false;
            scaleCheck = false;

            Console.WriteLine("\nHow many ingredients are in your recipe?");
            num = Convert.ToInt32(Console.ReadLine());

            name = new string[num];
            quan = new double[num];
            quan2 = new double[num];
            meas = new string[num];

            for (int i = 0; i < num; i++) {

                int no = i + 1;

                Console.WriteLine("\nPlease write the name for ingredient number " + no);
                name[i] = Console.ReadLine();

                Console.WriteLine("\nWhat is the quantity of " + name[i]);
                quan[i] = Convert.ToDouble(Console.ReadLine());
                quan[i] = quan2[i];

                Console.WriteLine("\nWhat is the unit of measuremnt for " + name[i] + "?");
                meas[i] = Console.ReadLine();
            }

            Console.WriteLine("\nHow many steps are in your recipe?");
            num2 = Convert.ToInt32(Console.ReadLine());

            desc = new string[num2];

            for (int x = 0; x < num2; x++) {

                int no = x + 1;
                Console.Write("Step " + no + ": ");
                desc[x] = Console.ReadLine();
            }

            Console.WriteLine("********RECIPE********");

            for (int y = 0; y < num; y++) {

                Console.WriteLine(quan[y] + meas[y] + " of " + name[y] + "(s)");
            }

            Console.Write("\n");

            for (int i = 0; i < num2; i++) {

                int no = i + 1;
                Console.WriteLine("Step " + no + ": " + desc[i]);
            }
            Console.WriteLine("**********************");
        }

        static void DisplayRecipe(string[] name, double[] quan, string[] meas, string[] desc) {

            Console.WriteLine("********RECIPE********");

            for (int y = 0; y < num; y++) {

                Console.WriteLine(quan[y] + meas[y] + " of " + name[y] + "(s)");
            }

            Console.Write("\n");

            for (int i = 0; i < desc.Length; i++) {

                int no = i + 1;
                Console.WriteLine("Step " + no + ": " + desc[i]);
            }
            Console.WriteLine("**********************");
        }

        static void ScaleFactor(double[] quan) {

            if (options2 == 1) {

                scale = 0.5;

                for (int i = 0; i < quan.Length; i++) {

                    quan[i] *= scale;
                }

            } else if (options2 == 2) {

                scale = 2;

                for (int i = 0; i < quan.Length; i++) {

                    quan[i] *= scale;
                }
            
            } else if (options2 == 3) {

                scale = 3;

                for (int i = 0; i < quan.Length; i++) {

                    quan[i] *= scale;
                }

            } else {

                Console.WriteLine("Invalid option.");
            }
        }
    }
}