using UnityEngine;
using System.Collections;

public class bulletShoot : MonoBehaviour {

	public Rigidbody2D rb;
	public float maxSpeed = 5f;
	// Use this for initialization
	void Start () {
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;
		//rb.AddRelativeForce(Vector3.up * 0.12f);
		rb.velocity = transform.TransformVector (Vector2.up * 12);
		Destroy (this.gameObject, 2f);
	}
	

}
