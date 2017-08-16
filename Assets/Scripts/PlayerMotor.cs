using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {
	private CharacterController controller;
	private float speed = 3.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;
	private Vector3 moveVector;
    private float animationDuration = 3.0f;
    private float startTime;
    private bool isDead = false;
	// Use this for initialization
	void Start () {
	controller = GetComponent<CharacterController>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
    if (isDead)
        {
            return;
           
        }
         
    if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
        }
    moveVector = Vector3.zero;
	if(controller.isGrounded)
	{
		verticalVelocity = -0.5f;
	}
	else
	{
		verticalVelocity -= gravity*Time.deltaTime;
	}
	//x
	moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
    if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > Screen.width/2)
            {
                moveVector.x = speed;
            }
            else
            {
                moveVector.x = -speed;
            }
        }
	//y
	moveVector.y = verticalVelocity;
		
	//z
	moveVector.z = speed;
    controller.Move(moveVector* Time.deltaTime);
	}

    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((hit.point.z > transform.position.z + controller.radius) && (hit.point.y > transform.position.y+0.5f))
            Death();
    }
    private void Death()
    {
        //Debug.Log("Collission");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
