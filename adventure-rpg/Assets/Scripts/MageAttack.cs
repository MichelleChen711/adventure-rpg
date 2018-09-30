using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour {

	public GameObject projectile; 
	public float projectileSpeed;
	float fireballCooldown = 5;
	bool fireballReady;
	// Use this for initialization
	void Start () {
		fireballReady = true;
	}
	void CastFireball () {
		GameObject fireball = Instantiate(projectile, transform); 
		Rigidbody rb = fireball.GetComponent<Rigidbody>();
		rb.velocity = transform.forward * projectileSpeed;
	}

	IEnumerator handleFireballCooldown () {
		fireballReady = false;
		yield return new WaitForSeconds(fireballCooldown);
		fireballReady = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			if (fireballReady) {
				Debug.Log("casting fireball");
				CastFireball();
				StartCoroutine(handleFireballCooldown());
			} else {
				Debug.Log("fireball is on cooldown");
			}
		}
	}
}
