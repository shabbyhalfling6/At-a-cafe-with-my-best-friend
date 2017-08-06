using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaristaManager : MonoBehaviour {

    //barista stands at counter
    //barista walks to tables - people run out of coffee

    //barista makes coffees
    //barista comes to you

    //variables
    public Transform behindCounter;
    public Transform playerTable;
    public Transform[] tables;

    private UnityEngine.AI.NavMeshAgent agent;

    private float timer = 0.0f;
    public float timerIn = 10.0f;

    private bool servePlayer = false;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = timerIn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f && !servePlayer)
        {
            MoveRandTable();
            timer = timerIn;
        }
	}

    void MoveRandTable()
    {
        int randNum = Random.Range(0, tables.Length);
        agent.SetDestination(tables[randNum].position);
    }

    public void ServePlayer()
    {
        agent.SetDestination(playerTable.position);
        servePlayer = true;
    }
}
