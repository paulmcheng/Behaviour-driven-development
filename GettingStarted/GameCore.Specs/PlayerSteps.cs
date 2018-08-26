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

        [Given]
        public void Given_I_m_a_new_player()
        {
            _player = new Player();
        }

        [When]
        public void When_I_take_P0_damage(int p0)
        {
            _player.Hit(p0);
        }

        [Then]
        public void Then_My_health_should_be_P0(int p0)
        {
            Assert.Equal(_player.Health, p0);
        }

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table)
        //{
        //    var race = table.Rows.First(row => row["attribute"] == "Race")["Value"];
        //    var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["Value"];

        //    double.TryParse(resistance, out double resistanceValue);

        //    _player.Resistance = resistanceValue;
        //    _player.Race = race;
        //}

    }
}
