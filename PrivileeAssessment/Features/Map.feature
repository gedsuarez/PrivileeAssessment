Feature: Map

@functional
Scenario: View a pool and beach venue
# The feature being tested: Viewing an existing pool and beach venue
# Expected outcome: The user should be able to view the venue details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the pool and beach details are displayed correctly
	Given the user proceeds to Privilee map website
	When the user clicks on "Fairmont The Palm"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: Search a pool and beach venue
# The feature being tested: Search feature for pool and beach venues
# Expected outcome: The user should be able to search the existing venue and view its details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the search functionality is working correctly
	Given the user proceeds to Privilee map website
	When the user searches "Fairmont The Palm"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a fitness venue
# The feature being tested: View feature for fitness venues
# Expected outcome: The user should be able to go to the fitness venue, click the venue, and view its details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the fitness page is loading correctly and user is able to view fitness details correctly
	Given the user proceeds to Privilee map website
	And the user clicks the "Fitness" button
	When the user clicks on "Mantra"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a family activity venue
# The feature being tested: View feature for family activity venues
# Expected outcome: The user should be able to go to the family activity venue, click the venue, and view its details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the family activity page is loading correctly and user is able to view family activity details correctly
	Given the user proceeds to Privilee map website
	And the user clicks the "Family activities" button
	When the user clicks on "Popsicle Kids Club"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a dining venue
# The feature being tested: View feature for dining venues
# Expected outcome: The user should be able to go to the dining venue, click the venue, and view its details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the dining page is loading correctly and user is able to view dining details correctly
	Given the user proceeds to Privilee map website
	And the user clicks the "Dining" button
	When the user clicks on "La Nena Coffee"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: View a waterpark venue
# The feature being tested: View feature for waterpark venues
# Expected outcome: The user should be able to go to the waterpark venue, click the venue, and view its details
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: To ensure that the waterpark page is loading correctly and user is able to view waterpark details correctly
	Given the user proceeds to Privilee map website
	And the user clicks the "Waterparks" button
	When the user clicks on "Jungle Float"
	Then the user should see the venue is correct

@functional @data_accuracy
Scenario: Search a non-existing venue
# The feature being tested: Ensure that the search functionality works correctly when venues searched as non-existing
# Expected outcome: The website is expected to show "No results found" message
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Ensure that the searching a non-existing venue returns the correct message/behavior
	Given the user proceeds to Privilee map website
	When the user searches "nonexisting venue"
	Then the user should see no results found

@functional @data_accuracy
Scenario: View an annual member only waterpark venue
# The feature being tested: Annual members only waterpark venue
# Expected outcome: The venue details are correctly displayed and Annual members only message is shown
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Guarantee that the annual members only venues are displayed correctly against those who are not annual members.
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	And the user clicks on "Legoland Water Park"
	Then the user should see the venue is correct
	And the user should see a message indicating that it is an annual member only venue

@user_interface @data_accuracy
Scenario: Annual members only ticked off button should display lock overlay
# The feature being tested: The tick button for Annual members only should display a lock overlay if it is not ticked
# Expected outcome: The lock overlay should NOT be displayed for venues that are for annual members only
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Better user experience for users who are not annual members and annual members
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	Then the user should see a lock overlay when venue is for annual members only

@user_interface @data_accuracy
Scenario: Annual members only ticked on button should display lock overlay
# The feature being tested: The tick button for Annual members only should display a lock overlay
# Expected outcome: The lock overlay should be displayed for venues that are for annual members only
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Better user experience for users who are not annual members and annual members
	Given the user proceeds to Privilee map website
	When the user clicks the "Waterparks" button
	And the user ticks the Annual members only button
	Then the user should not see a lock overlay when venue is for annual members only

@user_interface @data_accuracy
Scenario: Filter Abu Dhabi as location on pool and beach venues
# The feature being tested: Filter functionality for pool and beach venue
# Expected outcome: Grid only displays venues that were filtered
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Accurate venues should be displayed when a filter is applied
	Given the user proceeds to Privilee map website
	When the user filters "Abu Dhabi" as location
	Then the user should see venues with the filtered locations

@user_interface @data_accuracy
Scenario: Multiple filters are selected in fitness venues producing no results
# The feature being tested: Multiple filters functionality that produce no results
# Expected outcome: The website is expected to show no venues matching the selected filters
# Any setup or teardown procedures necessary for automation: Initialize the browser for setup and close it after the test
# Why you think this test is important: Ensure that filters that produce no results return the correct message/behavior
	Given the user proceeds to Privilee map website
	When the user clicks the "Fitness" button
	And the user clicks on "Studio;Recovery;Sauna" filters
	Then the user should that there are no venues matching the selected filters