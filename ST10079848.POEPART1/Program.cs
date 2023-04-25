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
        static Boolean disCheck =  false;
        static int num;
        static int num2;
        static string[] name;
        static double[] quan;
        static double[] quan2;
        static string[] meas;
        static string[] desc;

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

                        Console.WriteLine("\nPlease delete your current recipe in order to create a new one.");
                    
                    } else {

                        delCheck = false;
                        scaleCheck = false;
                        revertCheck = false;
                        recipeCheck = true;
                        disCheck = false;

                        num = RecipeHouseKeeping.amountGet();
                        name = RecipeHouseKeeping.nameGet();
                        quan = RecipeHouseKeeping.quanGet();
                        meas = RecipeHouseKeeping.measGet();
                        num2 = RecipeHouseKeeping.amountGet2();
                        desc = RecipeHouseKeeping.descGet();
                        DisplayRecipe();
                    }
                
                } else if (options == 2) {

                    if (scaleCheck == true) {
                        
                        Console.WriteLine("\nThere is no recipe to scale quanitites with. Please enter a recipe.");

                    } else {

                        RecipeHouseKeeping.ScaleFactor();
                    }

                } else if (options == 3) {

                    Console.WriteLine("\nAre you sure you want to clear your recipe?\nY for yes.\nN for no.");
                    string dec = Console.ReadLine();

                    if (dec.ToLower().Equals("y")) {

                        if (delCheck == true) {

                            Console.WriteLine("\nRecipe already deleted.");
                    
                            } else {

                                delCheck = true;
                                scaleCheck = true;
                                revertCheck = true;
                                recipeCheck = false;
                                disCheck = true;

                                RecipeHouseKeeping.DeleteRecipe();
                            }
                        }
                    
                } else if (options == 4) {

                        if (disCheck == true) {

                            Console.WriteLine("\nThere is no recipe to display. Please create a recipe.");

                        } else {

                            DisplayRecipe();
                        }                                         

                } else if (options == 5) {

                    if (revertCheck == true) {

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
        static void DisplayRecipe() {

            Console.WriteLine("\n********RECIPE********");

            for (int y = 0; y < num; y++) {

                Console.WriteLine(quan[y] + "" + meas[y] + " of " + name[y] + "(s)");
            }

            Console.Write("\n");

            for (int i = 0; i < num2; i++) {

                int no = i + 1;
                Console.WriteLine("Step " + no + ": " + desc[i]);
            }
            Console.WriteLine("**********************");
        }
    }
}


