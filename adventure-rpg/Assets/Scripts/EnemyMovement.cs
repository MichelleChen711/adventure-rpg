using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Transform player;
    UnityEngine.AI.NavMeshAgent nav;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (player.position);
	}
}


// using UnityEngine;
// using System.Collections;

// public class EnemyMovement : MonoBehaviour
// {
//     Transform player;
//     PlayerHealth playerHealth;
//     EnemyHealth enemyHealth;
//     UnityEngine.AI.NavMeshAgent nav;


//     void Awake ()
//     {
//         player = GameObject.FindGameObjectWithTag ("Player").transform;
//         playerHealth = player.GetComponent <PlayerHealth> ();
//         enemyHealth = GetComponent <EnemyHealth> ();
//         nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
//     }


//     void Update ()
//     {
//         if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
//         {
//             nav.SetDestination (player.position);
//         }
//         else
//         {
//             nav.enabled = false;
//         }
//     }
// }