using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
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
        static Boolean recipeCheck = false;
        static Boolean revertCheck = false;

        static void Main(string[] args) {

            Console.ForegroundColor = ConsoleColor.Yellow;
            recipeCheck = true;

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

                    if (recipeCheck == true) {

                        Console.WriteLine("Please delete your current recipe in order to create a new one.");
                    
                    } else { 

                    RecipeGet(name, quan, quan2, meas, desc);

                    }
                
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
                        recipeCheck = false;
                        revertCheck = true;

                    }

                } else if (options == 4) {

                    if (delCheck == true) {

                        Console.WriteLine("\nThere is no recipe to display. Please create a recipe.");

                    } else {

                        if (revertCheck == true) {

                            Console.WriteLine("There are no quantity values to revert. Please make a recipe.");
                        
                        } else { 

                            DisplayRecipe(name, quan, meas, desc);
                        }
                    }

                } else if (options == 5) {

                    if (scaleCheck == true) {

                        Console.WriteLine("\nThere are no quantities to scale. Please create a recipe.");
                    
                    } else {

                        for (int i = 0; i < num; i++) {

                            quan[i] = quan2[i];
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
            revertCheck = false;
            recipeCheck = true;

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

            Console.WriteLine("\n");

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

//How many ingredients are in your recipe?
//3

//Please write the name for ingredient number 1
//Potato

//What is the quantity of Potato
//23

//What is the unit of measuremnt for Potato?
//g

//Please write the name for ingredient number 2
//Patty

//What is the quantity of Patty
//45

//What is the unit of measuremnt for Patty?
//kg

//Please write the name for ingredient number 3
//Bun

//What is the quantity of Bun
//89

//What is the unit of measuremnt for Bun?
//mg

//How many steps are in your recipe?
//3
//Step 1: fry
//Step 2: Baste
//Step 3: Bake
//******** RECIPE********
//23g of Potato(s)
//45kg of Patty(s)
//89mg of Bun(s)

//Step 1: fry
//Step 2: Baste
//Step 3: Bake
//**********************

//Select an option by number:
//1) Create a new recipe.
//2) Scale amount of ingredients.
//3) Delete recipe.
//4) Display recipe.
//5) Reset ingredients to original quanitity.
//6) Exit application.
//3

//Are you sure you want to clear your recipe?
//Y for yes.
//N for no.
//Y

//Select an option by number:
//1) Create a new recipe.
//2) Scale amount of ingredients.
//3) Delete recipe.
//4) Display recipe.
//5) Reset ingredients to original quanitity.
//6) Exit application.
//4

//There is no recipe to display. Please create a recipe.

//Select an option by number:
//1) Create a new recipe.
//2) Scale amount of ingredients.
//3) Delete recipe.
//4) Display recipe.
//5) Reset ingredients to original quanitity.
//6) Exit application.
//1

//How many ingredients are in your recipe?
//1

//Please write the name for ingredient number 1
//Poatota

//What is the quantity of Poatota
//21

//What is the unit of measuremnt for Poatota?
//g

//How many steps are in your recipe?
//1


//Step 1: dat
//******** RECIPE********
//0g of Poatota(s)

//Step 1: dat
//**********************

//Select an option by number:
//1) Create a new recipe.
//2) Scale amount of ingredients.
//3) Delete recipe.
//4) Display recipe.
//5) Reset ingredients to original quanitity.
//6) Exit application.
//4
//* *******RECIPE * *******
//0 of(s)

//Step 1:
//Step 2:
//Step 3:
//**********************

//Select an option by number:
//1) Create a new recipe.
//2) Scale amount of ingredients.
//3) Delete recipe.
//4) Display recipe.
//5) Reset ingredients to original quanitity.
//6) Exit application.
