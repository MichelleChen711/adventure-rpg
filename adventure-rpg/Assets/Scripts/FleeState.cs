using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;

public class FleeState : State<Mage> {

	private static FleeState instance;

	//constructor
	private FleeState() {
		instance = this;
	}
	
  // This function basically initializes the instance if it doesnt exist,
  // otherwise return the already initialzed instance to keep re-using the
  // same instance.
  	public static FleeState getInstance() {
    	if (instance == null) {
      		instance = new FleeState();
    	}
    	return instance;
	}
  	public override void EnterState(Mage owner)
  	{
    	Debug.Log("Entering flee state");
  	}

  	public override void ExitState(Mage owner)
  	{
    	Debug.Log("Exiting flee state");
  	}

  	public override void UpdateState(Mage owner)
  	{
    	// owner.stateMachine.ChangeState(nextState);
  	}
}