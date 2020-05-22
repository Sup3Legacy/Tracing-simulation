using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONSTANTS : MonoBehaviour
{
    [Header("World")]
    public float nightDuration = 12f;
    public float workDuration = 10f;
    public float groceryDuration = 4f;
    public float shoppingDuration = 2f;
    public float stoppingDistance = 2f;

    [Header("Colors")]
    public Color safeColor;
    public Color exposedColor;
    public Color infectedColor;

    [Header("Exposition")]
    public float expositionRadius;
    public float expositionProbability; //Propbabilité d'exposer qqn
    public float expositionMeanDureation;
    public float expositionStdDiviationDuration;
    public float expositionDelay;

    [Header("Infection")]
    public float infectionProbability; // Probabilité de développerdes symptômes
    public float infectionMeanDureation;
    public float infectionStdDiviationDuration;

    [Header("Countermeasures")]
    public bool PartialLOCKDOWN; //désactivation des commerces secondaires
    public bool TotalLOCKDOWN; //désactivation des commerces secondaires + travail

    public bool contactTracingActivated; //Application contact-tracing
    public float contactTracingRate; //Portion de la pop qui utilise l'application

    public bool quarantineOnInfectRate; //Proportion des symptomatiques mises en quarantaine
}
