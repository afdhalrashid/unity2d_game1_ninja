using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D myrigidBody;
    [SerializeField]
    private float character_speed = 3;

	// Use this for initialization
	void Start () {
        myrigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
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
	}

    private void HandleMovement(float h)
    {

        myrigidBody.velocity = new Vector2(h * character_speed, myrigidBody.velocity.y);
    }
}
