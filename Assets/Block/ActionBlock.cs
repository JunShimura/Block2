using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBlock : MonoBehaviour
{
    public Action OnCollisionAction = null;
    public string destinationTag ="Ball";
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag ==destinationTag )
        {
            if (OnCollisionAction != null)
            {
                OnCollisionAction();
            }
        }
    }
}
