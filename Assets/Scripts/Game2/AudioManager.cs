using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour

{
   [SerializeField] private AudioSource music;

   [SerializeField] private AudioSource effects;
   
   #region Singleton

   private static AudioManager instance;

   public static AudioManager Instance
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

   public void PLaySound(AudioClip audio)
   {
      effects.PlayOneShot(audio);
   }
}
