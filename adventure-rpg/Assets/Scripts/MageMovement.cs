﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMovement : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent nav;

	public float moveSpeed = 6f;
	public float attackDistance = 15;
	public float runDistance = 5;
	public GameObject[] allEnemies;


	// Use this for initialization
	void Awake ()
    {
        //enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> (); 
    }

	void Flee (GameObject enemy) {
		float fleeDistance = -10;
		Vector3 direction = (enemy.transform.position - transform.position).normalized;
		Vector3 runTo = transform.position + (direction * fleeDistance);
		Debug.DrawLine(transform.position, enemy.transform.position);
		nav.SetDestination(runTo);
		// nav.destination = (transform.position + direction * fleeDistance);
	}
	void Approach (GameObject enemy) {
		float approachDistance = 1;
		Vector3 direction = (transform.position - enemy.transform.position).normalized;
		Vector3 runTo = transform.position - (direction * approachDistance);
		nav.SetDestination(runTo);
	}
	GameObject FindClosestEnemy () {
		float distanceToClosestEnemy = Mathf.Infinity;
		GameObject closestEnemy = null;
		foreach (GameObject enemy in allEnemies){
			float distanceToEnemy = (enemy.transform.position - transform.position).sqrMagnitude;
			if (distanceToClosestEnemy > distanceToEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = enemy;
			}
		}
		//Debug.DrawLine(transform.position, closestEnemy.transform.position);
		return closestEnemy;
	}
	// Update is called once per frame
	void Update ()
    {
		//transform.LookAt(enemy);
		GameObject enemy = FindClosestEnemy();
		if (
			Vector3.Distance(transform.position, enemy.transform.position) >= attackDistance
		) {
			Debug.Log("GO TOWARD ENEMY");
			//Go toward the enemy
			// transform.position += transform.forward * moveSpeed * Time.deltaTime;
			//nav.destination = (enemy.position);
			Approach(enemy);
			if (
				Vector3.Distance(transform.position, enemy.transform.position) <= attackDistance &&
				Vector3.Distance(transform.position, enemy.transform.position) > runDistance
			) {
				Debug.Log("ATTACK ENEMY");
				// call function to attack the enemy
			}
			else if (Vector3.Distance(transform.position, enemy.transform.position) <= runDistance) {
				// run
				Debug.Log("FLEE FROM ENEMY");
				Flee(enemy);
			}
		} else {
			if (
				Vector3.Distance(transform.position, enemy.transform.position) <= attackDistance &&
				Vector3.Distance(transform.position, enemy.transform.position) > runDistance
			) {
				Debug.Log("ATTACK ENEMY");
				// call function to attack the enemy
			}
			else if (Vector3.Distance(transform.position, enemy.transform.position) <= runDistance) {
				// run
				Debug.Log("FLEE FROM ENEMY2");
				Flee(enemy);
			}
		}
    }
}