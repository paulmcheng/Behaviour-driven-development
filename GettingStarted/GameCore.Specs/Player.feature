Feature: Player
	In order to play the game
	As a game player
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
	Then My health should be <expectedHealth>

	Examples: 
	| damage | expectedHealth |
	| 0      | 100            |
	| 10     | 90             |
	| 50     | 50             |
	| 99     | 1              |
	| 100    | 0              |

#Using data tables in scenario steps
Scenario: Elf race characters get additional 30 damage resistance
	#Given I'm a new player
	And I have the following attributes
	| attribute  | value |
	| Race       | Elf   |
	| Resistance | 30    |
	When I take 40 damage 
	Then My health should be 90 

Scenario: Human race characters get additional 0 damage resistance
	#Given I'm a new player
	And I have the following dynamic attributes
	| attribute  | value |
	| Race       | Human   |
	| Resistance | 0    |
	When I take 40 damage 
	Then My health should be 60 

# Cast enum 
Scenario: Healers restore all health
	#Given I'm a new player
	Given My character class is Healer
	When I take 40 damage
	And Cast a healing spell
	Then My health should be 100

#Using data tables in scenario steps
Scenario: Total magical power
	And I have the following magic items
	| item   | cost  | power |
	| Ring   | 100   | 100   |
	| Hat    | 30    | 200   |
	| Gloves | 100   | 400   |
	Then My total magic power should be 700

	#Using data tables in scenario steps
Scenario: Total dynamic magical power
	And I have the following dynamic magic items
	| item   | cost  | power |
	| Ring   | 100   | 100   |
	| Hat    | 30    | 200   |
	| Gloves | 100   | 400   |
	Then My total magic power should be 700