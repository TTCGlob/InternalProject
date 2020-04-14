Feature: TricentisWebShop
	Scenarios on the Tricentis web shop site

@frontend
Scenario: Login to the webshop
	Given I navigate to to the webshop
	And I click the log in link
	When I login as the default user
	Then I should be logged in

@cart
Scenario: Add product to cart
	Given I log in to the webshop
	And I navigate to the "Books" category
	When I add "Computing and Internet" to my cart
	Then The notification bar should say "The product has been added to your shopping cart"
	And The shopping cart should indicate it has 1 item in it