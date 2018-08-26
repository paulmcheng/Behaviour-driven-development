Feature: Player
	In order to play the game
	As a human player
	I want the health of the player to be correctly respresented

Background: 
	Given I'm a new player

# Single scenario
@health
Scenario: Taking no damage when hit doesn't affect health
	#Given I'm a new player
	When I take 0 damage
	Then My health should be 100

# Using scenario outlines
Scenario Outline: Starting health is reduced when hit
	#Given I'm a new player
	When I take <damage> damage 
	Then my health should be <expectedHealth>

	Examples: 
	| damage | expectedHealth |
	| 0      | 100            |
	| 10     | 90             |
	| 50     | 50             |
	| 99     | 1              |
	| 100    | 0              |

# Using data tables in scenario steps
#Scenario: Starting health is reduced when hit
#	Given I'm a new player
#	And I have the following attributes
#	Examples: 
#	| attribute  | value |
#	| Race       | Elf   |
#	| Resistance | 30    |
#	When I take 40 damage 
#	Then my health should be 90 