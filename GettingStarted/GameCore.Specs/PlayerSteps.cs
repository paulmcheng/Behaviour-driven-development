using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerSteps
    {
        [Given(@"I am a new player")]
        public void GivenIAmANewPlayer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
