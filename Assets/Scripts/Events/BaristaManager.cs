using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaristaManager : MonoBehaviour
{

    public enum baristaStates
    {
        Idle,   // serve random tables
        ServePlayer,    //serve player and takes thier order
        DeliverPlayerDrink  //delivers the players order
    }

    public enum baristaAction
    {
        MoveCounter,
        MakeCoffee,
        MoveTable,
    }

    //variables
    public Transform behindCounter;
    public Transform playerTable;
    public Transform[] tables;

    private UnityEngine.AI.NavMeshAgent agent;

    public float timer = 0.0f;
    public float timerIn = 10.0f;

    public baristaStates currentState = baristaStates.Idle;
    public baristaAction currentAction = baristaAction.MoveCounter;

    int randTable = 0;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = timerIn;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //switch over the states and do that behaviour
        switch (currentState)
        {
            case baristaStates.Idle:
                {
                    //call behaviour that handles delivering and making of coffee and feed it the baristas target table to serve
                    Serving(tables[randTable].position);
                    break;
                }
            case baristaStates.ServePlayer:
                {
                    break;
                }
            case baristaStates.DeliverPlayerDrink:
                {
                    //call behaviour that handles delivering and making of coffee and feed it the baristas target table to serve
                    Serving(playerTable.position);
                    break;
                }
        }

    }

    void Serving(Vector3 target)
    {
        switch (currentAction)
        {
            case baristaAction.MoveCounter:
                {
                    //////////////////// moving to the counter to grab a coffee //////////////////
                    //check if the destination is reached
                    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            timer = timerIn;
                            currentAction = baristaAction.MakeCoffee;
                        }
                    }
                    break;
                }
            case baristaAction.MakeCoffee:
                {
                    /////////////////// stand at counter until the drink is made ////////////////
                    //if the barista has stood at the counter long enough
                    if (timer <= 0.0f)
                    {
                        agent.SetDestination(target);
                        currentAction = baristaAction.MoveTable;
                    }
                    break;
                }
            case baristaAction.MoveTable:
                {
                    ////////////////// deliver drink to the customer ///////////////////
                    //check if the destination is reached
                    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            //go back to serving other customers
                            ServeRandoms();
                            currentAction = baristaAction.MoveCounter;
                        }
                    }
                    break;
                }
        }
    }

    //functions called through fungus to change barista state
    public void ServePlayer()
    {
        currentState = baristaStates.ServePlayer;
        agent.SetDestination(playerTable.position);
    }
    public void DeliverCoffee()
    {
        currentState = baristaStates.DeliverPlayerDrink;
        currentAction = baristaAction.MoveCounter;
        agent.SetDestination(behindCounter.position);
    }

    public void ServeRandoms()
    {
        currentState = baristaStates.Idle;
        currentAction = baristaAction.MoveCounter;
        timer = timerIn;
        randTable = Random.Range(0, tables.Length);
    }
}

