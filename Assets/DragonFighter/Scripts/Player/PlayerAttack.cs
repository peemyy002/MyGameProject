using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	GameObject player;
    public short PlayerDamage = 60;
    EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
    GameObject go2;
    public float d = 100f;
    // Use this for initialization
    void Awake () {
		anim = GetComponent <Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && playerHealth.currentHealth > 0)
        {
            Attack2();
     
    
          
            }
        }
    
    void Attack()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, d))
        {
            GameObject go = hit.collider.gameObject;
            go2 = go;
            if (go.tag == "Enemy")
            {
                enemyHealth =go.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(PlayerDamage);

            }
            else { return; }

        }

    }
    void Attack2 ()
    {
        anim.Play("Attack");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (d * transform.forward));
    }
}
