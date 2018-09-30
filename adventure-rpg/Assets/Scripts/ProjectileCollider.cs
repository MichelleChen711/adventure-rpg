using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider: MonoBehaviour {


    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update() {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag  == "Enemy") {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.currentHealth -= 20;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);

    }
}
