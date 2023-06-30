using AVS_Desktop.DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS_Desktop.NunitTest
{
    internal class UtilitiesNunitTest
    {
        [Test]
        public void TestGet()
        {
            DataTable result = utilities.sql.Get("select * from persons");
            Assert.IsNotNull(result); 
        }
        [Test]
        public async void TestSet()
        {
            bool result = await utilities.sql.Set("insert into Nunit values('4');");
            Assert.IsTrue(result);
        }

        [Test]
        public void TestVerifyHashPassword()
        {
            bool result = utilities.tools.VerifyHashPassword("prueba", "Ed191292@");
            Assert.IsTrue(result);
        }
    }
}
