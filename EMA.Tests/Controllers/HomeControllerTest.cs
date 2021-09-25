using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMA.Business.Factory.Repository;
using EMA;
using EMA.Controllers;

namespace EMA.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            try
            {
                HelpRepository repository = new HelpRepository();
                //int counter = repository.CountChars("pankaj", "a");
                string test = repository.CountTotalChars("pankaj");

                //string s;
                //object o = null;
                //s = Convert.ToString(o);
               
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
