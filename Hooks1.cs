using BoDi;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;
using System;
using System.Net.Http;
using OpenQA.Selenium.Appium.Service;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using parallelexecution.Drivers;

namespace parallelexecution;
[TestFixture]
[Parallelizable(ParallelScope.All)]
[Binding]
public sealed class Hooks1
{
    public StepDefinitions.Steps class1;
    private readonly IObjectContainer _container;

    public Hooks1(IObjectContainer container)
    {
        _container = container;
    }

    private void StartAppiumServer(string port, out AppiumLocalService appiumLocalService)
    {
        appiumLocalService = new AppiumServiceBuilder().UsingPort(int.Parse(port)).Build();
        appiumLocalService.Start();
    }

    [BeforeScenario("@launch")]
    public void BeforeScenarioWithTag()
    {
        // Start Appium servers for both devices
        StartAppiumServer("4723", out var appiumLocalService1);
        StartAppiumServer("4725", out var appiumLocalService2);

        // Device 1 configuration
        var appiumOptionsDevice1 = new AppiumOptions();
        appiumOptionsDevice1.AddAdditionalCapability("platformName", "Android");
        appiumOptionsDevice1.AddAdditionalCapability("deviceName", "Pixel8pro");
        appiumOptionsDevice1.AddAdditionalCapability("udid", "38111FDJG00EQA");// Name for device 1
                                                                               // UDID of device 1
        appiumOptionsDevice1.AddAdditionalCapability("app", "C:\\Users\\iray\\Documents\\TestMultiplePlugins-2.apk");
        // appiumOptionsDevice1.AddAdditionalCapability("appPackage", "dk.resound.smart3d");
        appiumOptionsDevice1.AddAdditionalCapability("commandTimeout", 50000);
        appiumOptionsDevice1.AddAdditionalCapability("adbExecTimeout", 50000);
        var httpClient1 = new HttpClient();
        httpClient1.Timeout = TimeSpan.FromSeconds(1500);
        var commandExecutor1 = new HttpCommandExecutor(new Uri($"http://localhost:4723/wd/hub"), TimeSpan.FromSeconds(1500));
        var driverDevice1 = new AndroidDriver<AndroidElement>(appiumLocalService1.ServiceUrl, appiumOptionsDevice1);
        _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driverDevice1);
        driverDevice1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1500);
        drivers._driver1 = driverDevice1;

        // Device 2 configuration
        var appiumOptionsDevice2 = new AppiumOptions();
        appiumOptionsDevice2.AddAdditionalCapability("platformName", "Android");
        appiumOptionsDevice2.AddAdditionalCapability("deviceName", "Pixel6"); // Name for device 2
        appiumOptionsDevice2.AddAdditionalCapability("udid", "F6002CF19151FD"); // UDID of device 2
        appiumOptionsDevice2.AddAdditionalCapability("app", "C:\\Users\\iray\\Documents\\TestMultiplePlugins-2.apk");
        //appiumOptionsDevice2.AddAdditionalCapability("appPackage", "dk.resound.smart3d");
        appiumOptionsDevice2.AddAdditionalCapability("commandTimeout", 500000);
        appiumOptionsDevice2.AddAdditionalCapability("adbExecTimeout", 500000);
        var httpClient2 = new HttpClient();
        httpClient2.Timeout = TimeSpan.FromSeconds(1500);
        var commandExecutor2 = new HttpCommandExecutor(new Uri($"http://localhost:4725/wd/hub"), TimeSpan.FromSeconds(1500));
        var driverDevice2 = new AndroidDriver<AndroidElement>(appiumLocalService2.ServiceUrl, appiumOptionsDevice2);
        _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driverDevice2);
        driverDevice2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1500);
        drivers._driver2 = driverDevice2;
    }


}


////adb -s RZCR90DL9KX uninstall io.appium.uiautomator2.server
////adb -s RZCR90DL9KX uninstall io.appium.uiautomator2.server.test
////adb -s RZCR90DL9KX uninstall dk.resound.smart3d
////adb -s RZCWA22GBCW uninstall io.appium.uiautomator2.server
////adb -s RZCWA22GBCW uninstall io.appium.uiautomator2.server.test
////adb -s RZCWA22GBCW uninstall dk.resound.smart3d
//using BoDi;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Android;
//using TechTalk.SpecFlow;
//using System;
//using OpenQA.Selenium.Appium.Service;
//using NUnit.Framework;

//namespace parallelexecution
//{
//    [TestFixture]
//    [Parallelizable(ParallelScope.All)]
//    [Binding]
//    public sealed class Hooks1
//    {
//        private readonly IObjectContainer _container;

//        public Hooks1(IObjectContainer container)
//        {
//            _container = container;
//        }

//        private AppiumLocalService StartAppiumServer(string port)
//        {
//            var appiumLocalService = new AppiumServiceBuilder().UsingPort(int.Parse(port)).Build();
//            appiumLocalService.Start();
//            return appiumLocalService;
//        }

//        private AndroidDriver<AndroidElement> InitializeDriver(AppiumLocalService appiumService, string deviceName, string udid, string appPath)
//        {
//            var appiumOptions = new AppiumOptions();
//            appiumOptions.AddAdditionalCapability("platformName", "Android");
//            appiumOptions.AddAdditionalCapability("deviceName", deviceName);
//            appiumOptions.AddAdditionalCapability("udid", udid);
//            appiumOptions.AddAdditionalCapability("app", appPath);
//            appiumOptions.AddAdditionalCapability("commandTimeout", 500000);
//            appiumOptions.AddAdditionalCapability("adbExecTimeout", 500000);

//            var driver = new AndroidDriver<AndroidElement>(appiumService.ServiceUrl, appiumOptions);
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
//            return driver;
//        }

//        [BeforeScenario("@launch")]
//        public void BeforeScenarioWithTag()
//        {
//            // Start Appium servers
//            var appiumService1 = StartAppiumServer("4723");
//            var appiumService2 = StartAppiumServer("4725");

//            // Initialize drivers
//            var driver1 = InitializeDriver(appiumService1, "Pixel7", "F6002CF19151FD", "C:\\Users\\iray\\Documents\\TestMultiplePlugins-2.apk");
//            var driver2 = InitializeDriver(appiumService2, "Pixel8", "38081FDJH007V4", "C:\\Users\\iray\\Documents\\TestMultiplePlugins-2.apk");

//            // Register drivers in container
//            _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driver1, "Device1");
//            _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driver2, "Device2");
//        }

//        [AfterScenario]
//        public void AfterScenario()
//        {
//            // Dispose drivers and stop Appium servers
//            if (_container.IsRegistered<AppiumDriver<AndroidElement>>("Device1"))
//            {
//                _container.Resolve<AppiumDriver<AndroidElement>>("Device1").Quit();
//            }

//            if (_container.IsRegistered<AppiumDriver<AndroidElement>>("Device2"))
//            {
//                _container.Resolve<AppiumDriver<AndroidElement>>("Device2").Quit();
//            }
//        }
//    }
//}
