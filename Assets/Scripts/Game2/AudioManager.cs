using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour

{
   [SerializeField] private AudioSource [] music;
   [SerializeField] private AudioSource effects;
   private const string PREFS_MxUSIC_VOLUME = "MusicVolume";
   private const string PREFS_EFFECT_VOLUME = "EffectVolume";
   private int musicIndex;
   private int musicCount;
   
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
   
   public void PLayMusic()
   {
      DontDestroyOnLoad(gameObject);
      // проверка, что песня играет
      // если не играет, то включаем следующую по индексу
      if (!music[musicIndex].isPlaying)
      {
         ChangeMusicIndex(); // поменять индекс
         music[musicIndex].Play(); //воспроизвести 
      }
   }
   
   // Если песня последняя в списке, то след запускается под индексом 0, если не последняя песня в массиве
   // то увеличить индекс
   private void ChangeMusicIndex()
   {
      if (musicIndex == musicCount)
      {
         musicIndex = 0;
      }
      else
      {
         musicIndex++;
      }
   }
   // задать значение 
   public void SetMusicVolume(float volume)
   {
      // переданная громкость в функцию устанавливается в music
      music[musicIndex].volume = volume;
      PlayerPrefs.SetFloat("PREFS_MUSIC_VOLUME", volume); //
   }
   
   // получить значение
   public float GetMusicVolume()
   {
      return music[musicIndex].volume;
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

   // песня с индексом 0 запускается при старте
   private void Start()
   {
      musicCount = music.Length-1;
      music[musicIndex].Play();
   }

   private void Update()
   {
      PLayMusic();
   }
}
