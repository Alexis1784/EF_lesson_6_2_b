using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_2_b
{
    class MyContextInitializator : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            Company c1 = new Company { Name = "Samsung" };
            Company c2 = new Company { Name = "Apple" };
            db.Companies.AddRange(new List<Company>() { c1, c2 });
            db.SaveChanges();
            
            Phone p1 = new Phone { Name = "Samsung Galaxy S5" };
            Phone p2 = new Phone { Name = "Samsung Galaxy S4" };
            Phone p3 = new Phone { Name = "iPhone5" };
            Phone p4 = new Phone { Name = "iPhone 4S" };

            p1.Company = c1;
            p2.Company = c1;
            p3.Company = c2;
            p4.Company = c2;
            //p1.Company.Add(c1);
            //p2.Company.Add(c1);
            //p3.Company.Add(c2);
            //p4.Company.Add(c2);
            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4 });
            db.SaveChanges();

            
            
            
        }
    }
}
