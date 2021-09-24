using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private Transform target;
	public float speed;
	void Start () {
		if (GameObject.Find ("playerSpacecraft(Clone)") != null) {
			target = GameObject.Find ("playerSpacecraft(Clone)").GetComponent <Transform> ();
		}
	}
	void Update() {
		if (target) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
}
	