# Jumper exercise

## Intro
Deze tutorial is gemaakt om een agent zichzelf aan te leren om te springen over bepaalde obstakels maar ook om beloningspunten te herkennen en die wel te pakken.

## Obstakels en beloningen
De obstakels zijn kleine muurtjes die in een rechte lijn van het begin punt naar het eindpunt zullen bewegen. Deze bevat een collider om collisions te kunnen opmerken. Deze hebben altijd een rode kleur. Het rewardsysteem zit beschreven bij Agent
Afwisselend, door middel van een randomizer, die in het script van de agent zit,  worden tussen de obstakels ook beloningen afgevuurd op de agent. Deze zijn gerepresenteerd door groene muurtjes.
Ook zullen de beloningen een tag ‘Reward’ krijgen en de obstakels een tag ‘Obstacle’ om bij het einde van een episode afhankelijk van wat de agent gedaan heeft, een positieve of negatieve beloning uit te delen.

## Agent
De agent in het project is een kubus die over de obstakels leert springen, maar ook de beloningen leert nemen. Dit doet hij aan de hand van een script: Bij het begin van een episode wordt er een obstakel of beloning afgevuurd op de agent met een random snelheid. Vervolgens kunnen er 4 verschillende uitkomsten zich voordoen. 
Uitkomst #1:  Er wordt een beloning afgevuurd en de agent pakt deze. De agent zal een beloning van 1 krijgen en de episode zal eindigen waarna een nieuwe kan beginnen
Uitkomst #2: Er wordt een beloning afgevuurd en de agent ontwijkt deze. De agent zal een beloning krijgen van -0.5 en de episode zal eindigen waarna een nieuwe kan beginnen.
Uitkomst #3: Er wordt een obstakel afgevuurd en de agent pakt deze. De agent zal een beloning krijgen van -0.5 en de episode zal eindigen waarna een nieuwe kan beginnen.
Uitkomst #4:  Er wordt een obstakel afgevuurd en de agent ontwijkt deze. De agent zal een beloning van 1 krijgen en de episode zal eindigen waarna een nieuwe kan beginnen.
Een obstakel of beloning raken wordt mogelijk gemaakt door middel van colliders en een boolean die op true springt (“collisionWithObstacle” en “collisionWithReward”). Deze wordt terug op false gezet bij het begin van elke episode. Het ontwijken van een object wordt opgemerkt doordat het op de x-as een eindpunt haalt (obj.localPosition.x >= 18). 
Verder krijgt de agent een beloning van -0.15 telkens wanneer hij springt zodat hij dit niet kan misbruiken.

Bart Pijkels en Ruben Vorsselmans