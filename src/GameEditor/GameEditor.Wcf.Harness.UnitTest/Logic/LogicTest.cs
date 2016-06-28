using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEditor.Wcf.Harness.UnitTest.Logic
{
    [TestClass]
    public class LogicTest
    {
        public class DateLogic
        {
            public int MinDate { get; set; }
            public int MaxDate { get; set; }

            public bool FilterDate(int min, int max)
            {
                return MinDate >= min && MinDate <= max || MinDate <= min && MaxDate >= min;
                //return MinDate <= min && MaxDate >= max;
            }
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public int MinDate { get; set; }
        public int MaxDate { get; set; }

        public DateLogic TestClass { get; set; }

        [TestInitialize]
        public void Initialise()
        {
            TestClass = new DateLogic();
            Min = -3000;
            MinDate = -2500;
            Max = -1000;
            MaxDate = -1500;
        }

        [TestMethod]
        public void FilterDate_Min_Greater_Than_MinDate_And_Max_Smaller_Than_MaxDate_Returns_True()
        {
            // Arrange
            TestClass.MinDate = MinDate;
            TestClass.MaxDate = MaxDate;

            // Act
            var actual = TestClass.FilterDate(Min, Max);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void FilterDate_Min_Smaller_Than_MinDate_And_Max_Greater_Than_MinDate_Returns_True()
        {
            // Arrange
            TestClass.MinDate = Min;
            TestClass.MaxDate = MaxDate;

            // Act
            var actual = TestClass.FilterDate(MinDate, Max);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void FilterDate_Min_Greater_Than_MinDate_And_Min_Smaller_Than_MaxDate_Returns_True()
        {
            // Arrange
            TestClass.MinDate = MinDate;
            TestClass.MaxDate = Max;

            // Act
            var actual = TestClass.FilterDate(Min, MaxDate);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void FilterDate_Min_Smaller_Than_MinDate_And_Max_Greater_Than_MaxDate_Returns_False()
        {
            // Arrange
            TestClass.MinDate = MaxDate;
            TestClass.MaxDate = Max;

            // Act
            var actual = TestClass.FilterDate(Min, MinDate);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void FilterDate_Min_Greater_Than_MinDate_And_Max_Greater_Than_MaxDate_Returns_False()
        {
            // Arrange
            TestClass.MinDate = Min;
            TestClass.MaxDate = MinDate;

            // Act
            var actual = TestClass.FilterDate(MaxDate, Max);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
