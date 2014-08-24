/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using System;
using System.Diagnostics;
using LearnByErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ChilderenMatrixTests
    {
        [TestMethod]
        public void VectorHorizontalTests()
        {
            try
            {
                VectorHorizontal vh = new VectorHorizontal(3);
                vh[0] = 1;
                vh[1] = 2;
                vh[2] = 3;
                Assert.AreEqual(1, vh[0]);
                Assert.AreEqual(2, vh[1]);
                Assert.AreEqual(3, vh[2]);

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
