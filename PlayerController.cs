using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;
    public Transform selfTransform;
    public Renderer renderer;

    public HousesController housesController;
    public WorkplacesController workplacesController;
    public GroceriesController groceriesController;
    public ShopsController shopsController;

    public Transform Home;
    public Transform Workplace;

    bool atHome = false;
    bool atWork = false;
    bool atGrocery = false;
    bool atShops = false;

    float timeAwaken = 0f;

    public bool safe = true;
    public bool exposed = false;
    public bool infected = false;

    CONSTANTS CST;

    void Start(){
        renderer = GetComponentInChildren<Renderer>();
        CST = GameObject.Find("Constants").GetComponent<CONSTANTS>();
        changeColor(CST.safeColor);
    }

    void Update(){
        if (Home == null && housesController.PotentialHouses.Length > 0) { //Initialise la maison
            Home = housesController.PotentialHouses[Random.Range(0, housesController.PotentialHouses.Length)];
        }

        if (Workplace == null && workplacesController.PotentialWorkplaces.Length > 0) { //Initialise le travail
            Workplace = workplacesController.PotentialWorkplaces[Random.Range(0, workplacesController.PotentialWorkplaces.Length)];
        }


        if(Home != null && !atHome){
            agent.SetDestination(Home.position);
        }

        if (!agent.pathPending) { //Arrête le pathfindign lorsque proche de la destination
            if (agent.remainingDistance <= CST.stoppingDistance) {
                agent.Stop();
            }
        }

    }

    void expose(){
        safe = false;
        exposed = true;
    }

    void changeColor(Color col){
        renderer.material.SetColor("_Color", col);
    }
}
