using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler , IPointerDownHandler 
{
    public static InputPanel instance;
    [System.NonSerialized] public float horizontal;
    Vector2 _lastPosition = Vector2.zero;
    int count = 0;

    private void Awake()
    {
        instance = this;
        count = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (LevelManager.gameState == GameState.Phase1)
        {
            horizontal = 0;
        }      
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(LevelManager.gameState == GameState.Phase1)
        {
            Vector2 direction = eventData.position - _lastPosition;
            horizontal = direction.x / Screen.width;
            _lastPosition = eventData.position;
        }
        
     
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        horizontal = 0;
        _lastPosition = Vector2.zero;
    }


    //--------------------------------------------------------------------------

    public void GrowTreeAtFinish(GameObject obj)
    {
        count++;
        GameObject particleEmoji;
        AudioManager.Play(AudioClipName.CartoonBubble);
       
        if(count < 7)
        {
            Debug.Log("asdasdasd");
            obj.transform.localScale *= 1.1f;
        }

        int coeffecient = (Player.instance.saplingIndex * count);

        if (coeffecient == 0)
        {
            particleEmoji =  Instantiate(LevelManager.instance.emojis[0], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
         else if (coeffecient > 5)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[1], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 10)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[2], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 15)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[3], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 20)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[4], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 25)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[5], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 30)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[6], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 35)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[7], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 40)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[8], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else if (coeffecient > 45)
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[9], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }
        else
        {
            particleEmoji = Instantiate(LevelManager.instance.emojis[9], Player.instance.toprak.transform.position + Vector3.up * 4f + Vector3.back * 3f, Quaternion.identity);
        }

        Debug.Log("particleEmoji:" + particleEmoji);

        switch (Player.instance.saplingIndex)
        {
            case 0:
                particleEmoji.transform.localScale = Vector3.one * 1.77f;
                break;
            case 1:
                particleEmoji.transform.localScale = Vector3.one * 2.15f * 0.5f;
                break;
            case 2:
                particleEmoji.transform.localScale = Vector3.one * 2.7f * 0.5f;
                break;
            case 3:
                particleEmoji.transform.localScale = Vector3.one * 3.3f * 0.5f;
                break;
            case 4:
                particleEmoji.transform.localScale = Vector3.one * 4f * 0.5f;
                break;
            case 5:
                particleEmoji.transform.localScale = Vector3.one * 4.8f * 0.5f;
                break;
            case 6:
                particleEmoji.transform.localScale = Vector3.one * 5.6f * 0.5f;
                break;
            case 7:
                particleEmoji.transform.localScale = Vector3.one * 6.3f * 0.5f;
                break;
            default:
                particleEmoji.transform.localScale = Vector3.one * 1.77f * 0.5f;
                break;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (LevelManager.gameState == GameState.Phase2)
        {
            if (Player.instance.toprak != null)
            {
                GrowTreeAtFinish(Player.instance.toprak);
            }
        }
    }
}
