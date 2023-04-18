using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V109.CSS;

namespace SeleniumTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // DELETE
        // CREATE
        // EDIT --> match the delete for the next time it runs
        // VIEW


        [TestMethod]
        public void TestDelete()
        {
            // This tests deleting a customer
            string urlCustomer = "https://localhost:44309//customers";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlCustomer);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();





            // This method tests deleting a service
            string urlService = "https://localhost:44309//services";
            driver.Navigate().GoToUrl(urlService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();




            // This method tests deleting an employee
            string urlEmployee = "https://localhost:44309//employees";
            driver.Navigate().GoToUrl(urlEmployee);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();




            // This method tests deleting a job
            string urlJob = "https://localhost:44309//jobs";
            driver.Navigate().GoToUrl(urlJob);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }



        [TestMethod]
        public void TestCreate()
        {
            // This method tests creating a new customer
            string urlCustomer = "https://localhost:44309//customers";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlCustomer);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys("CustomerTest000");
            driver.FindElement(By.Id("Address")).SendKeys("CustomerTest000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();




            // This method tests creating a new employee
            string urlEmployee = "https://localhost:44309//employees";
            driver.Navigate().GoToUrl(urlEmployee);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("Name")).SendKeys("EmployeeTest000");
            driver.FindElement(By.Id("Department")).SendKeys("EmployeeTest000");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();




            // This method tests creating a new service
            string urlService = "https://localhost:44309//services";
            driver.Navigate().GoToUrl(urlService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("Name")).SendKeys("ServiceTest000");

            // Select the dropdown option (this user was set in a previous test)
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("EmployeeID")));
            dropDown.SelectByText("EmployeeTest000");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();





            // This method tests creating a job
            string urlJob = "https://localhost:44309//jobs";
            driver.Navigate().GoToUrl(urlJob);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Select the dropdown option with the name test (this user was set in a previous test)
            SelectElement dropDown2 = new SelectElement(driver.FindElement(By.Id("ServiceId")));
            dropDown2.SelectByText("ServiceTest000");
            SelectElement dropDown3 = new SelectElement(driver.FindElement(By.Id("CustomerId")));
            dropDown3.SelectByText("CustomerTest000");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }



        [TestMethod]
        public void TestEdit()
        {
            // This method tests editing a customer
            string urlCustomer = "https://localhost:44309//customers";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlCustomer);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Address")).Clear();

            driver.FindElement(By.Id("Name")).SendKeys("EditTest");
            driver.FindElement(By.Id("Address")).SendKeys("EditTest");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();



            // This method tests editing an employee
            string urlEmployee = "https://localhost:44309//employees";
            driver.Navigate().GoToUrl(urlEmployee);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Department")).Clear();

            driver.FindElement(By.Id("Name")).SendKeys("EditTest");
            driver.FindElement(By.Id("Department")).SendKeys("EditTest");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();



            // This method tests editing a service
            string urlService = "https://localhost:44309//services";
            driver.Navigate().GoToUrl(urlService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("TestTest");

            // Select the dropdown option with the name test (this user was set in a previous test)
            //SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("EmployeeID")));
            //dropDown.SelectByText("Employee000");
            SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@class='form-control EmployeeClass']")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            dropDown.SelectByText("E5");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();



            // This method tests editing a job
            string urlJob = "https://localhost:44309//jobs";
            driver.Navigate().GoToUrl(urlJob);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Select the dropdown option (this user was set in a previous test)
            SelectElement dropDown3 = new SelectElement(driver.FindElement(By.XPath("//select[@class='form-control ServiceClass']")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            dropDown3.SelectByText("S3");
            SelectElement dropDown4 = new SelectElement(driver.FindElement(By.XPath("//select[@class='form-control CustomerClass']")));
            dropDown4.SelectByText("C5");

            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }



        [TestMethod]
        public void TestView()
        {
            // This method tests viewing a customer
            string urlCustomer = "https://localhost:44309//customers";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlCustomer);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();



            // This method tests viewing an employee
            string urlEmployee = "https://localhost:44309//employees";
            driver.Navigate().GoToUrl(urlEmployee);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();



            // This method tests viewing a service
            string urlService = "https://localhost:44309//services";
            driver.Navigate().GoToUrl(urlService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();


            // This method tests viewing a job
            string urlJob = "https://localhost:44309//jobs";
            driver.Navigate().GoToUrl(urlJob);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();

        }

    }
}
