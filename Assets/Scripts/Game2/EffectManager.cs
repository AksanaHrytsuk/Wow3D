using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    
    #region Singleton

    public static EffectManager instance { get; private set; }

    public static EffectManager Instance
    {
        get
        {
            // возврат значения переменной instance
            return instance;
        }
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }
    #endregion

    public void CreateEffect(GameObject response)
    {
        if (response != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: response, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }
}
