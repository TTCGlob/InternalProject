Feature: TricentisWebShop
	Scenarios on the Tricentis web shop site

	@stef
Background: Navigate to url and log in
Given I navigated to the DemoWebShop website
	When I click the Log in link
	And I submit username and password
	Then the DetailPage displays

@stef
Scenario: Navigate to url and login
	Given I navigated to the DemoWebShop website
	When I click the Log in link
	Then the LoginPage displays with title "Welcome, Please Sign In!"

Scenario: Confirm Price of chosen item
	Given I navigated to the Books page
	When I click the "Computing and Internet" link
	Then I confirm price is "10.00"

	
Scenario: Add product to cart failed
Given I navigated to Computers > "Accessories"
When I add "TCP Coaching day" to my cart
Then the notification bar displays "This product requires the following product is added to the cart: TCP Instructor Led Training" 
And 0 item is visible in the cart


Scenario: Add product to cart
Given I navigated to "Electronics > Cell phones"
When I add "Smartphone" to my cart
Then the notification bar displays "This product has been added to the shopping cart"
And 1 item is visible in the cart 
