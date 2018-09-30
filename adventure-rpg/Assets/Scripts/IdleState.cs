using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;
using System;

public class IdleState: State<AI> {


    private static IdleState _instance; 


    public static IdleState sharedInstance {
        get {
            if (_instance == null)  {
                _instance = new IdleState();
            }
            return _instance;
        }
    }
    // Use this for initialization
    void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

    public override void EnterState(AI _owner) {
        Debug.Log("Entering the IdleState!");

    }

    public override void ExitState(AI _owner) {
        Debug.Log("Exiting the IdleState!");
    }

    public override void UpdateState(AI _owner) {
        Debug.Log("Updating the IdleState!");
    }
}
