using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int damagePerShot = 20;
    public float timeBetweenAttacks = 1.0f;
    public float range = 100f;

    float timer;
    GameObject player;
    GameObject enemy;

    public GameObject projectile;

    // Use this for initialization
    void Start () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenAttacks && Time.timeScale > 0.0) {
            Debug.Log("Attacking!");
            if (enemy != null) {
                Attack();

            }
        }
    }

    void Attack() {
        GameObject fireball = Instantiate(projectile, transform) as GameObject;
        Rigidbody rigidbody = fireball.GetComponent<Rigidbody>();
        rigidbody.velocity = enemy.transform.position - transform.position;
    }
}
