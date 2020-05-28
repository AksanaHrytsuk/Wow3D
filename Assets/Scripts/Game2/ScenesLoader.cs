using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesLoader : MonoBehaviour
{
    #region Singleton

    public static ScenesLoader Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }
    #endregion

    public  void RestartLevel(float delay)
    {
        StartCoroutine(ReloadLevelWithDelay(delay));
    }
    
    // public void RestartLevel()
    // {
    //     // получить индекс текущей сцены
    //     int ccurentScene = SceneManager.GetActiveScene().buildIndex;
    //     // перезагрузка текущей сцены
    //     SceneManager.LoadScene(ccurentScene);
    // }
    IEnumerator ReloadLevelWithDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        
        int ccurentScene = SceneManager.GetActiveScene().buildIndex;
       
        SceneManager.LoadScene(ccurentScene);
    }
}
