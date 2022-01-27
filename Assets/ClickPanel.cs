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
            // �N���b�N���ꂽ
            Debug.Log("�N���b�N���ꂽ");
            if (OnClickedAction != null)
            {
                OnClickedAction();
            }
        }
    }
}
