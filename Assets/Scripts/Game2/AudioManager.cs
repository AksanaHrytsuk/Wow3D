using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour

{
   [SerializeField] private AudioSource music;
   [SerializeField] private AudioSource effects;
   private const string PREFS_MUSIC_VOLUME = "MusicVolume";
   private const string PREFS_EFFECT_VOLUME = "EffectVolume";
   
   #region Singleton
   public static AudioManager Instance { get; private set; }
   public void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
      }
      else
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
         // music.volume = PlayerPrefs.GetFloat(PREFS_MUSIC_VOLUME, 0.3f);
         // effects.volume = PlayerPrefs.GetFloat(PREFS_EFFECT_VOLUME, 0.5f);
      }
   }
   #endregion

   public void PLaySound(AudioClip audio)
   {
      DontDestroyOnLoad(gameObject);
      effects.PlayOneShot(audio);
   }
   
   // задать значение 
   public void SetMusicVolume(float volume)
   {
      // переданная громкость в функцию устанавливается в music
      music.volume = volume;
      PlayerPrefs.SetFloat("PREFS_MUSIC_VOLUME", volume); //
   }
   
   // получить значение
   public float GetMusicVolume()
   {
      return music.volume;
   }

   public void SetEffectVolume(float volume)
   {
      effects.volume = volume;
      PlayerPrefs.SetFloat("PREFS_EFFECT_VOLUME", volume); //
   }

   public float GetEffectVolume()
   {
      return effects.volume;
   }
}
