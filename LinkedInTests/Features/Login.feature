Feature: Login
User Logs in with valid credentials (username, password)
Home page will load after successfull login

Background: 
	Given User will be on the login page

@positive
Scenario Outline: Login with Valid Credentials
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on Login button
	Then User will be redirected to Homepage
Examples:
	| UserName    | Password |
	| abc@xyz.com | 12345    |
	| def@xyz.com | 76765    |


@negative
Scenario Outline: Login with InValid Credentials
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on Login button
	Then Error Message for Password Length should be thrown
Examples:
	| UserName    | Password |
	| abc@xyz.com | 12345    |
	| def@xyz.com | 76765    |


@regression
Scenario Outline: Check for Password Show Display
	When User will enter password '<Password>'
	And User will click on Show Link in the password textbox
	Then Password characters should shown
Examples:
	| Password |
	| 12345    |
	| 76765    |

@regression
Scenario Outline: Check for Password Hidden Display
	When User will enter password '<Password>'
	And User will click on Show Link in the password textbox
	And User will click on Hide Link in the password textbox
	Then Password characters should not be shown
Examples:
	| Password |
	| 12345    |
	| 76765    |