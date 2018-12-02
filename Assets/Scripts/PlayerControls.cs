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
	
	private RaycastHit2D hit;
	
	public float maxdistance = 1;
	public LayerMask layerMask;
	private LineRenderer lineRenderer;
	private SpringJoint2D joint;

	// Use this for initialization
	void Start ()
	{
		joint = gameObject.AddComponent<SpringJoint2D>();
		joint.enableCollision = true;
		joint.enabled = false;
		rb.GetComponent<Rigidbody2D>();
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		lineRenderer.SetWidth(0.1F,0.1F);
		lineRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lineRenderer.SetPosition(0,transform.position);
		lineRenderer.SetPosition(1,hit.point);
		
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetMouseButtonDown(0))
		{
			lineRenderer.enabled = true;
			Vector3 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 directionOfMouse = mouseClickPosition - transform.position;
			hit = Physics2D.Raycast(transform.position, directionOfMouse, maxdistance, layerMask);
			print(hit.point.x+" - "+hit.point.y);
			Debug.DrawLine(transform.position, hit.point, Color.yellow,5);
			joint.enabled = true;
			joint.connectedAnchor = hit.point;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{ 
			rb.velocity = new Vector2(-3, rb.velocity.y);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{ 
			rb.velocity = new Vector2(3, rb.velocity.y);
		}
		if (Input.GetKey(KeyCode.UpArrow)&&onGround)
		{
			rb.velocity = new Vector2(rb.velocity.x, 10);
		}

		if (onGround)
		{
			joint.enabled = false;
			lineRenderer.enabled = false;
		}
	}
}
