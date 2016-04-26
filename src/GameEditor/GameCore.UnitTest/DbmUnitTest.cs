using GameCore.DebellisMultitudinis;
using GameCore.DebellisMultitudinis.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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

        [TestMethod]
        public void When_Unit_Is_Elephant_Being_Attack_By_Mounted_Attack_Value_Is_5()
        {
            // Arrange
            const int expected = 5;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Mounted);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Elephants
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Unit_Is_Elephant_Being_Attack_By_Naval_Attack_Value_Is_3()
        {
            // Arrange
            const int expected = 3;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Naval);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Elephants
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Unit_Is_Elephant_Being_Attack_By_Foot_Attack_Value_Is_4()
        {
            // Arrange
            const int expected = 4;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Foot);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Elephants
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void When_Unit_Is_Spears_Being_Attack_By_Mounted_Attack_Value_Is_4()
        {
            // Arrange
            const int expected = 4;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Mounted);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Spear
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Unit_Is_Spears_Being_Attack_By_Naval_Attack_Value_Is_4()
        {
            // Arrange
            const int expected = 4;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Naval);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Spear
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Unit_Is_Spears_Being_Attack_By_Foot_Attack_Value_Is_4()
        {
            // Arrange
            const int expected = 4;
            var opposed = Substitute.For<IDbmUnit>();
            opposed.DispositionType.Returns(DispositionTypeEnum.Foot);
            var unit = new Unit
            {
                UnitType = UnitTypeEnum.Spear
            };

            // Act
            var actual = unit.GetAttackValue(opposed);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
