using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONSTANTS : MonoBehaviour
{
    public float nightDuration = 12f;
    public float workDuration = 10f;
    public float groceryDuration = 10f;
    public float stoppingDistance = 2f;

    public Color safeColor;
    public Color exposedColor;
    public Color infectedColor;

    public float exposureRadius;
    public float exposureProbability;
    public float exposureMeanDureation;
    public float exposureStdDiviationDuration;

    public float infectionProbability;
    public float infectionMeanDureation;
    public float infectionStdDiviationDuration;

    public bool PartialLOCKDOWN; //désactivation des commerces secondaires
    public bool TotalLOCKDOWN; //désactivation des commerces secondaires + travail

    public bool contactTracingActivated; //Application contact-tracing
    public float contactTracingRate; //Portion de la pop qui utilise l'application
}
