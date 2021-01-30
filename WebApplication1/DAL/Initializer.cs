using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var vehicles = new List<Vehicle>
            {
            new Vehicle{Brand="Lexus",Model="RX300",Year=2000,Color="Złoty",Mileage=205000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX261/b3cf7924-5642-432e-9693-659e346bf22c.JPG",},
            new Vehicle{Brand="Honda",Model="Accord",Year=2011,Color="Srebrny",Mileage=135000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX277/d54fc8c2-7914-4f58-9f0c-ebc05741a5b0.JPG",},
            new Vehicle{Brand="Ford",Model="F150",Year=2019,Color="Biały",Mileage=2700,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX280/9fe4b344-46b1-4b7b-8103-07f2d80f2f8f.JPG",},
            new Vehicle{Brand="Nissan",Model="Versa",Year=2010,Color="Czarny",Mileage=220000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX288/43b808ab-1240-47a6-88f0-856783bd6246.JPG",},
            new Vehicle{Brand="Jeep",Model="Compass",Year=2020,Color="Czarny",Mileage=3400,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX287/0b9c2b57-eed2-4dbe-9dce-1090087d4e5a.JPG",},
            new Vehicle{Brand="Hummer",Model="H3",Year=2008,Color="Niebieski",Mileage=150000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX291/563f9ddf-c467-4eaf-824b-2b39109c18cb.JPG",},
            new Vehicle{Brand="Honda",Model="Odyssey",Year=2001,Color="Srebrny",Mileage=205000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX292/030d2d29-7c2c-463e-8940-c68d7a5c20d3.JPG",},
            new Vehicle{Brand="Chevrolet",Model="Cruze",Year=2013,Color="Czerwony",Mileage=79000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX291/0b383897-3801-47a8-ac7a-c8649c56f08e.JPG",},
            new Vehicle{Brand="Lincoln",Model="MKX",Year=2014,Color="Czarny",Mileage=41000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX291/a72f1a3c-006c-4693-88d8-173a25fa15e9.JPG",},
            new Vehicle{Brand="Jaguar",Model="X-type",Year=2005,Color="Niebieski",Mileage=107000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX292/02319694-d8d2-4663-b596-457b88c42f49.JPG",},
            new Vehicle{Brand="Hyundai",Model="Tucson",Year=2014,Color="Biały",Mileage=132000,Description="No Data",Url="https://cs.copart.com/v1/AUTH_svc.pdoc00001/PIX293/f222557c-7e64-4c07-b192-631d9260ceae.JPG",},


            };

            vehicles.ForEach(s => context.Vehicles.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{VehicleID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{VehicleID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{VehicleID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{VehicleID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{VehicleID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{VehicleID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{VehicleID=3,CourseID=1050},
            new Enrollment{VehicleID=4,CourseID=1050,},
            new Enrollment{VehicleID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{VehicleID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{VehicleID=6,CourseID=1045},
            new Enrollment{VehicleID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}