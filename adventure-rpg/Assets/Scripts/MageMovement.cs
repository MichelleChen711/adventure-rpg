using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMovement : MonoBehaviour {

	public Mage mage;
	UnityEngine.AI.NavMeshAgent nav;

	public void Start () {
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}
	void Flee (GameObject enemy) {
		float fleeDistance = -10;
		Vector3 direction = (enemy.transform.position - mage.transform.position).normalized;
		Vector3 runTo = mage.transform.position + (direction * fleeDistance);

		mage.transform.rotation = Quaternion.LookRotation(direction);
		nav.SetDestination(runTo);
		Debug.DrawLine(mage.transform.position, enemy.transform.position);
	}
	void Chase (GameObject enemy) {
		float approachDistance = 1;
		Vector3 direction = (mage.transform.position - enemy.transform.position).normalized;
		Vector3 runTo = mage.transform.position - (direction * approachDistance);
		
		mage.transform.rotation = Quaternion.LookRotation(direction);
		nav.SetDestination(runTo);
	}
	public void Update ()
    {
		if (mage.stateMachine.currentState == ChaseState.getInstance()){
			Chase(mage.enemy);
		} else if (mage.stateMachine.currentState == FleeState.getInstance()){
			Flee(mage.enemy);
		}
	}
}
