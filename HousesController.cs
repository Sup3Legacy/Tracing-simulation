using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesController : MonoBehaviour
{
    public Transform[] PotentialHouses;

    void Start()
    {
        PotentialHouses = GetComponentsInChildren<Transform>();
    }

}
