using System.Threading.Tasks;
using Behavioral.Automation.Playwright.Context;
using Behavioral.Automation.Playwright.ElementSelectors;
using Microsoft.Playwright;

namespace Behavioral.Automation.Playwright.WebElementsWrappers;

public class ItemWrapper : WebElementWrapper
{
    public readonly ItemSelector ItemSelector;
    
    public ItemWrapper(WebContext webContext, ItemSelector selector, string caption) : base(webContext, selector.CurrentElementSelector, caption)
    {
        ItemSelector = selector;
    }
    
    public ILocator AddToCartButton => GetChildLocator(ItemSelector.AddToCartButtonSelector);

    public ILocator RemoveFromCartButton => GetChildLocator(ItemSelector.RemoveFromCartButtonSelector);

    public async Task AddToCart()
    {
        await AddToCartButton.ClickAsync();
    }

    public async Task RemoveFromCart()
    {
        await RemoveFromCartButton.ClickAsync();
    }
}