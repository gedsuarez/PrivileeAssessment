# Privilee Assessment
This repository is covers the automation testing some features of Privilee's Staging website covering viewing venue for each criterie (Pool & Beach, Fitness, Family Activity, Waterpark, and Dining). This also covers searching a venue and filtering.
            
Automation tool utilized is Playwright with C# and ReqnRoll as a BDD tool for better readability. Directory profile are as follows:
* Drivers - should contains specific context (proxy or cookies settings) if there are but as of this iteration, no context testing was needed.
* Features - contains the test scenarios in BDD/Gherkin format
* StepDefinitions - Contains the Bindings that are used by the Features
* Support - Contains the Page Object Models and Utilities
  * Pages - Contains the Page Object Models
  * Utilities - Contains the functions
* runsettings - contains the environment variables used by the automation

## Setup
1. Install dotnet from their website
2. Install Visual Studio 2022 <- This is where we will run the tests
3. Clone the repository
4. Open the solution `PrivileeAssessment` using Visual Studio 2022
5. Ensure that the NuGet Package Managers are installed. To verify, click on `Tools->NuGet Package Manager->Manage NuGet Packages for Solution`. It should contain the following under `Installed` tab:
```bash
- Microsoft.Net.Test.Sdk
- Microsoft.Playwright
- Microsoft.Playwright.NUnit
- NUnit
- NUnit3TestAdapter
- Reqnroll.NUnit
```
6. Configure runsettings by clicking `Test->Configure Run Settings->Select Solution Wide runsettings File`

## Usage
1. Open `Test Explorer` by clicking `View->Test Explorer`
2. Build the solution by clicking `Build->Build Solution`
3. Run the tests in the `Test Explorer`

NOTE: Currently, headless is set as true. If you want to change the run to `headless=false`, update the `Privilee.runsettings` <HEADLESS> value
