using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkplacesController : MonoBehaviour
{
    public Transform[] PotentialWorkplaces;

    void Awake()
    {
      Transform[] PotentialWorkplacesBis = GetComponentsInChildren<Transform>();
      PotentialWorkplaces = new Transform[PotentialWorkplacesBis.Length - 1];
      for(int i = 1; i < PotentialWorkplacesBis.Length; i++){
          PotentialWorkplaces[i - 1] = PotentialWorkplacesBis[i];
      }
    }
}
