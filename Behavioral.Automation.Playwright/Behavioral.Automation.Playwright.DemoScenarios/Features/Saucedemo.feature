Feature: Saucedemo

  Background: 
    Given application URL is opened
    And user entered "standard_user" into "Username"
    And user entered "secret_sauce" into "Password"
    And user clicked on "Login button"

#Закончить тест с покупкой.
#Последний шаг должен проверить надпись "Checkout: Complete!".
  Scenario: Purchase
    When user clicks on "Add Backpack to Cart"
    Then the "Shopping cart badge" text should be "1"
    When user clicks on "Shopping cart link"
    Then the "Page header" text should be "Your Cart"
    When user clicks on "Checkout button"
    Then the "Page header" text should be "Checkout: Your Information"
    When user enters "James" into "First name input"
    And user enters "Bond" into "Last name input"
    And user enters "236011" into "Zip postal code input"
    And user clicks on "Continue checkout button"
    Then the "Page header" text should be "Checkout: Overview"
    When user clicks on "Finish checkout button"
    Then the "Page header" text should be "Checkout: Complete!"

  #Покрыть сценарий, который проверит количество айтемов (элементов) товаров на странице.
  #Их шесть.
  #Для этого нужно будет реализовать новый шаг.
  Scenario: There are 6 items available for buying
    Then "Items list" has "6" items

  #Реализовать враппер для элемента товара который будет содержать поля с  названием, кнопку добавления в корзину и удаления из корзины.
  #Реализовать шаг, который будет добавлять и удалять из корзины по имени товара.
  #Пример: When user adds the "Sauce Labs Backpack" item from "Items" to the cart
  #Пример: When user removes the "Sauce Labs Backpack" item from "Items" from the cart
  #(Можно переформулировать шаг на свой вкус, можно использовать табличку как параметр)
  Scenario: Item can be added into shopping cart and deleted
    When user adds the "Sauce Labs Backpack" item from "Items list" to the cart
    Then the "Shopping cart badge" text should be "1"
    When user adds the "Sauce Labs Bike Light" item from "Items list" to the cart
    Then the "Shopping cart badge" text should be "2"
    When user removes the "Sauce Labs Backpack" item from "Items list" from the cart
    Then the "Shopping cart badge" text should be "1"
    