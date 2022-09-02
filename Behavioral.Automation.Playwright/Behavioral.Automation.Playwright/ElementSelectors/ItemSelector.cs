namespace Behavioral.Automation.Playwright.ElementSelectors;

public class ItemSelector : ElementSelector
{
    public ItemSelector(ElementSelector selector, string title)
    {
        BaseElementSelector = selector;
        this.title = title;
    }

    public readonly string title;
    
    
    public ElementSelector BaseElementSelector { get; }

    public ElementSelector CurrentElementSelector =>
        new()
            {Selector = $"{BaseElementSelector.Selector} >> xpath=child::*[.//div[contains(text(), '{title}')]]"};

    public ElementSelector AddToCartButtonSelector => new() {Selector = "text=Add to cart"};

    public ElementSelector RemoveFromCartButtonSelector => new() {Selector = "text=Remove"};
}