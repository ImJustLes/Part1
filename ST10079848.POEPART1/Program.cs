using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST10079848.POEPART1 {
    internal class Program {

        static Boolean delCheck = false;
        static Boolean scaleCheck = false;
        static Boolean recipeCheck = false;
        static Boolean revertCheck = false;
        static int num;
        static int num2;

        static void Main(string[] args) {

            Console.ForegroundColor = ConsoleColor.Yellow;

            while (true) {

                Console.WriteLine("\nSelect an option by number: " +
                  "\n1) Create a new recipe." +
                  "\n2) Scale amount of ingredients." +
                  "\n3) Delete recipe." +
                  "\n4) Display recipe." +
                  "\n5) Reset ingredients to original quanitity." +
                  "\n6) Exit application.");
                int options = Convert.ToInt32(Console.ReadLine());

                if (options == 1) {

                    if (recipeCheck == true) {

                        Console.WriteLine("Please delete your current recipe in order to create a new one.");
                    
                    } else {

                        delCheck = false;
                        scaleCheck = false;
                        revertCheck = false;
                        recipeCheck = true;

                        RecipeHouseKeeping.amountGet();
                        RecipeHouseKeeping.nameGet();
                        RecipeHouseKeeping.quanGet();
                        RecipeHouseKeeping.measGet();
                        RecipeHouseKeeping.amountGet2();
                        RecipeHouseKeeping.amountGet2();
                        DisplayRecipe();
                    }
                
                } else if (options == 2) {

                    RecipeHouseKeeping.ScaleFactor();

                } else if (options == 3) {

                        delCheck = true;
                        scaleCheck = true;
                        recipeCheck = false;
                        revertCheck = true;

                    RecipeHouseKeeping.DeleteRecipe();
                    

                } else if (options == 4) {

                    if (delCheck == true) {

                        Console.WriteLine("\nThere is no recipe to display. Please create a recipe.");

                    } else {

                        DisplayRecipe();

                        if (revertCheck == true) {
                        
                        } else {

                            DisplayRecipe();
                        }
                    }

                } else if (options == 5) {

                    if (scaleCheck == true) {

                        Console.WriteLine("\nThere are no quantities to revert. Please create a recipe.");
                    
                    } else {

                        RecipeHouseKeeping.RevertQuan();
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
        static void DisplayRecipe()
        {

            Console.WriteLine("********RECIPE********");

            for (int y = 0; y < num; y++)
            {

                Console.WriteLine(quan[y] + meas[y] + " of " + name[y] + "(s)");
            }

            Console.Write("\n");

            for (int i = 0; i < desc.Length; i++)
            {

                int no = i + 1;
                Console.WriteLine("Step " + no + ": " + desc[i]);
            }
            Console.WriteLine("**********************");
        }
    }
}


