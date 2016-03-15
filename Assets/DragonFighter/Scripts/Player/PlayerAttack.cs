using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	GameObject player;
    public short PlayerDamage = 60;
    EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Awake () {
		anim = GetComponent <Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && playerHealth.currentHealth > 0) {
			Attack ();


		}
	}
	void Attack ()
		{
			anim.Play("Attack");
             enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(PlayerDamage);
		}
}
