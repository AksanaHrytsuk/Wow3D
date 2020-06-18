﻿
using UnityEngine;


[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour

{
   [Header("Sounds")] [SerializeField] private AudioClip[] musicPlayList;
   [SerializeField] private AudioSource  music;
   [SerializeField] private AudioSource effects;
   [SerializeField] private bool rundomMusic;
   private const string PREFS_MUSIC_VOLUME = "MusicVolume";
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
      if (!music.isPlaying)
      {
         ChangeMusicIndex(); // поменять индекс
         music.clip = musicPlayList[musicIndex];
         music.Play(); //воспроизвести 
      }
   }
   
  
   private void ChangeMusicIndex()
   {
      if (rundomMusic)
      {
         Shuffle();
      }
      else
      {
         Consistently();
      }
   }
   
   // воспроизведение музыки по кругу
   // Если песня последняя в списке, то след запускается под индексом 0, если не последняя песня в массиве
   // то увеличить индекс
   void Consistently()
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
   
   // перемешать индексы в массиве 
   void Shuffle()
   {
      musicIndex = Random.Range(0, musicCount + 1);
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
      PlayerPrefs.SetFloat("PREFS_EFFECT_VOLUME", volume); //сохраняет громкость в реестре
   }
   
   // возвращает громкость эффектов
   public float GetEffectVolume()
   {
      return effects.volume;
   }

   // песня с индексом 0 запускается при старте
   private void Start()
   {
      // колличество песен на старте игры (длина массива)
      musicCount = musicPlayList.Length-1;
      // воспроизвести музыку
      music.Play();
   }

   private void Update()
   {
      PLayMusic();
   }
}
