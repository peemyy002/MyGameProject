using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	GameObject player;
    public short PlayerDamage = 60;
    EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
    double d = 100f;
    // Use this for initialization
    void Awake () {
		anim = GetComponent <Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
           
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 100f))
            {
            GameObject go = hit.collider.gameObject;
            if(go.tag == "Enemy")
            {
                Debug.Log("Enemy");
            }
            else
            {
                return;
            }
        }
        if (Input.GetKey(KeyCode.Space) && playerHealth.currentHealth > 0)
        {
            Attack();
        }
    }
	void Attack ()
		{
			anim.Play("Attack");
             enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(PlayerDamage);
		}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (100f * transform.forward));
    }
}
