using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    [SerializeField] GameController.GameState nextState;  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // クリックされた
            Debug.Log("クリックされた");
            GameController.gameState = nextState;
        }      
    }
}
