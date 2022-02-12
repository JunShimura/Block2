using System;
using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public Action OnDeadAction = null;
    void OnCollisionEnter(Collision collision)
    {
        transform.SetParent(null);
        Destroy(gameObject);
        if (OnDeadAction != null)
        {
            OnDeadAction();
        }
    }
}
