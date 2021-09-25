using UnityEngine;
using UnityEngine.UI;

public class PlayArea : MonoBehaviour
{
    void Start()
    {
        LevelManager.gameState = GameState.BeforeStart;
    }

    public void GameStarter()
    {
        Debug.Log("GameStarter()");
        LevelManager.gameState = GameState.Phase1;
        UpperPanel.instance.transform.GetChild(0).gameObject.SetActive(true);
        UpperPanel.instance.transform.GetChild(1).gameObject.SetActive(false);
        UpperPanel.instance.transform.GetChild(3).gameObject.SetActive(true);
        gameObject.SetActive(false);
        Player.instance.DetermineAnimCondition(1);
     



    }
}
