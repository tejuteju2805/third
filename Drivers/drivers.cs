using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallelexecution.Drivers
{
    public class drivers
    {
        public static AppiumDriver<AndroidElement> _driver1
        {
            get; set;
        }

        public static AppiumDriver<AndroidElement> _driver2
        {
            get; set;
        }

    }
}
