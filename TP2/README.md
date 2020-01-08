# TP 2 : RVI
Gautier Kasperek

## Partie 1 :
Scène 1 : Appuyer sur le bouton "Start" pour accèder à la scène 2.

Scène 2 : Il est possible de bouger la caméra grâce aux boutons de l'UI ou avec les flèches directionnelles du clavier.

    scripts : Start_game.cs, Camera_follow.cs

## Partie 2 : Interactions

Scène 3 : Click and Drag des objets présent. La molette permet de rapprocher ou d'éloigner l'objet non-cliqué selectionné.

	script : Select_object.cs

## Partie 3 : Configurateur

Scène_partie3_configurateur : Les points sont traçables sur le canevas. Attention cependant, il est possible que les points empêche de cliquer sur le bouton *valider* au quel cas il faut redimensionner la fenêtre.  Le placement de meuble est possible mais décalé par rapport à la souris. Il manque un mapping entre les coordonnées cliqué sur le canevas et les coordonnées réels.

	script : Configurateur.cs
