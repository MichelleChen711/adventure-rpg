using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateBehavior;

public class AI : MonoBehaviour {

    public StateMachine<AI> stateMachine { get; set; }
    public int seconds = 0;
    public float gameTimer;

	// Use this for initialization
	void Start () {
        stateMachine = new StateMachine<AI>(this);
        //stateMachine.ChangeState(IdleState.sharedInstance);

	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > gameTimer + 1) {
            gameTimer = Time.time;
            seconds += 1;
            Debug.Log(seconds);
        }

        if (seconds == 5) {
            seconds = 0;
            stateMachine.ChangeState(IdleState.sharedInstance);
            //stateMachine.currentState = s
            
        }		
	}
}
