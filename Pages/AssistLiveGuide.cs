using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parallelexecution.Drivers;
using OpenQA.Selenium;

namespace parallelexecution.Pages
{
    public class AssistLiveGuide
    {
        private AppiumDriver<AndroidElement> driver1;

        private AppiumDriver<AndroidElement> driver2;


        public AssistLiveGuide()
        {
            driver1 = drivers._driver1;
            driver2 = drivers._driver2;
        }
       
    }
}
