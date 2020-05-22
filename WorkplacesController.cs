using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkplacesController : MonoBehaviour
{
    public Transform[] PotentialWorkplaces;

    void Awake()
    {
        PotentialWorkplaces = GetComponentsInChildren<Transform>();
    }
}
