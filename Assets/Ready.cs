using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    [SerializeField] GameController.GameState nextState;  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // クリックされた
            Debug.Log("クリックされた");
            GameController.gameState = nextState;
        }      
    }
}
