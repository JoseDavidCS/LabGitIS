using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Enter_to_List_Of_Countries_Test()
        {
            var URL = "http://localhost:8080/";

            _driver.Navigate().GoToUrl(URL);

            Assert.That(
                _driver.FindElement(By.TagName("h1")).Text,
                Is.EqualTo("Lista de países"));

            _driver.FindElement(
                By.ClassName("btn-outline-secondary"))
                .Click();

            IWebElement nameInput =
                _driver.FindElement(By.Id("name"));

            Assert.That(nameInput.Displayed, Is.True);

            nameInput.SendKeys("Alemania");

            Assert.That(
                nameInput.GetAttribute("value"),
                Is.EqualTo("Alemania"));

            IWebElement continent =
                _driver.FindElement(By.Id("continente"));

            continent.SendKeys("Europa");

            IWebElement language =
                _driver.FindElement(By.Id("idioma"));

            language.SendKeys("Aleman");

            _driver.FindElement(
                By.ClassName("btn-success"))
                .Click();

            WebDriverWait wait =
                new WebDriverWait(
                    _driver,
                    TimeSpan.FromSeconds(5));

            wait.Until(driver =>
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch
                {
                    return false;
                }
            });

            IAlert alert =
                _driver.SwitchTo().Alert();

            Assert.That(
                alert.Text,
                Is.EqualTo("País creado correctamente"));

            alert.Accept();

            wait.Until(driver =>
                driver.FindElement(By.TagName("h1")).Text
                == "Lista de países");

            Assert.That(
                _driver.FindElement(By.TagName("table"))
                .Text.Contains("Alemania"),
                Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}