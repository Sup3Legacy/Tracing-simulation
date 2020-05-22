using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceriesController : MonoBehaviour
{
    public Transform[] PotentialGroceries;

    void Start()
    {
        PotentialGroceries = GetComponentsInChildren<Transform>();
    }
}
