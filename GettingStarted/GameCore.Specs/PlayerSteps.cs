using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
namespace GameCore.Specs
{
    //David Aamaie
    [Binding]
    public class PlayerSteps
    {
        private Player _player;

        [Given(@"I'm a new player")]
        public void GivenIMANewPlayer()
        {
            _player = new Player();
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            _player.Hit(p0);
        }

        [Then(@"My health should be (.*)")]
        public void ThenMyHealthShouldBe(int p0)
        {
            Assert.Equal(_player.Health, p0);
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];

            _player.Resistance = int.Parse(resistance);
            _player.Race = race;
        }
        [Given(@"My character class is (.*)")]
        public void GivenMyCharacterClassIsHealer(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }


    }
}
