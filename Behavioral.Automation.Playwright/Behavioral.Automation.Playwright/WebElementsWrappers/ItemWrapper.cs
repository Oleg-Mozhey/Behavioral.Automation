using System;
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
        Console.WriteLine($"Selector for item is {selector.BaseElementSelector}");
        ItemSelector = selector;
    }
    
    public ILocator AddToCartButton
    {
        get
        {
            Console.WriteLine("Trying to get locator for add to cart button:");
            Console.WriteLine($"Selector for finding child: {ItemSelector.AddToCartButtonSelector.Selector}");
            var childLocator = GetChildLocator(ItemSelector.AddToCartButtonSelector);
            Console.WriteLine($"Locator: {childLocator}");
            return childLocator;
        }
    }

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