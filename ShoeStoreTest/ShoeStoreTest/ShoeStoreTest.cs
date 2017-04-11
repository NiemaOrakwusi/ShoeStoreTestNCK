/*Selenium WebDriver Test Completed in C# By: Niema Kitt 
 On March 30, 2017 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;


namespace ShoeStoreTest
{
    [TestClass]
    public class ShoeStoreTest
    {
        static IWebDriver driver;


        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {

            driver = new FirefoxDriver();

        }


          [TestMethod]
         public void TestMonthly()
         {

             driver.Navigate().GoToUrl("http://shoestore-manheim.rhcloud.com");
             driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
             driver.FindElement(By.LinkText("All Shoes")).Click();
             driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
             IList<IWebElement> test = driver.FindElements(By.ClassName("shoe_description"));
             
             foreach (var item in test)
             {
                 if (item == null)
                 {

                    Assert.IsTrue(item.Displayed);
                 // MessageBox.Show("Null Description\n");

                 }
                 else
                 {
                    Assert.IsTrue(item.Displayed);
                    //MessageBox.Show("Not Null Description\n" + item.Text.Trim());

                 }
             }

             driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
             IList<IWebElement> tes = driver.FindElements(By.ClassName("shoe_image"));
             foreach (var items in tes)
             {
                 if (items == null)
                 {
                    Assert.IsTrue(items.Displayed);
                    //MessageBox.Show("Null Picture");

                 }
                 else
                 {
                    Assert.IsTrue(items.Displayed);
                    //MessageBox.Show("Not Null Picture\n" + items.Displayed);


                 }
             }

                  driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
             IList<IWebElement> testie = driver.FindElements(By.ClassName("shoe_price"));
             foreach (var itemse in testie)
             {
                 if (itemse == null)
                 {
					
					//Verify the item is displayed
                    Assert.IsTrue(itemse.Displayed);
					Console.WriteLine("Nothing Displayed");
                    
                   


                 }
                 else
                 {
					
                    //Verify the item is displayed
                    Assert.IsTrue(itemse.Displayed);
                    

                 }
             }

         }

        [TestMethod]
        public void Email()
        {
            driver.Navigate().GoToUrl("http://shoestore-manheim.rhcloud.com");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            IWebElement busd = driver.FindElement(By.Id("remind_email_input"));

            busd.SendKeys("testme@yahoo.com");

            driver.FindElement(By.XPath("//html//body//header//form[1]//div//input[2]")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));

            
            string fnd = driver.FindElement(By.XPath("//html//body//div[4]//div")).Text;

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            Assert.IsTrue(fnd.Contains("Thanks! We will notify you of our new shoes at this email:"));

            string foe3 = fnd.Substring(0,59);
            var foe4 = fnd.Substring(fnd.IndexOf(':') + 1).ToString();

            Assert.AreEqual(fnd,"Thanks! We will notify you of our new shoes at this email:" + foe4);

        }
           [TestMethod]
         public void TCleanup()
         {
            driver.Quit();

         }
    }
}
