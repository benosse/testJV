rappel:
créer un .gitignore dans le dossier "test" (pas à la racine) et le remplir avec https://github.com/github/gitignore/blob/master/Unity.gitignore

--------------------------------------------------------------------------
------------------------------------------------------------------------


# les commandes git:

## git fetch origin nom_de_la_branche
*récupère une branche du dépot distant

## git pull 
*récupère la dernière version sur le dépot distant et essaie de la merge avec votre branche courante

## git add monFichier / git add *
*ajoute les fichiers à la liste de fichiers à sauver dans le prochain commit*

## git commit -m "un résumé des changements que j'ai fait"
*enregistre le dossier de travail EN LOCAL*
-> pensez à faire souvent des commits, à chaque fos que vous validez une partie du code

## git push
*pour envoyer votre dossier de travail en l'état sur le dépot distant*


# Les branches
La branche de base est la branche master

## git branch nomDeLaBranche
*Pour créer une branche*
## git checkout nomDeLaBranche
*Pour changer de branche*
## git checkout -b nomDeLaBranche
*Pour créer une branche et direct passer dessus* 

## git checkout master (on va sur master)
## git merge nomDeLaBranche (merge)
*Pour fusionner une branche à master*

