# GameC

## Purpose
This is student project made as a final work for subject named Designing and Developing Object-Oriented High-Level Applications.
The task was to extend completed game using design patterns. The previous version of the game can be found [there](https://github.com/JakubChecinski/GameC).
## Changes

### New monsters

#### Wizard
Wizard is a Monster, whose attack strength depends on is actual state and random generator. There are several strategies of the attack. There is also corresponding class implementing factory method named "WizardFactory".
In addition, wizard's attacks are depend on actual user's level and mystery Wizard's degree, which is generate by random number. 
4 attack strategies:
* SuperPower - only as 'life saver' used sometimes as last move
* Unarmed - using when magicPower ended
* Weak - using depends on random number generator
* Casual - default move
#### The Groke
The Groke is a globally known monster from "The Moomins". It scares every children, and have levels depends on user actual level. Attack strategy updates every move, dependently on received damage. There is corresponding class implementing factory method named "TheGrokeFactory". 
4 attack strategies basing on the received damage and random generator:
* Freeze - used if received damage is high enough
* Rest - used to improve health
* Spell - used if the magic attack was low enough

Movement variants are added to special container, then one of them is drawn.

### New items
All new items are located in new directory "./Items/Weapon" and are added to "WeaponFactory" which produces them.

#### Minthril Armor
Minthril armor is a very expensive and rare item which makes player nearly immortal. It is more useful if the player is "a friend of dwarfs". It means that player has to have an basic axe to unlock all possibilities of the item.

#### Super Sword
This item improves player's health and stamina but main power is it increases next attack by 40% od the last last received damage.

#### Wand
Wand is a magical artifact which gives more resistance to magical attacks, improves player's magic ad health and increases power of taking opponent's magical power.
  
