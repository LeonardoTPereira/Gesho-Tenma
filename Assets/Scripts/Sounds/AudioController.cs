using System;
using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sounds
{
    public class AudioController : MonoBehaviour
    {
        public struct Audio
        {
            public Audio(AudioSource source, Sound sound)
            {
                Source = source;
                Sound = sound;
            }

            public AudioSource Source;
            public Sound Sound;
        }

        private Dictionary<string, Audio> _audioDictionary = new Dictionary<string, Audio>();

        [SerializeField] [Header("Sounds")] 
        private List<Sound> soundEffects = new List<Sound>();
        [SerializeField]
        private List<Sound> bgms = new List<Sound>();

        private void Awake()
        {
            foreach (var sound in soundEffects)
            {
                _audioDictionary.Add(sound.name, new Audio(AddAudioSourceFromSoundSo(sound), sound));
            }
            foreach (var bgm in bgms)
            {
                _audioDictionary.Add(bgm.name, new Audio(AddAudioSourceFromSoundSo(bgm), bgm));
            }
        }

        private void OnEnable()
        {
            BattleScene.BattleStartEventHandler += PlayBGM;
            BattleScene.BattleStartEventHandler += PlayWarning;
        }
        
        private void OnDisable()
        {
            BattleScene.BattleStartEventHandler -= PlayBGM;
            BattleScene.BattleStartEventHandler -= PlayWarning;
        }

        private AudioSource AddAudioSourceFromSoundSo(Sound sound)
        {
            var newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.rolloffMode = sound.AudioMode;
            newAudioSource.outputAudioMixerGroup = sound.Output;
            newAudioSource.clip = sound.Clip;
            newAudioSource.volume = sound.Volume;
            newAudioSource.pitch = sound.Pitch;
            newAudioSource.loop = sound.Loop;
            newAudioSource.playOnAwake = sound.PlayOnAwake;
            newAudioSource.spatialBlend = sound.SpatialBlend;
            newAudioSource.maxDistance = sound.MaxRange;
            return newAudioSource;
        }
        


        private void PlayBGM(object sender, EventArgs eventArgs)
        {
            Debug.Log("Play BGM");
            PlaySound(_audioDictionary["Boss1Theme"]);
        }
        private void PlayWarning(object sender, EventArgs eventArgs)
        {
            Debug.Log("Play SFX");
            PlayAudioOnce(_audioDictionary["Warning"]);
        }

        private void PlaySound(Audio sound)
        {
            if (sound.Source.isPlaying)
                return;
            Debug.Log("Play: "+ sound.Source.clip.name);
            sound.Source.Play();
        }
     
        public void PlayAudioOnce(Audio sound)
        {
            if (sound.Source == null)
                return;
            Debug.Log("Play One Shot"+ sound.Source.clip.name);
            sound.Source.PlayOneShot(sound.Source.clip);
        }
     
        public void PlayAudioOnceRandomizePitch(AudioSource source, Sound sound)
        {
            if (source == null)
                return;
            source.pitch = (Random.Range(sound.PitchMin, sound.PitchMax));
            source.PlayOneShot(source.clip);
        }
     
        public void FadeOutAudio(AudioSource source)
        { StartCoroutine(StartFade(source, 2, 0)); }
     
        public IEnumerator StartFade(AudioSource fadeSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = fadeSource.volume;
     
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                fadeSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
        }
     
        public void StopAudio(AudioSource source)
        {
            if (source == null)
                return;
            source.Stop();
        }
        
        public List<Sound> SoundEffects => soundEffects;
        public List<Sound> BGMs => bgms;

    }
}