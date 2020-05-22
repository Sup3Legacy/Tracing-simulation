using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopsController : MonoBehaviour
{
    public Transform[] PotentialShops;

    void Start()
    {
      Transform[] PotentialShopsBis = GetComponentsInChildren<Transform>();
      PotentialShops = new Transform[PotentialShopsBis.Length - 1];
      for(int i = 1; i < PotentialShopsBis.Length; i++){
          PotentialShops[i - 1] = PotentialShopsBis[i];
      }
    }
}
