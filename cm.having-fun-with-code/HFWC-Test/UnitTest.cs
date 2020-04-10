using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFWC_Luxoft_Spreadsheet;
using System.Collections.Generic;

namespace HFWC_Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void When_Needs_To_Substring_And_Concatenate()
        {
            string actual = "A1+B1";
            string expected = "A9+B1";
            int index = 1;
            string replaceBy = "9";

            actual = Program.InsertRemove(actual, index, replaceBy);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Needs_To_Split_By_Comma()
        {
            string actual = "DEF*1,2+ABC+3,4-GHI";
            string expected = "DEF*5+ABC+7-GHI";

            string[,] matrix = new string[,]
	        {
	            {"0", "0", "0", "0", "0"},
	            {"0", "0", "5", "0", "0"},
                {"0", "0", "0", "0", "0"},
                {"0", "0", "0", "0", "7"},
                {"0", "0", "0", "0", "0"}
	        };

            actual = Program.ReplaceMatrixGetValue(actual, matrix);

            Assert.AreEqual(expected, actual);
        }
    }
}
