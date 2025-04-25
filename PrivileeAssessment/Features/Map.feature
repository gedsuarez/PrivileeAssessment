Feature: Map

@functional
Scenario: View a pool and beach venue
	Given the user proceeds to Privilee map website
	When the user clicks on "Fairmont The Palm"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: Search a pool and beach venue
	Given the user proceeds to Privilee map website
	When the user searches "Fairmont The Palm"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a fitness venue
	Given the user proceeds to Privilee map website
	And the user clicks the "Fitness" button
	When the user clicks on "Mantra"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a family activity venue
	Given the user proceeds to Privilee map website
	And the user clicks the "Family activities" button
	When the user clicks on "Popsicle Kids Club"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a dining venue
	Given the user proceeds to Privilee map website
	And the user clicks the "Dining" button
	When the user clicks on "La Nena Coffee"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a waterpark venue
	Given the user proceeds to Privilee map website
	And the user clicks the "Waterparks" button
	When the user clicks on "Jungle Float"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: Search a non-existing venue
	Given the user proceeds to Privilee map website
	When the user searches "nonexisting venue"
	Then the user should see no results found

@functional @data_accuracy
Scenario: View an annual member only waterpark venue
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	And the user clicks on "Legoland Water Park"
	Then the user should see the venue is correct
	And the user should see a message indicating that it is an annual member only venue

@user_interface @data_accuracy
Scenario: Annual members only ticked off button should display lock overlay
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	Then the user should see a lock overlay when venue is for annual members only

@user_interface @data_accuracy
Scenario: Annual members only ticked on button should display lock overlay
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	And the user ticks the Annual members only button
	Then the user should not see a lock overlay when venue is for annual members only

@user_interface @data_accuracy
Scenario: Filter Abu Dhabi as location on pool and beach venues
	Given the user proceeds to Privilee map website
	When the user filters "Abu Dhabi" as location
	Then the user should see venues with the filtered locations

@user_interface @data_accuracy
Scenario: Multiple filters are selected in fitness venues producing no results
	Given the user proceeds to Privilee map website
	When the user clicks the "Fitness" button
	And the user clicks on "Studio;Recovery;Sauna" filters
	Then the user should that there are no venues matching the selected filters