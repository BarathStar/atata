﻿using NUnit.Framework;

namespace Atata.Tests
{
    public class ControlTests : UITestFixture
    {
        [Test]
        public void Control_DragAndDrop_UsingDragAndDropUsingScriptBehavior()
        {
            Go.To<DragAndDropPage>().
                DropContainer.Items.Should.BeEmpty().
                DragItems.Items.Should.HaveCount(2).
                DragItems[x => x.Content == "Drag item 1"].DragAndDropTo(x => x.DropContainer).
                DragItems[0].DragAndDropTo(x => x.DropContainer).
                DropContainer.Items.Should.HaveCount(2).
                DragItems.Items.Should.BeEmpty().
                DropContainer[1].Content.Should.Equal("Drag item 2");
        }
    }
}
