using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Zavrsni_rad.Library;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Registar = Zavrsni_rad.PageObjects.Registar;

namespace Zavrsni_rad.PageObjects
{
    class LoginPage

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        //UsefulFunctions helper = new UsefulFunctions();

        //public IWebElement Username
        //{
        //    get
        //    {
        //        return helper.GetElement(By.Name("username"));
        //    }
        //}
        //public IWebElement Password
        //{
        //    get
        //    {
        //        return helper.GetElement(By.Name("password"));
        //    }
        //}

        //public IWebElement Button
        //{
        //    get
        //    {
        //        return helper.GetElement(By.Name("button"));
        //    }
        //}
        public IWebElement UsernameInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("username")));
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("password")));
                    element = this.driver.FindElement(By.Name("password"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("login")));
                    element = this.driver.FindElement(By.Name("login"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }


        public void ClickLoginButton()
        {
            this.LoginButton?.Click();
            wait.Until(EC.ElementIsVisible(By.CssSelector("h3.panel-title")));
           
        }
        public HomePage Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            ClickLoginButton();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new HomePage(this.driver);
        }
    }
}
