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
    public Transform Grocery;
    public Transform Shop;

    public bool atHome = false;
    public bool atWork = false;
    public bool atGrocery = false;
    public bool atShop = false;

    public bool goingHome = false;
    public bool goingWork = false;
    public bool goingGrocery = false;
    public bool goingShop = false;

    float timeAwaken = 0f;
    public float timeSinceActivity = 0f;
    float lastExposed = 0f;

    public bool safe = true;
    public bool exposed = false;
    public bool infected = false;

    bool prevSafe = false;
    bool prevExposed = false;
    bool prevInfected = false;

    public bool stopped = false;
    public bool placed = false;
    CONSTANTS CST;
    bool complete_old = true;

    void Start(){
        selfTransform = gameObject.GetComponent<Transform>();
        renderer = GetComponentInChildren<Renderer>();
        CST = GameObject.Find("Constants").GetComponent<CONSTANTS>();
        changeColor(CST.safeColor);
        agent.stoppingDistance = CST.stoppingDistance;
    }

    void Update(){
        if (Home != null && Workplace != null){
          if (!placed){
              agent.Warp(Home.position);
              placed = true;
              atHome = true;
          }

          if((exposed || infected) && Time.time - lastExposed >= CST.expositionDelay){
              InfectOther();
              lastExposed = Time.time;
          }

          if(safe && !prevSafe){
              prevSafe = true;
              changeColor(CST.safeColor);
          }
          if(exposed && !prevExposed){
              prevExposed = true;
              changeColor(CST.exposedColor);
          }
          if(infected && !prevInfected){
              prevInfected = true;
              changeColor(CST.infectedColor);
          }

          if (!complete_old && agent.remainingDistance <= CST.stoppingDistance && 0 < agent.remainingDistance) { //Si on vient d'arriver
              complete_old = true;
              timeSinceActivity = Time.time;
              if (goingHome) {
                  atHome = true;
                  goingHome = false;
              }
              else if (goingWork) {
                  atWork = true;
                  goingWork = false;
              }
              else if (goingGrocery) {
                  atGrocery = true;
                  goingGrocery = false;
              }
              else if (goingShop) {
                  atShop = true;
                  goingShop = false;
              }
          }
          Routine();
        }

        if (Home == null && housesController.PotentialHouses.Length > 0) { //Initialise la maison
            Home = housesController.PotentialHouses[Random.Range(0, housesController.PotentialHouses.Length)];
        }

        if (Workplace == null && workplacesController.PotentialWorkplaces.Length > 0) { //Initialise le travail
            Workplace = workplacesController.PotentialWorkplaces[Random.Range(0, workplacesController.PotentialWorkplaces.Length)];
        }
    }

    void DetectLocation(){
        if (Vector3.Distance(Home.position, selfTransform.position) <= CST.stoppingDistance){
            atHome = true;
            atWork = false;
            atGrocery = false;
            atShop = false;
            agent.isStopped = true;
            timeSinceActivity = Time.time;
        }
        else if (Workplace != null && Vector3.Distance(Workplace.position, selfTransform.position) <= CST.stoppingDistance){
            atHome = false;
            atWork = true;
            atGrocery = false;
            atShop = false;
            agent.isStopped = true;
            timeSinceActivity = Time.time;
        }
        else if (Grocery != null && Vector3.Distance(Grocery.position, selfTransform.position) <= CST.stoppingDistance){
            atHome = false;
            atWork = false;
            atGrocery = true;
            atShop = false;
            agent.isStopped = true;
            timeSinceActivity = Time.time;
        }
        else if (Shop != null && Vector3.Distance(Shop.position, selfTransform.position) <= CST.stoppingDistance){
            atHome = false;
            atWork = false;
            atGrocery = false;
            atShop = true;
            agent.isStopped = true;
            timeSinceActivity = Time.time;
        }
    }



    public void GetExposed(){
        if (Random.Range(0f, 1f) <= CST.expositionProbability) {
            safe = false;
            exposed = true;
            changeColor(CST.exposedColor);
            lastExposed = Time.time; //On remet à 0 le décompte d'exposition
        }
    }

    void changeColor(Color col){
        renderer.material.SetColor("_Color", col);
    }

    void InfectOther(){
        Collider[] hitColliders = Physics.OverlapSphere(selfTransform.position, CST.expositionRadius);
        foreach(Collider col in hitColliders){
            if (col.gameObject != gameObject){
                col.gameObject.GetComponent<PlayerController>().GetExposed();
            }

        }
    }

    void Routine(){
      if (complete_old) {
        if (atHome && Time.time - timeSinceActivity >= CST.nightDuration){
            goWork();
            complete_old = false;
        }
        else if (atWork && Time.time - timeSinceActivity >= CST.workDuration){
            goGrocery();
            complete_old = false;
        }
        else if(atGrocery && Time.time - timeSinceActivity >= CST.groceryDuration){
            if (CST.PartialLOCKDOWN) {
                goHome();
                complete_old = false;
            }
            else{
                goShopping();
                complete_old = false;
            }
        }

        else if (atShop && Time.time - timeSinceActivity >= CST.shoppingDuration) {
            goHome();
            complete_old = false;
        }
      }
    }

    void stayHome(){ //TM

    }

    void goHome(){
        agent.SetDestination(Home.position);
        goingHome = true;
        atGrocery = false;
        atShop = false;
    }

    void goWork(){
        goingWork = true;
        agent.SetDestination(Workplace.position);
        atHome = false;
    }

    void goGrocery(){
        Grocery = groceriesController.PotentialGroceries[Random.Range(0, groceriesController.PotentialGroceries.Length)];
        agent.SetDestination(Grocery.position);
        goingGrocery = true;
        atWork = false;
    }

    void goShopping(){
        agent.SetDestination(shopsController.PotentialShops[Random.Range(0, shopsController.PotentialShops.Length)].position);
        goingShop = true;
        atGrocery = false;
    }
}
