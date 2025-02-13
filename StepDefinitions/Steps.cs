using parallelexecution.Pages;

namespace parallelexecution.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private AssistLiveGuide assistLiveGuide;
        private Common common;

        public Steps()
        {
            assistLiveGuide = new AssistLiveGuide();
            common = new Common();
        }
       
        [When(@"i press the '([^']*)'")]
        public void WhenIPressThe(string assistLiveGuidePlugin)
        {
            common.PluginPage(assistLiveGuidePlugin);
        }

        [Then(@"Validate header is displayed on the '([^']*)' page")]
        public void ThenValidateHeaderIsDisplayedOnThePage(string assistLiveGuide)
        {
            common.validateTitle(assistLiveGuide);
        }

        [Then(@"Validate '([^']*)' is Displayed")]
        public void ThenValidateIsDisplayed(string closeButton)
        {
            throw new PendingStepException();
        }

    }
}
