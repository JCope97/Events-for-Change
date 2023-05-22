@Antonia

Feature: MA-29-Edit-User-Information

    There is the ability for users to update information tied to their account.

    Scenario: There exists an explanation message on the Edit Info page
        Given I am a user that is registered 
            And I login
        When I am on the "EditInfo" page
        Then the page presents an explanation message

    Scenario: The page presents a submit button
        Given I am a user that is registered 
            And I login
        When I am on the "EditInfo" page
        Then the page presents a submit button

    Scenario: There exists a form to update information
        Given I am a user that is registered 
            And I login
        When I am on the "EditInfo" page
        Then the page presents a form for editing information

    Scenario: A non-registered user/visitor cannot access the edit profile page
        Given I am a visitor
        When I am on the "EditInfo" page
        Then I am redirected to the "EditLogin" page

    Scenario: Once I successfully submit the form, I am redirected to the Home page
        Given I am a user that is registered 
            And I login
        When I am on the "EditInfo" page
            And I fill out the form
            And I click submit
        Then I am redirected to the "Home" page

    Scenario: Once I successfully submit the form and go back to the Edit Info page, then I see my updated info
        Given I am a user that is registered 
            And I login
            And I am on the "EditInfo" page
            And I fill out the form
            And I click the submit button
        When I navigate back to the "EditInfo" page
        Then I can see my updated information in the form

