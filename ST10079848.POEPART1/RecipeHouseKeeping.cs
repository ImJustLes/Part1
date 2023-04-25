using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ST10079848.POEPART1 {

    internal class RecipeHouseKeeping {

        static double scale;
        static int options2;
        static int num;
        static int num2;
        static string[] name;
        static double[] quan;
        static double[] quan2;
        static string[] meas;
        static string[] desc;

        public static int amountGet() {
           

            Console.WriteLine("\nHow many ingredients are in your recipe?");
            num = Convert.ToInt32(Console.ReadLine());

            return num;
        }

        public static string[] nameGet() {


            name = new string[num];

            for (int i = 0; i < num; i++) {
                
                int no = i + 1;

                Console.WriteLine("\nPlease write the name for ingredient number " + no);
                name[i] = Console.ReadLine();
            }
            return name;
        }

        public static double[] quanGet() {

            quan = new double[num];
            quan2 = new double[num];

            for (int i = 0; i < num; i++) { 

            Console.WriteLine("\nWhat is the quantity of " + name[i]);
            quan[i] = Convert.ToDouble(Console.ReadLine());
            quan2[i] = quan[i];
        } 
            return quan;
    }

        public static string[] measGet() {

            meas = new string[num];

            for (int i = 0; i < num; i++) {

                Console.WriteLine("\nWhat is the unit of measuremnt for " + name[i] + "?");
                meas[i] = Console.ReadLine();
            }
            return meas;
        }

        public static int amountGet2() {

            Console.WriteLine("\nHow many steps are in your recipe?");
            num2 = Convert.ToInt32(Console.ReadLine());

            return num2;
        }

        public static string[] descGet() {

            desc = new string[num2];

            Console.WriteLine("\n");

            for (int x = 0; x < num2; x++) {

                int no = x + 1;
                Console.Write("Step " + no + ": ");
                desc[x] = Console.ReadLine();
            }
            return desc;
        }

        public static double[] ScaleFactor() {

            Console.WriteLine("\nSelect a value by number you would like to scale by:" +
                                     "\n1) 0.5" +
                                     "\n2) 2" +
                                     "\n3) 3");
            options2 = Convert.ToInt32(Console.ReadLine());

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
            return quan;
        }

        public static void DeleteRecipe() {

            Console.WriteLine("\nAre you sure you want to clear your recipe?\nY for yes.\nN for no.");
            string dec = Console.ReadLine();

            if (dec.ToLower().Equals("y")) {

                Array.Clear(quan, 0, quan.Length);
                Array.Clear(name, 0, name.Length);
                Array.Clear(quan2, 0, quan2.Length);
                Array.Clear(meas, 0, meas.Length);
                Array.Clear(desc, 0, desc.Length);
            }
        }
    }
}
