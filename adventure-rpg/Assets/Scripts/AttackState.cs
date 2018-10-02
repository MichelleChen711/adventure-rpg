using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;

public class AttackState : State<Mage> {

	private static AttackState instance;

	//constructor
	private AttackState() {
		instance = this;
	}
	
  // This function basically initializes the instance if it doesnt exist,
  // otherwise return the already initialzed instance to keep re-using the
  // same instance.
  public static AttackState getInstance() {
    if (instance == null) {
      instance = new AttackState();
    }
    return instance;
	}
  public override void EnterState(Mage owner)
  {
    Debug.Log("Entering attack state");
  }

  public override void ExitState(Mage owner)
  {
    Debug.Log("Exiting attack state");
  }

  public override void UpdateState(Mage owner)
  {
    // owner.stateMachine.ChangeState(nextState);
    Debug.Log("is updating attack state");
  }
}