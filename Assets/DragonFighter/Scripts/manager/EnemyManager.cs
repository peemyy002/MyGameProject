using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int C;
    public GameObject Pass;
    EnemyHealth enemyhealth;
    GameObject go;
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
        
    }
    void Update()
    {
        
        if (C >= 10)
        {
            StartCoroutine(Passs());
        }
    }
    IEnumerator Passs ()
    {
        yield return new WaitForSeconds (0.5f);
        Pass.SetActive(true);
        Animator anim = Pass.GetComponent<Animator>();
        anim.Play("PASS");

    }

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if (C <= 6)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            C++;
        }
        else {

            C++;  
        }
    }
}



