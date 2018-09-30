using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateBehavior;

public class EnemyMovement : MonoBehaviour {

    Transform mageTransform;
    NavMeshAgent enemyAgent;
    float aggroRange = 10;
    AI enemyBehavior;



    // Use this for initialization
    void Start () {
        mageTransform = GameObject.FindGameObjectWithTag("Mage").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyBehavior = GetComponent<AI>();

	}
	
	// Update is called once per frame
	void Update () {
        if (enemyAgent.isActiveAndEnabled) {
            if (enemyBehavior.stateMachine.currentState == IdleState.sharedInstance) {
                enemyAgent.isStopped = true;
            } else {
                enemyAgent.SetDestination(mageTransform.position);

            }
        } 

        //Collider[] colliders = Physics.OverlapSphere(enemyAgent.transform.position, aggroRange);
        //int i = 0;
        //while (i < colliders.Length)
        //{
        //    colliders[i].SendMessage("AddDamage");
        //    i++;
        //}

    }
}
