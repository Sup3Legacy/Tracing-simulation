using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceriesController : MonoBehaviour
{
    public Transform[] PotentialGroceries;

    void Start()
    {
        Transform[] PotentialGroceriesBis = GetComponentsInChildren<Transform>();
        PotentialGroceries = new Transform[PotentialGroceriesBis.Length - 1];
        for(int i = 1; i < PotentialGroceriesBis.Length; i++){
            PotentialGroceries[i - 1] = PotentialGroceriesBis[i];
        }
    }
}
