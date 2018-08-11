Feature: Player
	In order to to play the game
	As a human player
	I want my character to be correctly represented

@mytag
Scenario: Taking no damage when hit has no effect to health
	Given I am a new player
	When I take 0 damage
	Then My health should now be 100
