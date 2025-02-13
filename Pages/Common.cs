using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using parallelexecution.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace parallelexecution.Pages
{
    public class Common
    {
        private AppiumDriver<AndroidElement> driver1;

        private AppiumDriver<AndroidElement> driver2;


        public Common()
        {
            driver1 = drivers._driver1;
            driver2 = drivers._driver2;
        }
        public string baseXPath = "com.ReSound.TestMultiplePlugins:id/ReSound.App.Legolas.Plugins.StandardMenuWithPlugins.Pages.MenuPage.MenuItem";

        //private void ClickElement(AppiumDriver<AndroidElement> driver, string buttonText)
        //{
        //    string fullXPath = $"{baseXPath}.{buttonText}";
        //    var button = driver.FindElement(By.Id(fullXPath));
        //    button.Click();
        //}

        //// Perform the click on both devices
        //public void PluginPage(string buttonText)
        //{
        //    // Execute the click on both devices using the respective drivers
        //    ClickElement(driver1, buttonText);  // For device 1
        //    ClickElement(driver2, buttonText);  // For device 2
        //}
        private void ClickElementOnBothDevices(By Id)
        {
            Thread thread1 = new Thread(() =>
            {
                driver1.FindElement(Id).Click();
            });
            Thread thread2 = new Thread(() =>
            {
                driver2.FindElement(Id).Click();
            });
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
        public void PluginPage(string buttonText)
        {
            string fullXPath = $"{baseXPath}.{buttonText}";
            By by = By.Id(fullXPath);
            ClickElementOnBothDevices(by);
        }

        public void validateTitle(string title)
        {
            Thread thread1 = new Thread(() =>
            {
                AndroidElement speech = driver1.FindElement(By.XPath($"//android.widget.TextView[contains(@resource-id, '{title}')]"));
                bool isClicked = speech.Selected;
                Assert.IsTrue(isClicked, "speech clarity is not enabled");
            });
            Thread thread2 = new Thread(() =>
            {
                AndroidElement speech1 = driver2.FindElement(By.XPath($"//android.widget.TextView[contains(@resource-id, '{title}')]"));
                bool isClicked1 = speech1.Selected;
                Assert.IsTrue(isClicked1, "speech clarity is not enabled");
            });
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

    }
}
