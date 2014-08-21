using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float speed = 2.0f;

	void Start() {
		rigidbody2D.velocity = Vector2.one.normalized * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight){
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D col) {
		// This function is called whenever the ball
		// collides with something
		int x;
		if (col.gameObject.name == "RacketLeft") {
			x = 1;
		} else if (col.gameObject.name == "RacketRight") {
			x = -1;
		} else {
			return;
		}

		float y = hitFactor (transform.position, col.transform.position, ((BoxCollider2D)col.collider).size.y);
		Vector2 dir = new Vector2(x, y).normalized;
		rigidbody2D.velocity = dir * speed; 

	}
} 
