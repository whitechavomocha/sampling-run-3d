using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class SettingsPanel : MonoBehaviour
    {
        GameObject p_settings;
        GameObject b_vib;
        GameObject b_sound;

        private void Start()
        {
            p_settings = transform.GetChild(0).gameObject;
            b_vib = p_settings.transform.GetChild(0).transform.GetChild(3).gameObject;
            b_sound = p_settings.transform.GetChild(0).transform.GetChild(4).gameObject;
            SetStartButtons();
        }
        public void SettingsButtonHandleEvent()
        {
            p_settings.SetActive(true);
        }
        public void ExitButtonHandleEvent()
        {
            p_settings.SetActive(false);
        }
        void SetStartButtons()
        {
            if (GameManager.Vibration == 1)
            {
                b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On");
            }
            else
            {
                b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off");
            }
            if (GameManager.Sound == 1)
            {
                b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On");
            }
            else
            {
                b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off");
            }
        }
        public void VibrationButtonHandleEvent()
        {
            if (GameManager.Vibration == 1)
            {
                GameManager.Vibration = 0;
                b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off");
            }
            else
            {
                GameManager.Vibration = 1;
                b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On");
            }
        }
        public void SoundButtonHandleEvent()
        {
            if (GameManager.Sound == 1)
            {
                GameManager.Sound = 0;
                b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off");
            }
            else
            {
                GameManager.Sound = 1;
                b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On");
            }
        }
    }