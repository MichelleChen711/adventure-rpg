using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy"){
			Destroy(gameObject);
		}
	}

	void Update() {
		Destroy(gameObject, 4);
	}
}
