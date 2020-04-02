Feature: My 2Unlimited

Background: 
	Given Webpage http://demowebshop.tricentis.com/ is loaded
	And Switch to Log in page
	
@mytag
Scenario Outline: Exesise Email field on Login page
	When I enter <email> in Email field
	And Change the focus
	Then I can see the error message

	Examples:
	| variant      | email |
	| just text    | abc   |
	| just numbers | 123   |

