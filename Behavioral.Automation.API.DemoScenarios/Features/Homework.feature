Feature: Homework
Задание:
API Проект Behavioral.Automation.API.DemoScenarios.
Покрыть 2 сценария, которые проверят 1 успешный и 1 не успешный ответ тестового сервера https://reqres.in/

  Scenario: Database entries can be updated (example of positive case)
    When user sends a "PATCH" request to "api/users/5" url with the json:
      """
      {
        "name": "Ivan Ivanich",
        "job": "QA"
      }
      """
    Then response json path "$.updatedAt" value should not be empty

  Scenario: Users information can be retrieved by API call (delay simulation + example of positive case)
    When user sends a "GET" request to "api/users" url with the following parameters:
      | Name  | Value | Kind  |
      | delay | 3     | Param |
    Then response json path "$.data[?(@.last_name == 'Morris')].first_name" value should be "["Charles"]"

  Scenario: Call to wrong endpoint should return appropriate error (it could be a bug, example of negative case)
    Given user creates a "GET" request to "api/wrong_url" url
    And expected response status code is "404"
    When user sends request