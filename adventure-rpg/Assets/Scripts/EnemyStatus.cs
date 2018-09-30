using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : MonoBehaviour {

    bool isProvoked;
    NavMeshAgent enemyNavMesh;

	// Use this for initialization
	void Start () {
        enemyNavMesh = GetComponent<NavMeshAgent>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
