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
        MakeOrder,
        Wait,
        MoveTable,
        ServeTable
    }

    //travel locations
    public Transform behindCounter;
    public Transform playerTable;
    public Transform[] tables;

    private UnityEngine.AI.NavMeshAgent agent;

    //timer variables for how long to do the current action, if needed
    private float timer = 0.0f;
    public float timerIn = 10.0f;

    private baristaStates currentState = baristaStates.Idle;
    private baristaAction currentAction = baristaAction.ServeTable;

    public ClickableObject playerCup;
    public bool coffeeOrTea;

    private int randTable = 0;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = timerIn;

        //initialise a random table to travel to in the Idle state
        randTable = Random.Range(0, tables.Length);
    }

    void Update()
    {
        //decrementation of the timer
        timer -= Time.deltaTime;

        //switch over the states and do that behaviour
        switch (currentState)
        {
            case baristaStates.Idle:
                {
                    //Idle Behaviour
                    ServingRandoms();
                    break;
                }
            case baristaStates.ServePlayer:
                {
                    break;
                }
            case baristaStates.DeliverPlayerDrink:
                {
                    //Serving Player Behaviour
                    ServingPlayer();
                    break;
                }
        }

    }

    void ServingPlayer()
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
                            currentAction = baristaAction.MakeOrder;
                        }
                    }
                    break;
                }
            case baristaAction.MakeOrder:
                {
                    /////////////////// stand at counter until the drink is made ////////////////
                    //if the barista has stood at the counter long enough
                    if (timer <= 0.0f)
                    {
                        agent.SetDestination(playerTable.position);
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

                            currentAction = baristaAction.MakeOrder;
                            currentState = baristaStates.Idle;
                            randTable = Random.Range(0, tables.Length);

                            //(poop code)
                            if (coffeeOrTea)
                            {
                                playerCup.spriteRenderer.sprite = playerCup.coffeeCupSprites[4];
                            }
                            else
                            {
                                playerCup.spriteRenderer.sprite = playerCup.teaCupSprites[4];
                            }
                            playerCup.clicksBeforeExecute = playerCup.clicksBeforeExecuteIn;
                        }
                    }
                    break;
                }
        }
    }

    //Behaviour for serving random customers in the cafe, or the "Idle state"
    //  1. Moves to a random table in the cafe and takes order
    //  2. Takes order and waits at the table for x seconds
    //  3. Moves to counter and makes order and waits for x seconds
    //  4. Delivers order to the table that ordered
    //  5. Resets back and moves to another random table
    void ServingRandoms()
    {
        switch (currentAction)
        {
            case baristaAction.ServeTable:
                {
                    //check if the destination is reached
                    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            currentAction = baristaAction.Wait;
                            timer = timerIn;
                        }
                    }
                    break;
                }
            case baristaAction.Wait:
                {
                    if (timer <= 0.0f)
                    {
                        currentAction = baristaAction.MoveCounter;
                        agent.SetDestination(behindCounter.position);
                    }
                    break;
                }
            case baristaAction.MoveCounter:
                {
                    //////////////////// moving to the counter to grab a drink //////////////////
                    //check if the destination is reached
                    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            timer = timerIn;
                            currentAction = baristaAction.MakeOrder;
                        }
                    }
                    break;
                }
            case baristaAction.MakeOrder:
                {
                    /////////////////// stand at counter until the drink is made ////////////////
                    //if the barista has stood at the counter long enough
                    if (timer <= 0.0f)
                    {
                        //set the destination back to the table currently being served
                        agent.SetDestination(tables[randTable].position);
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
                            currentAction = baristaAction.ServeTable;
                            randTable = Random.Range(0, tables.Length);
                            agent.SetDestination(tables[randTable].position);
                        }
                    }
                    break;
                }
        }
    }

    //functions called through fungus to move the barista to the players table
    //happens after the cup has been pressed X times
    //changes the current state to a state that does nothing until fungus is...
    //...finished doing it's stuff and calls DeliverCoffee()
    public void ServePlayer()
    {
        currentState = baristaStates.ServePlayer;
        agent.SetDestination(playerTable.position);
    }

    //Called through fungus when the player has picked their drink
    public void DeliverCoffee()
    {
        currentState = baristaStates.DeliverPlayerDrink;
        currentAction = baristaAction.MoveCounter;
        agent.SetDestination(behindCounter.position);
    }

    //Called through fungus to determine what drink was selected
    public void DrinkType(bool _isCoffee)
    {
        playerCup.isCoffee = _isCoffee;
        coffeeOrTea = _isCoffee;
    }
}

