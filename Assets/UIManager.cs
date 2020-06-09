using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1;
    [SerializeField] private CanvasGroup popUp;

    public void ShowMenu()
    {
        popUp.gameObject.SetActive(true);
        popUp.DOFade(1, fadeDuration);
    }

    public void HideMenu()
    {
        popUp.DOFade(0, fadeDuration).OnComplete(() => popUp.gameObject.SetActive(false));
    }
}
