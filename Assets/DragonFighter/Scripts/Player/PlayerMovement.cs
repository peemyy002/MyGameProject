  using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;


    void Update()
    {
      
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        

        Move(h, v);
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        
		movement.Set (h, 0f, v);
		

		movement = movement.normalized *20* speed * Time.deltaTime;
		

		playerRigidbody.MovePosition (transform.position + movement);
	}
	

	void Animating (float h, float v)
	{

		bool walking = h != 0f || v != 0f;
        if (h > 0)
        {
            // this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime*2);
            transform.forward = Vector3.right;
        }
        else if (h<0)
        {
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime*2);
            transform.forward = Vector3.left;
        }
		anim.SetBool ("IsWalking", walking);
	}
}