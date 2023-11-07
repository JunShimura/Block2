using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour
{
    public float accel = 1000.0f;
    [SerializeField]
    private Vector3 inputVector = new Vector3();
    private Rigidbody rig;
    // Use this for initialization
    void Start()
    {
        inputVector = Vector3.zero;
        rig = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = Vector3.right * Input.GetAxisRaw("Horizontal") * accel;

    }
    void FixedUpdate()
    {
        rig.AddForce(inputVector, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>()!=null)
        {
            Debug.Log($"On Racket{collision.gameObject.GetComponent<Rigidbody>().velocity}");
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            var velocity = rb.velocity;
            var contact = collision.GetContact(0);
            rb.gameObject.transform.LookAt((contact.point - this.transform.position)* velocity.magnitude);
            rb.velocity = rb.gameObject.transform.forward * velocity.magnitude;
        }
    }
}
