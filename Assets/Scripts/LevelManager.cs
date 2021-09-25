using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static GameState gameState;

    LevelAssetCreate levelAsset;
    GameObject[] levelPrefabs;
    GameObject[] particles;
    [System.NonSerialized] public GameObject[] emojis;

    [System.NonSerialized] public GameObject treeHolder;
    [System.NonSerialized] public GameObject particleHolder;
    [System.NonSerialized] public int particleCounter = 0;

    private void Awake()
    {
        instance = this;
        gameState = GameState.Phase1;
        SetValues();
        CreateLevel();
    }

    //-----------------------------------------------------------------------
    void SetValues()
    {
        particleHolder = new GameObject("Particles Holder");

        levelAsset = Resources.Load<LevelAssetCreate>("Scriptables/LevelAsset");
        levelPrefabs = levelAsset.levelPrefabs;
        particles = levelAsset.particles;
        emojis = levelAsset.emojis;


        ParticleSpawner();
        treeHolder = GameObject.FindGameObjectWithTag("TreeHolder");
    }

    //-----------------------------------------------------------------------
    void CreateLevel()
    {
        if (GameManager.Level < levelPrefabs.Length)
        {
            Instantiate(levelPrefabs[GameManager.Level - 1], Vector3.zero, Quaternion.identity);
        }
        else
        {
            int random = UnityEngine.Random.Range(0, levelPrefabs.Length);
            GameObject createdLEvel = Instantiate(levelPrefabs[random], Vector3.zero, Quaternion.identity);;
        }

        treeHolder = GameObject.FindGameObjectWithTag("TreeHolder");
    }

    //-----------------------------------------------------------------------
    void ParticleSpawner()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(particles[0], particleHolder.transform, false);
        }
    }

    public void PlayParticleAtPosition(Vector3 pos)
    {
        particleHolder.transform.GetChild(particleCounter).transform.position = pos;
        particleHolder.transform.GetChild(particleCounter).transform.GetComponent<ParticleSystem>().Play();
        particleCounter++;
        if (particleCounter > particleHolder.transform.childCount - 1)
        {
            particleCounter = 0;
        }
    }

    public void GrowFinishTree()
    {
        Debug.Log("GrowFinishTree" + treeHolder);
        if (treeHolder)
        {
            if(treeHolder.transform.childCount > 0)
            {
                for (int i = 0; i < treeHolder.transform.childCount; i++)
                {
                    treeHolder.transform.GetChild(i).gameObject.transform.DOScale(5, 0.8f);
                }
            }
        }
    }

    public void ConfettiExplode()
    {
        GameObject conffetiHolder = GameObject.FindGameObjectWithTag("ConfettiHolder");
        if (conffetiHolder)
        {
            for (int i = 0; i < conffetiHolder.transform.childCount; i++)
            {
                conffetiHolder.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }


    public void Victory()
    {
       
        CompletePanel.instance.Activator(true);
        InputPanel.instance.gameObject.SetActive(false);
        Player.instance.DetermineAnimCondition(2);
    }

}
