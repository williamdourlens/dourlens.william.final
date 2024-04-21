using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dourlens.RG.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Dourlens.RG.DAL.DAL;
using Dourlens.RG.DAL.Model;

namespace Dourlens.RG.DAL.Service.Tests
{
    [TestClass()]
    public class AddEspionTest
    {
        [TestMethod()]
        public void AddEspion()
        {
            var mockDbContext = new Mock<IDourlensDbContext>();
            var service = new RenseignementsGenerauxService(mockDbContext.Object());


        }
    }
}