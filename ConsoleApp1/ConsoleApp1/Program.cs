using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vehicle
    {
        public String VehicleId { get; set; }
        public String VehicleName { get; set; }
        public String Brand { get; set; }
        public int ReleaseYear { get; set; }

        public Vehicle(String vehicleId, String vehicleName, String brand, int releaseYear)
        {
            this.VehicleId = vehicleId;
            this.VehicleName = vehicleName;
            this.Brand = brand;
            this.ReleaseYear = releaseYear;
        }
        //change in revisedcopy 
    }





    public class Program         //DO NOT CHANGE the class name
    {
        /** DO NOT CHANGE this 'List' declaration with initialized values  **/
        public static List<Vehicle> vehicleList = new List<Vehicle>()
                                    {
                                        new Vehicle("HO345","CRV","Honda",2015),
                                        new Vehicle("HY562","Creta","Hyundai",2017),
                                        new Vehicle("RE198","Duster","Reanult",2014),
                                        new Vehicle("MA623","Spacio","Suzuki",2014),
                                        new Vehicle("TR498","Nexon","Tata",2015),
                                        new Vehicle("TR981","Zest","Tata",2016),
                                        new Vehicle("HO245","WRV","Honda",2018)

                                    };
        public static void getVehicleName(int fromYear, int toYear)
        {
            //var name=vehicleList.OfType<Vehicle>().Where(n=> n.ReleaseYear >= fromYear && n.ReleaseYear <= toYear).Select(n=>n);
            var a = (from n in vehicleList
                     where n.ReleaseYear >= fromYear && n.ReleaseYear <= toYear
                     select n).ToList();
            foreach (var i in a)
            {
                Console.WriteLine("Vehicle Name Released Between 2014 And 2016 : {0}", i.VehicleName );
            }
        }
        static void Main(string[] args)   //DO NOT Change this 'Main' signature
        {

            Console.WriteLine("Enter From Year : ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter To Year : ");
            int y = int.Parse(Console.ReadLine());
            getVehicleName(x, y);
            //  Console.WriteLine("Vehicle Name Released Between 2014 And 2016 : {0}", getVehicleName(x, y));
            Console.ReadKey();
        }

        //Implement the method 'getVehicleName' here
       

        /** DO NOT CHANGE this ParameterExpression **/
        public static ParameterExpression variableExpr = Expression.Variable(typeof(IEnumerable<Vehicle>), "sampleVar");

        public static Expression getMyExpression(int fromYear, int toYear)
        {
            Expression assignExpr = Expression.Assign(variableExpr, Expression.Constant(from n in vehicleList
                                                                                        where n.ReleaseYear >= fromYear && n.ReleaseYear <= toYear
                                                                                        select n));

            return assignExpr;
        }


    }
}


