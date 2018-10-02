using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour {

	public Mage mage;
	public GameObject Fireball; 
	float fireballSpeed = 3;
	float fireballCooldown = 5;
	bool fireballReady;

	public GameObject MagicBolt;
	float magicBoltSpeed = 2;
	float magicBoltCooldown = 3;
	bool magicBoltReady;

	// Use this for initialization
	void Start () {
		fireballReady = true;
		magicBoltReady = true;
	}
	public void AutoAttack (GameObject enemy) {
		Debug.Log("auto attacking!!");
		GameObject magicBolt = Instantiate(MagicBolt, transform.position, transform.rotation);
		Rigidbody rb = magicBolt.GetComponent<Rigidbody>();
		
		Vector3 direction = (enemy.transform.position - transform.position).normalized;
		mage.transform.rotation = Quaternion.LookRotation(direction);
	
		rb.velocity = transform.forward * magicBoltSpeed;
		// damage to enemy health
		StartCoroutine(handleMagicBoltCooldown());
	}
	void CastFireball () {
		GameObject fireball = Instantiate(Fireball, transform.position, transform.rotation); 
		Rigidbody rb = fireball.GetComponent<Rigidbody>();
		rb.velocity = transform.forward * fireballSpeed;
		StartCoroutine(handleFireBallCooldown());
	}

	IEnumerator handleFireBallCooldown () {
		fireballReady = false;
		yield return new WaitForSeconds(fireballCooldown);
		fireballReady = true;
	}
	IEnumerator handleMagicBoltCooldown () {
		magicBoltReady = false;
		yield return new WaitForSeconds(magicBoltCooldown);
		magicBoltReady = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			if (fireballReady) {
				Debug.Log("casting fireball");
				CastFireball();
			} else {
				Debug.Log("fireball is on cooldown");
			}
		}
		if (mage.stateMachine.currentState == AttackState.getInstance()){
			if (magicBoltReady) {
				AutoAttack(mage.enemy);
			}
		}
	}
}
