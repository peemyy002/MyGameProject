﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            
	public int currentHealth;                   
	public float sinkSpeed = 2.5f;             
	              
	public AudioClip deathClip;                 
	
	
	Animator anim;                             
	AudioSource enemyAudio;                                  
	CapsuleCollider capsuleCollider;            
	bool isDead;                                
	bool isSinking;                            
	
	
	void Awake ()
	{

		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
	}
	
	void Update ()
	{

		if(isSinking)
		{

			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}
	
	
	public void TakeDamage (int amount)
	{

		if(isDead)

			return;

        anim.Play("Damage");
		enemyAudio.Play ();
		currentHealth -= amount;

		if(currentHealth <= 0)
		{

			Death ();
            StartSinking();
		}
	}
	
	
	void Death ()
	{

		isDead = true;
		

		capsuleCollider.isTrigger = true;
		

		anim.SetTrigger ("Dead");
		

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
	}
	
	
	public void StartSinking ()
	{

		GetComponent <NavMeshAgent> ().enabled = false;
		

		GetComponent <Rigidbody> ().isKinematic = true;
		

		isSinking = true;
		
	

		

		Destroy (gameObject, 2f);
	}
}