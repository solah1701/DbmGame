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
            ListView.Items.Returns(new List<string>());
            ListView.ClearReceivedCalls();
        }

        [TestMethod]
        public void SetView_View_ClearList_Called()
        {
            // Arrange

            // Act
            Controller.SetView(ListView);

            // Assert
            ListView.Received(1).ClearList();
        }

        [TestMethod]
        public void AddItem_View_AddItem_Called()
        {
            // Arrange
            const string item = "SomeItem";

            // Act
            Controller.AddItem(item);

            // Assert
            ListView.Received(1).AddItem(item);
        }

        [TestMethod]
        public void RemoveItem_View_RemoveItem_Called_If_Selected_Exists()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var selected = "Third";
            ListView.Items.Returns(list);
            ListView.Selected.Returns(selected);

            // Act
            Controller.RemoveItem();

            // Assert
            ListView.Received(1).RemoveItem(selected);
        }

        [TestMethod]
        public void RemoveItem_View_RemoveItem_Not_Called_If_Selected_Does_Not_Exist()
        {
            // Arrange
            var list = new List<string> { "First", "Second", "Third" };
            var selected = "DoesNotExist";
            ListView.Items.Returns(list);
            ListView.Selected.Returns(selected);

            // Act
            Controller.RemoveItem();

            // Assert
            ListView.DidNotReceive().RemoveItem(selected);
        }
    }
}
