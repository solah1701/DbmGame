using System;
using GameCore.DebellisMultitudinis;
using GameCore.DebellisMultitudinis.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCore.UnitTest
{
    [TestClass]
    public class DbmUnitTest
    {
        [TestMethod]
        public void When_Unit_Is_General_Non_Ally_Regular_Superior_Knight_Cost_Is_35()
        {
            // Arrange
            const int expected = 35;

            // Act
            var unit = new Unit
            {
                IsGeneral = true,
                DisciplineType = DisciplineTypeEnum.Regular,
                GradeType = GradeTypeEnum.Superior,
                UnitType = UnitTypeEnum.Knights
            };

            // Assert
            Assert.AreEqual(expected, unit.Cost);
        }
    }
}
