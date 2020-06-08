using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour

{
   [SerializeField] private AudioSource music;

   [SerializeField] private AudioSource effects;
   
   #region Singleton

   public static AudioManager Instance { get; private set; }

   // public static AudioManager Instance
   // {
   //    get
   //    {
   //       // возврат значения переменной instance
   //       return instance;
   //    }
   // }

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

   public void PLaySound(AudioClip audio)
   {
      effects.PlayOneShot(audio);
      DontDestroyOnLoad(gameObject);
   }
}
