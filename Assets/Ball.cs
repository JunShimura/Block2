using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public float speed = 20.0f;
    public Vector3 initialForce = new Vector3(1, 0, 1);
    public float maxSpeed = 1.0f;
    public int speedUpCycle = 20;
    public float speedUpRatio = 1.0625f;
    private int collisionCount = 0;
    public float exclusionVelocityY = 0.125f;
    private Vector3 adjust = Vector3.zero;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(
            initialForce.normalized * speed, ForceMode.VelocityChange);
        collisionCount = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisionCount= (collisionCount+1)%speedUpCycle;
        if (collisionCount == 0&&rb.velocity.magnitude<maxSpeed)
        {
            rb.velocity = rb.velocity * speedUpRatio;
        }
        if (Mathf.Abs(rb.velocity.y) < exclusionVelocityY)
        {
            var v = new Vector3(
                rb.velocity.x,
                exclusionVelocityY*Mathf.Sign(rb.velocity.y)*2,
                rb.velocity.z)
                .normalized
                *rb.velocity.magnitude;
            Debug.Log($"補正{rb.velocity.ToString()}⇒{v.ToString()}");
            adjust = v;
        }
    }
    private void FixedUpdate()
    {
        if(adjust != Vector3.zero)
        {
            rb.velocity = adjust;
            adjust = Vector3.zero;
        }
    }
}
