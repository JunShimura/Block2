using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 20.0f;
    public Vector3 initialForce = new Vector3(1, 0, 1);
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().AddForce(
            initialForce * speed, ForceMode.VelocityChange);
    }
}
