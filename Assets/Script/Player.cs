using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D body2D;
	private Vector2 moveDirection;
	private float x;

	public float movePower = 5;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		body2D = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
	}


	void FixedUpdate ()
	{
		#if UNITY_EDITOR
		if (Input.GetMouseButton (0)) {
			moveDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x ? Vector2.left : Vector2.right;
		}
		body2D.velocity = moveDirection * (Input.GetMouseButton (0) ? movePower : 0);
		#elif UNITY_ANDROID
		if(Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount == 1) {
		    x = Input.GetTouch (0).position.x;
		    moveDirection=x <= Screen.width / 2 ? Vector2.left : Vector2.right;
		}
		body2D.velocity = moveDirection * (Input.GetTouch(0).phase == TouchPhase.Stationary ? movePower : 0);
		#endif
		anim.SetBool ("isMove", body2D.velocity.x != 0);
	}

	void OnCollisionEnter2D(Collision2D othre)
	{
		if (othre.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			GameController.GetInstance ().GameOver ();
			gameObject.SetActive (false);
		}
	}
}
