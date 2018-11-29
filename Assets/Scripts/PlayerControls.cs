using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public Rigidbody2D rb;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;

	// Use this for initialization
	void Start ()
	{
		rb.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetMouseButtonDown(0))
		{
			Clicked();
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{ 
			rb.velocity = new Vector2(-3, rb.velocity.y);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{ 
			rb.velocity = new Vector2(3, rb.velocity.y);
		}
		if (Input.GetKeyDown("space")&&onGround)
		{
			rb.velocity = new Vector2(rb.velocity.x, 10);
		}
	}
	
	void Clicked()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
		RaycastHit hit = new RaycastHit();
 
		if (Physics.Raycast (ray, out hit))
		{
			Debug.Log(hit.collider.gameObject.name);
		}
	}
}
