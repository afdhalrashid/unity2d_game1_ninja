using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D myrigidBody;
    private Animator myanimator;
    [SerializeField]
    private float character_speed = 3;
    private bool facingRight;
    private bool attack;

	// Use this for initialization
	void Start () {
        facingRight = true;
        myrigidBody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {
        HandleInput();

    }
	void FixedUpdate () {
        float Horizontal = Input.GetAxis("Horizontal");

        //if (Horizontal < 0 ) {
        //    Horizontal -= 3;
        //}
        
        //if (Horizontal > 0 ) {
        //    Horizontal += 3;
        //}
        Debug.Log(Horizontal);
        
        HandleMovement(Horizontal);
        flip(Horizontal);// right/left
        HandleAttack();
        ResetValue();
	}

    private void HandleMovement(float h)
    {
        if (!this.myanimator.GetCurrentAnimatorStateInfo(0).IsTag("attack")) //animator->layer->firstlayer / tag on animation
        {
            myrigidBody.velocity = new Vector2(h * character_speed, myrigidBody.velocity.y);

        }
        //else if (this.myanimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        //{
        //    myrigidBody.velocity = new Vector2(0, 0);
        //}

        myanimator.SetFloat("speed", Mathf.Abs(h)); //run animation
    }

    private void HandleAttack()
    {
        if (attack && !this.myanimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            myanimator.SetTrigger("attack");
            myrigidBody.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            attack = true;
        }        
        
    }
   

    private void flip(float horizontal)
    {
        if (horizontal < 0 && facingRight == true)
        {
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (horizontal > 0 && facingRight == false)
        {
            facingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValue()
    {
        attack = false;
    }

}
