using System;
using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public Action OnDeadAction = null;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            transform.SetParent(null);
            Destroy(gameObject);
            if (OnDeadAction != null)
            {
                OnDeadAction();
            }
        }
    }
}
