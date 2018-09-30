using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;

    private int _currentHealth;

    public int currentHealth {
        get {
            return _currentHealth;
        }

        set {
            if (value <= 0) {
                _currentHealth = 0;
                Death();
            } else {
                _currentHealth = value;
            }
        }
    }
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    public float sinkSpeed = 2.5f;

	// Use this for initialization
	void Start () {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

    }
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }
   

    void Death() {
        Debug.Log("Enemy is dying!");

        isDead = true;

        capsuleCollider.isTrigger = true;
        StartSinking();

        //anim.SetTrigger("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }

}
