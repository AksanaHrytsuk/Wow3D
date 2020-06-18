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
    [SerializeField] private Slider effectsSlider;

    private void Start()
    {
        popUp.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        // включает меню
        popUp.gameObject.SetActive(true);
        popUp.alpha = 0;
        // плавное проявление меню с 0 до 1 по алфаканалу за fadeDuration. 
        // Твин выполнится со скоростью 1 независимо от значения Time.timeScale
        popUp.DOFade(1, fadeDuration).SetUpdate(true);
        
        Time.timeScale = 0;
        // слайдеру(громкости) передаётся значение, записанное в AudioManager
        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
        effectsSlider.value = AudioManager.Instance.GetEffectVolume() * effectsSlider.maxValue;
    }

    public void HideMenu()
    {
        // плавное увядание меню с 1 до 0 по алфаканалу за fadeDuration
        popUp.DOFade(0, fadeDuration).OnComplete(() =>
        {
            // выключает меню
            popUp.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
            ).SetUpdate(true);
    }
    
    public  void MusicVolumeChanged()
    {
        // Делим на maxValue для того, чтобы совпадало значение в слайдере от 0 до 10, а в AudioSours от 0,1 до 1
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }
    public  void EffectVolumeChanged()
    {
        AudioManager.Instance.SetEffectVolume(effectsSlider.value / effectsSlider.maxValue);
    }
}
