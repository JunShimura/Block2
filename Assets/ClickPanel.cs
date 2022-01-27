using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPanel : MonoBehaviour
{
    public Action OnClickedAction = null;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // クリックされた
            Debug.Log("クリックされた");
            if (OnClickedAction != null)
            {
                OnClickedAction();
            }
        }
    }
}
