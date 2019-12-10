
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
namespace SeleniumKodDva
{
    class Class11
    {
        IWebDriver driver;

        [Test]
        public void TestUnos()
        {
            string txtMessage = "Ovo je neka poruka.";
            GoToWebsite("http://qa.todorowww.net/", true);
            IWebElement txtUnos = FindElement(By.Name("unos"));
            txtUnos?.SendKeys(txtMessage);
            Sleep(2);
            if (txtUnos.Text == txtMessage)
            {
                Assert.Fail("The text differs from requested.");
            }
            else
            {
                Assert.Pass("Entered text matches the requested one.");
            }
        }

        [Test]
        public void TestRegister()
        {
            GoToWebsite("http://qa.todorovic.net/, true");
            IWebElement linkRegister;
            linkRegister = FindElement(By.PartialLinkText("Registruj"));
            if (linkRegister != null)
            {
                linkRegister.Click();
            }
            FindElement(By.Name("ime"))?.SendKeys("Petar");
            FindElement(By.Name("prezime"))?.SendKeys("Petrovic");
            Sleep();
            string xpath = "//input[@name='korisnicko']";
            FindElement(By.XPath(xpath))?.SendKeys("PPetrovic");
            Sleep(5);

        }

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        public void Sleep(int ms = 1000)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public void GoToWebsite(string url, bool wait = false)
        {
            if (wait) { Sleep(); }
            driver.Navigate().GoToUrl(url);
            if (wait) { Sleep(); }
        }

        public IWebElement FindElement(By selector)
        {
            IWebElement elReturn = null;
            try
            {
                elReturn = driver.FindElement(selector);
            }
            catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw e;
            }

            return elReturn;
        }
    }
}