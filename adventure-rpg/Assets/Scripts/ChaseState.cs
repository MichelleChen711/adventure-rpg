using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;

public class ChaseState : State<Mage> {

	private static ChaseState instance;

	//constructor
	private ChaseState() {
		instance = this;
	}
	
  // This function basically initializes the instance if it doesnt exist,
  // otherwise return the already initialzed instance to keep re-using the
  // same instance.
  	public static ChaseState getInstance() {
    	if (instance == null) {
      		instance = new ChaseState();
    	}
    	return instance;
	}
  	public override void EnterState(Mage owner)
  	{
    	Debug.Log("Entering chase state");
  	}

  	public override void ExitState(Mage owner)
  	{
    	Debug.Log("Exiting chase state");
  	}

  	public override void UpdateState(Mage owner)
  	{
    	// owner.stateMachine.ChangeState(nextState);
  	}
}