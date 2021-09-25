using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speed;
    private void Update()
    {
        if(LevelManager.gameState == GameState.Phase1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }


        
    }
}
