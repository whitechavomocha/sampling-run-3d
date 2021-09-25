using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using ElephantSDK;
public class UpperPanel : MonoBehaviour
{
    public static UpperPanel instance;
    Image leaves;
    private void Awake()
    {
        instance = this;
        leaves = transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>();
    }
    private void Start()
    {
        transform.GetChild(2).GetComponent<Text>().text = "LEVEL "+GameManager.Level + string.Empty;
    }

    public void Activater(bool status = true, int childIndex = int.MinValue)
    {
        if (childIndex != int.MinValue)
        {
            transform.GetChild(childIndex).gameObject.SetActive(status);
        }
    }

    public void RetryButtonHandleEvent()
    {
        //Elephant.LevelFailed(GameManager.Level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowLeavesCount(int index)
    {
        leaves.fillAmount = (12.5f * (index+1)) / 100;
    
    }

    public void HideUnnecessaryChildatFinish()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

}
