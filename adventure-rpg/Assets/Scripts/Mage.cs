using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;

public class Mage : MonoBehaviour {
	//State
	public bool shouldSwitchState = false;
	public StateMachine<Mage> stateMachine { get; set; }
	public AttackState attackState;

	// Movement
	UnityEngine.AI.NavMeshAgent nav;
	float attackDistance = 15;
	float runDistance = 5;
	GameObject[] allEnemies;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		stateMachine = new StateMachine<Mage>(this);
		stateMachine.ChangeState(AttackState.getInstance());

		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemy = FindClosestEnemy();

        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
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
	void Update () {
		//transform.LookAt(enemy);
		enemy = FindClosestEnemy();
		if (
			Vector3.Distance(transform.position, enemy.transform.position) >= attackDistance
		) {
			Debug.Log("GO TOWARD ENEMY");
			//Approach(enemy);
			if (stateMachine.currentState != AttackState.getInstance()) {
				stateMachine.ChangeState(ChaseState.getInstance());
			}
		}
		if (
			Vector3.Distance(transform.position, enemy.transform.position) <= attackDistance &&
			Vector3.Distance(transform.position, enemy.transform.position) > runDistance
		) {
			Debug.Log("ATTACK ENEMY");
			if (stateMachine.currentState != AttackState.getInstance()){
				stateMachine.ChangeState(AttackState.getInstance());
			}
		}
		if (Vector3.Distance(transform.position, enemy.transform.position) <= runDistance) {
			Debug.Log("FLEE FROM ENEMY");
			//Flee(enemy);
			if (stateMachine.currentState != FleeState.getInstance()) {
				stateMachine.ChangeState(FleeState.getInstance());
			}
		}
	}
}
