# GameC
##Purpose
This is student project made as a final work for subject named Designing and Developing Object-Oriented Higgh-Level Applications.
The task was to extend completed game using design patterns. The previous version of the game can be found [there](https://github.com/JakubChecinski/GameC).
##Changes
###New monster group
####Wizard
Wizard is a Monster, whose attack strength depends on is actual state and random generator. There are several strategies of the attack. There is also corresponding class implementing factory method named "WizardFactory".
In addition, wizard's attacks are depend on actual user's level and mystery Wizard's degree, which is generate by random number. 
4 strategies:
* SuperPower - only as 'life saver' used sometimes as last move
* Unarmed - using when magicPower ended
* Weak - using depends on random number generator
* Casual - default move
####The Groke
The Groke is a globally known monster from "Tke Moomins". It scares every children, and have levels depends on user actual level. Attack strategy updates every move, dependently on received damage. There is corresponding class implementing factory method named "TheGrokeFactory". 