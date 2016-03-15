using UnityEngine;
using System.Collections;

public class PASSMAP : MonoBehaviour
{
    public GameObject Fade;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Fadee());
        }
    }
    IEnumerator Fadee ()
    {
        yield return new WaitForSeconds (0.5f);
        Animator anim = Fade.GetComponent<Animator>();
        anim.Play("FadeB");
    }
}