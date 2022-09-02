using Behavioral.Automation.Configs;
using Behavioral.Automation.Playwright.Configs;
using Behavioral.Automation.Playwright.ElementSelectors;

namespace Behavioral.Automation.Playwright.Pages;

class MainPage : ISelectorStorage
{
    private static readonly string Id = ConfigManager.GetConfig<Config>().SearchAttribute;
    
    //Login
    public ElementSelector Username = new() { IdSelector = "username"};
    public ElementSelector Password = new() { IdSelector = "password"};
    public ElementSelector LoginButton = new() { IdSelector = "login-button"};
    
    //Main page
    public ElementSelector PageHeader = new() {Selector = "//div[@class='header_secondary_container']/span"};

    //Items
    public ElementSelector AddBackpackToCart = new() { IdSelector = "add-to-cart-sauce-labs-backpack" };
    public ElementSelector ShoppingCartLink = new() {Selector = "//a[@class='shopping_cart_link']" };
    public ElementSelector ItemsList = new() {Selector = "//div[@class='inventory_list']"};
    
    //ShoppingCart
    public ElementSelector ShoppingCartBadge = new() { Selector = "//span[@class='shopping_cart_badge']" };
    public ElementSelector CheckoutButton = new() { IdSelector = "checkout" };
    public ElementSelector ContinueCheckoutButton = new() {IdSelector = "continue"};
    public ElementSelector FinishCheckoutButton = new() {IdSelector = "finish"};
    public ElementSelector FirstNameInput = new() {IdSelector = "firstName"};
    public ElementSelector LastNameInput = new() {IdSelector = "lastName"};
    public ElementSelector ZipPostalCodeInput = new() {IdSelector = "postalCode"};
}