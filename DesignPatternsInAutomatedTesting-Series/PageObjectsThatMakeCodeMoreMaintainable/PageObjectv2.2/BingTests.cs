﻿// <copyright file="BingTests.cs" company="Automate The Planet Ltd.">
// Copyright 2019 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>http://automatetheplanet.com/</site>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PageObjectsThatMakeCodeMoreMaintainable.PageObjectv22
{
    [TestClass]
    public class BingTests 
    {
        private BingMainPage _bingMainPage;
        private IWebDriver _driver;

        [TestInitialize]
        public void SetupTest()
        {
            _driver = new FirefoxDriver();
            _bingMainPage = new BingMainPage(_driver);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void SearchForAutomateThePlanet()
        {
            _bingMainPage.Open();
            _bingMainPage.Search("Automate The Planet");
            _bingMainPage.AssertResultsCountIsAsExpected(264);
        }

        [TestMethod]
        public void SearchForAutomateThePlanet_Second()
        {
            _bingMainPage.Open();
            _bingMainPage.SearchBox.Clear();
            _bingMainPage.SearchBox.SendKeys("Automate The Planet");
            _bingMainPage.GoButton.Click();
            _bingMainPage.AssertResultsCountIsAsExpected(264);
        }
    }
}