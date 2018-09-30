using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateBehavior;

public class PlayerMovement : MonoBehaviour {

    Transform enemyTransform;
    NavMeshAgent playerAgent;
    //State<AI> playerState;
    //float speed;

    // Use this for initialization
    void Start()
    {
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        playerAgent = GetComponent<NavMeshAgent>();
        //playerState = GetComponent<State<AI>>();
        //speed = GetComponent<float>();

    }

    // Update is called once per frame
    void Update() {
        //playerAgent.s
        //destination = playerAgent.transform.localPosition + enemy.transform.InverseTransformVector
        if (enemyTransform != null)  {
            playerAgent.SetDestination(transform.position - enemyTransform.position);
        }


    }

}
