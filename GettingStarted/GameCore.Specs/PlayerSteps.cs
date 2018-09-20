using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

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

        [Given(@"I have the following dynamic attributes")]
        public void GivenIHaveTheFollowingDynamicAttributes(Table table)
        {
            dynamic attributes = table.CreateDynamicInstance();

            _player.Resistance = attributes.Resistance;
            _player.Race = attributes.Race;
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

        [Given(@"I have the following magic items")]
        public void GivenIHaveTheFollowingMagicItems(Table table)
        {
            //List<MagicItem> magicItems = new List<MagicItem>();
            //foreach(var row in table.Rows)
            //{
            //    string item = row["item"];
            //    int cost = int.Parse(row["value"]);
            //    int power = int.Parse(row["power"]);
            //    magicItems.Add(new MagicItem(item, cost, power));
            //}
            IEnumerable<MagicItem> magicItems = table.CreateSet<MagicItem>();

            _player.MagicItems.AddRange(magicItems);
        }

        [Given(@"I have the following dynamic magic items")]
        public void GivenIHaveTheFollowingDynamicMagicItems(Table table)
        {

            IEnumerable<dynamic> magicItems = table.CreateDynamicSet();
            foreach (var item in magicItems)
            {
                string name = item.item;
                int cost = item.cost;
                int power = item.power;
                _player.MagicItems.Add(new MagicItem
                {
                    Name = name,
                    Cost = cost,
                    Power = power
                });
            }
        }

        [Then(@"My total magic power should be (.*)")]
        public void ThenMyTotalMagicPowerShouldBe(int expectedPower)
        {
            Assert.Equal(_player.MagicPower, expectedPower);
        }

        [Then(@"I should be dead")]
        public void ThenIShouldBeDeath()
        {
            Assert.Equal(_player.IsDead, true);
        }

        [Given(@"My race is (.*)")]
        public void GivenMyRaceIs(string raceName)
        {
            _player.Race = raceName;
        }

        [Given(@"I have a magical item (.*) with a power of (.*)")]
        public void GivenIHaveAMagicalItemWithAPowerOf(string magicalItemName, int power)
        {
            _player.AddMagicItem(new MagicItem() { Name =  magicalItemName, Power = power});
        }

        [When(@"I use the magical item (.*)")]
        public void WhenIUseTheMagicalItem(string magicalItemName)
        {
            _player.UseMagicalItem(magicalItemName);
        }

        [Then(@"the power of magical item (.*) should be (.*)")]
        public void ThenThePowerOfMagicalItemShouldBe(string magicalItemName, int expectedPower)
        {
            MagicItem magicalItem = _player.MagicItems.First(item => item.Name == magicalItemName);
            Assert.Equal(magicalItem.Power, expectedPower);
        }

    }
}
