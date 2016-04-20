using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization;

namespace GameCore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IGoods Basalt;
        IGoods Granulate;

        IPrimaryProducer BasaltField;

        ISecondaryProducer BasaltExtraction;

        [TestInitialize]
        public void InitTest()
        {
            Basalt = new Goods { Name = "Basalt" };
            Granulate = new Goods { Name = "Granulate" };

            BasaltField = new PrimaryProducer { Name = "BasaltField", Produces = Basalt };
            BasaltExtraction = new SecondaryProducer { Name = "BasaltExtraction", Consumes = { Basalt }, Produces = Granulate };
        }

        [TestMethod]
        public void SecondaryProduce_Name_Is_BasaltExtraction()
        {
            // Arrange
            const string Name = "BasaltExtraction";

            // Act
            var x = BasaltExtraction;

            // Assert
            Assert.AreEqual(Name, x.Name);
        }

        [TestMethod]
        public void Write_BasaltExtraction_To_File()
        {
            // Arrange
            const string FileName = @"C:\Users\Stephen\Documents\Visual Studio 2015\Projects\GameEditor\GameCore.UnitTest\TestResults\BasaltExtraction.xml";
            var x = BasaltExtraction as SecondaryProducer;

            // Act
            using(var writer = new FileStream(FileName, FileMode.Create))
            {
                x.WriteObject(writer);
            }
        }

        [TestMethod]
        public void Read_BasaltExtraction_From_File()
        {
            // Arrange
            const string FileName = @"C:\Users\Stephen\Documents\Visual Studio 2015\Projects\GameEditor\GameCore.UnitTest\TestResults\BasaltExtraction1.xml";
            var x = new SecondaryProducer();

            // Act
            using (var reader = new FileStream(FileName, FileMode.Open))
            {
                x.ReadObject(reader);
            }
        }

    }
}
