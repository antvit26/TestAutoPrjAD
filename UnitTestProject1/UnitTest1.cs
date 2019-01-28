using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.IO;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Part A testing calculator website.

        //Testing method for couse testing.
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//Find 5 button element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[1]/span[2]")).Click();// find the cos element.
           
            IWebElement resultText = driver.FindElement(By.XPath("//*[@id='sciOutPut']"));//Find the result.
            double actual = double.Parse(resultText.Text);
            double expected = 0.9961946981;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect results when doing cos calculation.");
            return;
                        
        }

        //Test method for log testing.
        [TestMethod]
        public void TestMethod2()//Log testing
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//Finding 5 button element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[4]/span[5]")).Click();// finding the Log element.

            IWebElement resultText = driver.FindElement(By.XPath("//*[@id='sciOutPut']"));//Find the result.
            double actual = double.Parse(resultText.Text);
            double expected = 0.6989700043;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect results when for log 5");
            return;
        }

        //Test method for 𝑥� 
        [TestMethod]
        public void TestMethod3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//Find 5 button element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[3]/span[1]")).Click();// Finding xy element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//Find 5 button element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();//Find = element

            IWebElement resultText = driver.FindElement(By.XPath("//*[@id='sciOutPut']"));//Find the result.
            double actual = double.Parse(resultText.Text);
            double expected = 3125;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect results when for xy 5");
            return;
        }
        //Test method for n!
        [TestMethod]
        public void TestMethod4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//Find 5 button element.
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[5]/span[5]")).Click();

            IWebElement resultText = driver.FindElement(By.XPath("//*[@id='sciOutPut']"));//Find the result.
            double actual = double.Parse(resultText.Text);
            double expected = 120;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect results when for xy 5");
            return;

        }

        //Part B testing the website automationpractice.com
        [TestMethod]
        public void TestMethod5()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com");
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span")).Click(); //Adding first item into cart.
            driver.Navigate().GoToUrl("http://automationpractice.com");
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span")).Click(); //Adding second item into cart.
            driver.Navigate().GoToUrl("http://automationpractice.com");
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]/div[2]/a[1]/span")).Click(); //Adding third item into cart.
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order");

            IWebElement resultText = driver.FindElement(By.XPath("//*[@id='total_price_container']"));
            string actual = (resultText.Text);
            string expected = "$71.51";
            Assert.AreEqual(actual, expected, "Incorrect result for the Total for 3 items in cart" );
            driver.Close();
        }

        //Part C validates the availability of all links in this page.
        [TestMethod]
        public void TestMethod6()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com");
            ICollection<IWebElement> links = driver.FindElements(By.TagName("a"));
            TextWriter tw = new StreamWriter("C:/Users/adayr/Desktop/link.txt");// Give file location.
            foreach (IWebElement link in links)
            {
                tw.WriteLine(link);
            }

        }
        //Part D Checking Region and Distict values are right.
        [TestMethod]
        public void TestMethod7()
        {
            int region = 0;
            int dist = 0;
            IWebDriver driver = new ChromeDriver();
            TextWriter tw = new StreamWriter("C:/Users/adayr/Desktop/test.txt");
            driver.Navigate().GoToUrl("http://classic.realestate.co.nz/?oldsite=true&_ga=2.197705900.2045270058.1528962944-427710986.1528962941&_gac=1.149620098.1529028671.EAIaIQobChMItLeY0cvU2wIVGCQrCh0Bww3sEAAYAiAAEgJJ1PD_BwE");
            IWebElement regions = driver.FindElement(By.XPath("//*[@id='search_filters_regions']"));
            SelectElement regionAll = new SelectElement(regions);
            foreach (IWebElement selectionRegion in regionAll.Options)
            {
                regionAll.SelectByIndex(2);
                if (selectionRegion.Text.Equals("All Regions")) continue;
                region++;
                tw.WriteLine(selectionRegion.Text);
                regionAll.SelectByText(selectionRegion.Text);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Id("search_filters_districts"))));
                IWebElement distElement = driver.FindElement(By.Id("search_filters_districts"));
                SelectElement distPlace = new SelectElement(distElement);
                foreach (IWebElement m in distPlace.Options)
                {
                    if (m.Text.Equals("All districts")) continue;
                    dist++;
                    tw.WriteLine("--" + m.Text);
                }
            }
            tw.Close();
        }
        //Compareing two text files.
        [TestMethod]
        public void compareTwoFiles()
        {
            using (StreamReader file1 = new StreamReader("C:/Users/adayr/Desktop/test.txt"))
            using (StreamReader file2 = new StreamReader("C:/Users/adayr/Desktop/Test1.txt"))
            {
                while (true)
                {
                    if (file1.EndOfStream || file2.EndOfStream)
                        break;
                    string file1txt = file1.ReadLine();
                    string file2txt = file2.ReadLine();
                    Assert.AreEqual(file1txt, file2txt);
                }
            }
        }
    }
}



