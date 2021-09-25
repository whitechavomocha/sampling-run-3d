using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    float horizontal;


    private void Update()
    {
        MoveHorizontal();
    }

    void MoveHorizontal()
    {
        if (LevelManager.gameState == GameState.Phase1)
        {
            horizontal = InputPanel.instance.horizontal;
            float coefficent = 100;

#if UNITY_EDITOR
            horizontal = Input.GetAxisRaw("Horizontal");
            coefficent = 10;
#endif

            Vector3 temp = transform.localPosition;
            temp.x += horizontal * Time.deltaTime * coefficent;
            temp.x = Mathf.Clamp(temp.x, -11f, 11f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, temp, 0.8f);
        }
    }
}
