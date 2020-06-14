using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private CanvasGroup popUp;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        popUp.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        popUp.gameObject.SetActive(true);
        popUp.alpha = 0;
        popUp.DOFade(1, fadeDuration).SetUpdate(true);
        
        Time.timeScale = 0;

        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
    }

    public void HideMenu()
    {
        popUp.DOFade(0, fadeDuration).OnComplete(() =>
        {
            popUp.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
            ).SetUpdate(true);
    }
    
    public  void MusicVolumeChanged()
    {
        // Debug.Log("Music" + musicSlider.value);
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }
}
