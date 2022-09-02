using Behavioral.Automation.Playwright.Context;
using Behavioral.Automation.Playwright.ElementSelectors;

namespace Behavioral.Automation.Playwright.WebElementsWrappers;

public class ItemsListWrapper : WebElementWrapper
{
    private readonly WebContext _webContext;
    private readonly ElementSelector _selector;
    public ItemsListWrapper(WebContext webContext, ElementSelector selector, string caption) : base(webContext, selector, caption)
    {
        _webContext = webContext;
        _selector = selector;
    }

    public ItemWrapper GetItem(string title)
    {
        return new ItemWrapper(_webContext, new ItemSelector(_selector, title), title);
    }
}