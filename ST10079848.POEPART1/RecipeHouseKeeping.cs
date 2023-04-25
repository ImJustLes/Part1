using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10079848.POEPART1 {

    internal class RecipeHouseKeeping {

        static double scale;
        static int options2;
        static int num;
        static int num2;

       public static int amountGet() {
           

            Console.WriteLine("\nHow many ingredients are in your recipe?");
            num = Convert.ToInt32(Console.ReadLine());

            return num;
        }

        public static string[] nameGet() {

            string[] name = new string[num];

            for (int i = 0; i < num; i++) {
                
                int no = i + 1;

                Console.WriteLine("\nPlease write the name for ingredient number " + no);
                name[i] = Console.ReadLine();
            }
            quanGet(name);
            return name;
        }

        public static double[] quanGet(string[] name) {

            double[] quan = new double[num];
            double[] quan2 = new double[num];

            for (int i = 0; i < num; i++) { 

            Console.WriteLine("\nWhat is the quantity of " + name[i]);
            quan[i] = Convert.ToDouble(Console.ReadLine());
            quan2[i] = quan[i];
        }
            ScaleFactor(quan); 
            return quan;
    }

        public static string[] measGet() {

            string[] meas = new string[num];

            for (int i = 0; i < num; i++) {

                Console.WriteLine("\nWhat is the unit of measuremnt for " + name[i] + "?");
                meas[i] = Console.ReadLine();
            }
            return meas;
        }

        static int amountGet2() {

            Console.WriteLine("\nHow many steps are in your recipe?");
            num2 = Convert.ToInt32(Console.ReadLine());

            return num2;
        }

        public static string[] descGet() {

            string[] desc = new string[num2];

            Console.WriteLine("\n");

            for (int x = 0; x < num2; x++) {

                int no = x + 1;
                Console.Write("Step " + no + ": ");
                desc[x] = Console.ReadLine();
            }
            return desc;
        }

        static double[] ScaleFactor(double[] quan) {

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
    }
}
