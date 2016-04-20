using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEditor.Views.UI;
using NSubstitute;
using GameEditor.Controllers.UI;
using System.Collections.Generic;

namespace GameEditor.UnitTest
{
    [TestClass]
    public class UIListControlTest
    {
        private IUIListView ListView { get; set; }
        private IUIListController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ListView = Substitute.For<IUIListView>();
            Controller = new UIListController();
            Controller.SetView(ListView);
        }

        [TestMethod]
        public void SetupList_Test()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            ListView.Items = new List<string>();

            // Act
            Controller.SetupList(list);
            Controller.AddItems(list);

            // Assert
            CollectionAssert.AreEqual(ListView.Items, list);
        }

        [TestMethod]
        public void ItemSelected_Before_Selection_Selected_Is_String_Empty()
        {
            // Arrange

            // Act
            var actual = ListView.Selected;

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void ItemSelected_Select_Second_Item()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var item = "Second";
            ListView.Items.Returns(list);

            // Act
            //Controller.ItemSelected(item);
            var actual = ListView.Selected;

            // Assert
            Assert.AreEqual(item, actual);
        }

        [TestMethod]
        public void ItemSelected_Select_Invalid_Item_Returns_String_Empty()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            //var item = "Invalid";
            ListView.Items.Returns(list);

            // Act
            //Controller.ItemSelected(item);
            var actual = ListView.Selected;

            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void ItemSelected_Select_Invalid_Item_Returns_Second()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var previousItem = "Second";
            //var item = "Invalid";
            ListView.Items.Returns(list);
            ListView.Selected.Returns(previousItem);

            // Act
            //Controller.ItemSelected(item);
            var actual = ListView.Selected;

            // Assert
            Assert.AreEqual(previousItem, actual);
        }

        [TestMethod]
        public void RemoveItem_If_No_Item_Selected_Nothing_Is_Removed()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var expected = list.Count;
            ListView.Items.Returns(list);

            // Act
            Controller.RemoveItem();
            var actual = ListView.Items.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItem_If_Item_Selected_Count_Is_Reduced_By_One()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var expected = list.Count - 1;
            ListView.Items.Returns(list);
            ListView.Selected.Returns("Second");

            // Act
            Controller.RemoveItem();
            var actual = ListView.Items.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItem_If_Item_Selected_List_No_Longer_Contains_Item()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var expected = "Second";
            ListView.Items.Returns(list);
            ListView.Selected.Returns(expected);

            // Act
            Controller.RemoveItem();

            // Assert
            CollectionAssert.DoesNotContain(ListView.Items, expected);
        }

    }
}
