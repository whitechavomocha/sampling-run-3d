using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public static Player instance;
    [System.NonSerialized] public Animator anim;
    [System.NonSerialized] public int animConditionState;
    public GameObject mainPotHolder;
    int countPotHolder;
    public int saplingIndex = 0;
    [System.NonSerialized] public GameObject toprak;

    public void IncreaseSaplingCount()
    {
        if (saplingIndex < countPotHolder)
        {
            saplingIndex++;
            UpperPanel.instance.ShowLeavesCount(saplingIndex);
            if(saplingIndex != countPotHolder)
            {
                for (int i = 0; i < countPotHolder; i++)
                {
                    bool state = (i == saplingIndex) ? true : false;
                    mainPotHolder.transform.GetChild(i).gameObject.SetActive(state);
                }
            }
            saplingIndex = (saplingIndex == countPotHolder) ? (countPotHolder - 1) : saplingIndex;                 
        }
    }

    public void DecreaseSaplingCount()
    {
        if (saplingIndex > 0)
        {
            saplingIndex--;
            UpperPanel.instance.ShowLeavesCount(saplingIndex);
            for (int i = 0; i < countPotHolder; i++)
            {
                bool state = (i != saplingIndex) ? false : true;
                mainPotHolder.transform.GetChild(i).gameObject.SetActive(state);
            }          
        }
        else
        {
            CompletePanel.instance.Activator(false);
            RagdollActive();
        }
    }



    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        animConditionState = Animator.StringToHash("condition");
        countPotHolder = mainPotHolder.transform.childCount;
    }

    public void DetermineAnimCondition(int condition)
    {
        anim.SetInteger(animConditionState, condition);        
    }

    private void Update()
    {
        if(LevelManager.gameState == GameState.Phase1)
        {
            Vector3 temp = transform.localPosition;
            temp.x += InputPanel.instance.horizontal * Time.deltaTime * 2000;
            temp.x = Mathf.Clamp(temp.x, -9.5f, 9.5f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, temp, 0.8f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            IncreaseSaplingCount();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            DecreaseSaplingCount();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            if(LevelManager.gameState == GameState.Phase1)
            {
                Debug.Log("VICTORY");
                Vibration.Vibrate(500);
                UpperPanel.instance.HideUnnecessaryChildatFinish();
                DetermineAnimCondition(0);
                MoveSaplingToHole();
                transform.DOLocalMoveX(-2, 0.7f);
            }
            
            LevelManager.gameState = GameState.Victory;
        }
        else if (other.CompareTag("Trap"))
        {
            Vibration.Vibrate(150);
            other.tag = "Untagged";
            AudioManager.Play(AudioClipName.Trap);
            Player.instance.DecreaseSaplingCount();
         
        }
        else if (other.CompareTag("Watering Can"))
        {
            if(LevelManager.gameState == GameState.Phase1)
            {
                Vibration.Vibrate(150);
                LevelManager.instance.PlayParticleAtPosition(transform.position + transform.forward * 3f);
                AudioManager.Play(AudioClipName.CollectWateringCan);
                Player.instance.IncreaseSaplingCount();
                other.gameObject.SetActive(false);
            }       
        }
    }

    public void MoveSaplingToHole()
    {

        toprak = mainPotHolder.transform.GetChild(saplingIndex).gameObject;
        Camera.main.DOFieldOfView(45, 2f);

        Camera.main.transform.DOLocalRotate(Vector3.right * 18, 2f);
        Vector3 targetPos = Camera.main.transform.localPosition + Vector3.forward * 12 + Vector3.down * 14f ;
        Camera.main.transform.DOLocalMove(targetPos, 2f);


        toprak.transform.SetParent(null);
        Vector3 target1 =  toprak.transform.position + toprak.transform.up * 2f;
        toprak.transform.DOMove(target1, 0.4f)
            .OnComplete(() => 
            {
                LevelManager.instance.ConfettiExplode();
                toprak.transform.DOLocalRotate(Vector3.zero, 0.8f);
                GameObject targetHole = GameObject.FindGameObjectWithTag("TargetHole");
                toprak.transform.DOJump(targetHole.transform.position, 9, 1, 0.6f)
                .OnComplete(() =>
               {
               LevelManager.gameState = GameState.Phase2;
               InputPanel.instance.transform.GetChild(0).gameObject.SetActive(true);

                   DetermineAnimCondition(0);
                   Sequence mySeq = DOTween.Sequence();
                   mySeq.SetDelay(1.5f)
                       .OnComplete( () => 
                       {
                           LevelManager.instance.Victory();
                       });                
                });
            });       
    }

    public void ThrowSapling()
    {
        LevelManager.gameState = GameState.Failed;
        GameObject bitki = mainPotHolder.transform.GetChild(saplingIndex).GetChild(0).gameObject;
        bitki.transform.SetParent(null);
        Rigidbody rg =  bitki.AddComponent<Rigidbody>();
        rg.mass = 10;
        MeshCollider col = bitki.AddComponent<MeshCollider>();
        col.convex = true;

        rg.AddForce((Vector3.forward * 5 + Vector3.up * 11 ) * 500)  ;
    }

    public void RagdollActive()
    {
 
        LevelManager.gameState = GameState.Failed;
        anim.enabled = false;
        Rigidbody[] rgArray = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rgArray)
        {
            rb.isKinematic = false;
            rb.AddForce(Vector3.back * 150f + Vector3.up * 40f);
        }
        ThrowSapling();

    }



}
