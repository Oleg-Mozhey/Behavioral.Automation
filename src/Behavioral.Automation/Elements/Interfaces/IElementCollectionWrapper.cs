﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace Behavioral.Automation.Elements.Interfaces
{
    public interface IElementCollectionWrapper : IWebElementWrapper
    {
        IEnumerable<IWebElementWrapper> Elements { [NotNull, ItemNotNull] get; }

        void ClickByIndex(int index);

        string GetAttributeByIndex([NotNull] string attribute, int index);
    }
}
