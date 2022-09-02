using System.Threading.Tasks;
using Behavioral.Automation.Playwright.WebElementsWrappers;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Behavioral.Automation.Playwright.Bindings;

[Binding]
public class ItemsListBinding
{
    [Then(@"""(.*)"" has ""(\d*)"" items")]
    public async Task ThenHasItems(ItemsListWrapper element, int quantity)
    {
        //var innerElements = element.Locator.Locator("xpath=child::*");
        //var innerElements = element.Locator.Locator("text=Add to cart");
        var test = element.Locator.ToString();
        test = test + "  >> text=Add to cart";
        var innerElements = element.Locator.Locator("text=Add to cart");
        //xpath=child::*[contains(text(), '{title}')]

        await Assertions.Expect(innerElements).ToHaveCountAsync(quantity);
    }

    [When(@"user adds the ""(.*)"" item from ""(.*)"" to the cart")]
    public async Task WhenUserAddsTheItemFromToTheCart(string itemTitle, ItemsListWrapper list)
    {
        await list.GetItem(itemTitle).AddToCart();
    }

    [When(@"user removes the ""(.*)"" item from ""(.*)"" from the cart")]
    public async Task WhenUserRemovesTheItemFromFromTheCart(string itemTitle, ItemsListWrapper list)
    {
        await list.GetItem(itemTitle).RemoveFromCart();
    }
}