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
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
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
