Feature: ParallelExecution
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](parallelexecution/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@launch
Scenario: AssistLiveGuide
When i press the 'AssistLiveGuidePlugin'
Then Validate header is displayed on the 'AssistLiveGuide' page
And Validate 'CloseButton' is Displayed 
	