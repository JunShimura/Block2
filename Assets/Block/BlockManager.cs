using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Action OnBlockBroken = null;
    public Action OnBlockBrokenAll = null;
    private int nBlock = 0;
    // Start is called before the first frame update
    void Awake()
    {
        nBlock = this.transform.childCount;
        IEnumerable<Block> blocks = GetComponentsInChildren<Block>();
        foreach (var block in blocks)
        {
            block.OnDeadAction = OnBlockDead;
        }
    }
    private void OnBlockDead()
    {
        var n = this.transform.childCount;
        if (n <= nBlock)
        {
            //�u���b�N��nBlock-n�������Ă���
            Debug.Log($"�u���b�N����������A�c���{n}��");
            if (OnBlockBroken != null)
            {
                OnBlockBroken();
            }
            if (n == 0)
            {
                //�S����������
                if (OnBlockBrokenAll != null)
                {
                    OnBlockBrokenAll();
                }
                Debug.Log($"�u���b�N���S���������A�c���{n}��");
            }
        }

    }
}
