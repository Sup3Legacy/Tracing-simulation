using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopsController : MonoBehaviour
{
    public Transform[] PotentialShops;

    void Start()
    {
        PotentialShops = GetComponentsInChildren<Transform>();
    }
}
