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
            //ブロックがnBlock-n分消えている
            Debug.Log($"ブロックが一つ消えた、残りは{n}個");
            if (OnBlockBroken != null)
            {
                OnBlockBroken();
            }
            if (n == 0)
            {
                //全部が消えた
                if (OnBlockBrokenAll != null)
                {
                    OnBlockBrokenAll();
                }
                Debug.Log($"ブロックが全部消えた、残りは{n}個");
            }
        }

    }
}
