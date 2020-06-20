# Tracing-simulation
Simulation dans le moteur Unity du fonctionnement du Contact-Tracing (https://github.com/ROBERT-proximity-tracing/documents)

## Motivation
Ayant entendu parler de la possibilité que soit mise en place une stratégie de contact-tracing, je me suis demandé comment cela marche en pratique et quels bénéfices nous pouvons en tirer

## Contexte de la simulation

Pour mener ce projet, j'ai mis en place une simulation, dans le moteur Unity, d'une ville et de ses habitants. 

![Aperçu de la ville](/images/Ville.png)

Les habitants, représentés par des capsules de couleur, suivent un  ```cycle maison/travail/courses/magasin``` (on distingues les courses, qui représentent les achats de première nécessité avec les magasins, représentant les achats secondaires). (Les voitures en sont que de la décoration, elles ne bougent pas, les habitants se déplacent tous à pieds pour simplifier la simulation!)

La maladie est considéré dans le cadre d'un modèle parent du modèle **SIR**, le modèle **Sain/exposé/infecté/guéri**. La couleur d'un habitant représente l'état dans lequel il est : vert pour sain et guéri, orange poru exposé et rouge pour infecté.

J'ai pris le parti de ce modèle car il est plus complexe et *a priori* plus réaliste que le modèle **SIR** : ```exposé``` signifie "atteint, contagieux mais encore asymptomatique", il s'agit donc de l'état où le patient ne se sait pas encore porteur du virus, donc ne prend pas de précautions, continue à aller au travail, etc. Puis, il passe dans l'état ```infecté```, qui représente la phase symptomatique de la maladie (on suppose ici que tous les malades développent des symptômes tôt ou tard, ce qui n'est, on l'a vu, pas vrai dans la réalité), donc propice à la prise de mesures individuelles de distanciation.

Exemple d'habitants sains : 

![Habitant sain](/images/Individus_sains.png)

## Déroulement

Tout au long de la simulation, il est possible d'ajouter des **patients-zéro**, lieux de départ d'une épidémie. Cette épidémie peut alors se propager parmi les individus au gré des déplacements et rassemblements.

Patient-zéro : 
![Patient-zéro](/images/Individus_exposes.png)

J'ai simulé les contacts et risques contagieux par une sphère d'un rayon arbitraire (faisant partie des hyperparamètres de la simulation), centrée autour de chaque individu contagieux et dans laquelle tout individu sain risque de passer dans l'état exposé.

On voit le fonctionnement ici, où un unique individu (ici en rouge) a contaminé plusieurs de ses  co-travailleurs sur son lieu de travail :
![Contamination](/images/Individus_infectes.png)

## Pistes pour le futur

Il y a plusieurs points sur lesquels j'aimerais améliorer cette simulation :
* Améliorer le cycle jour/nuit : Pour l'instant, chaque individu suit son propre rythme jour/nuit, ce qui est peu représentatif de la réalité
* Ajouter des actions : Les individus ne font qu'aller travailler, faire les courses et magasins et rentrer chez eux. Il serait intéressant de leur donner un âge et de faire dépendre de cet âge les occupations!
* Ajouter les contre-mesures : je n'ai pas encore implémenté les différentes contre-mesures possibles : confinement partiel ou total, contact-tracing
