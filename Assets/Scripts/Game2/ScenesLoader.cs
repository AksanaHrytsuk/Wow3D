using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesLoader : MonoBehaviour
{
    #region Singleton

    private static ScenesLoader instance;

    public static ScenesLoader Instance
    {
        get
        {
            // возврат значения переменной instance
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }
    #endregion

    public  void RestartLevel(float delay)
    {
        StartCoroutine(RestartLevelCoroutine(delay));
    }
    
    IEnumerator RestartLevelCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        int curentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curentScene);
    }
    
    public void RestartLevel()
    {
        // получить индекс текущей сцены
        int ccurentScene = SceneManager.GetActiveScene().buildIndex;
        // перезагрузка текущей сцены
        SceneManager.LoadScene(ccurentScene);
    }
    
    public void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1, LoadSceneMode.Single);
    }
}
