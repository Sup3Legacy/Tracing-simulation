using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousesController : MonoBehaviour
{
    public Transform[] PotentialHouses;

    void Start()
    {
      Transform[] PotentialHousesBis = GetComponentsInChildren<Transform>();
      PotentialHouses = new Transform[PotentialHousesBis.Length - 1];
      for(int i = 1; i < PotentialHousesBis.Length; i++){
          PotentialHouses[i - 1] = PotentialHousesBis[i];
      }
    }

}
