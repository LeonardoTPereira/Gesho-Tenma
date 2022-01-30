using System;
using System.Collections;
using System.Collections.Generic;
using Boss;
using Events;
using Player;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapons;
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
            BossHealth.BossTakeDamageEventHandler += PlayEnemyHit;
            BossAttackState.BossPowerUpEventHandler += PlayBossPowerUp;
            BossAttackState.BossDeathEventHandler += PlayBossDeath;
            PlayerController.PlayerTakeDamageEventHandler += PlayPlayerHit;
            BattleScene.BattleWonEventHandler += PlayFanfare;
        }
        
        private void OnDisable()
        {
            BattleScene.BattleStartEventHandler -= PlayBGM;
            BattleScene.BattleStartEventHandler -= PlayWarning;
            BossHealth.BossTakeDamageEventHandler -= PlayEnemyHit;
            BossAttackState.BossPowerUpEventHandler -= PlayBossPowerUp;
            BossAttackState.BossDeathEventHandler -= PlayBossDeath;
            PlayerController.PlayerTakeDamageEventHandler -= PlayPlayerHit;
            BattleScene.BattleWonEventHandler -= PlayFanfare;
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
            PlaySound(_audioDictionary["Boss1Theme"]);
        }
        private void PlayFanfare(object sender, EventArgs eventArgs)
        {
            StopAudio(_audioDictionary["Boss1Theme"]);
            PlaySound(_audioDictionary["VictoryTheme"]);
        }
        private void PlayWarning(object sender, EventArgs eventArgs)
        {
            PlayAudioOnce(_audioDictionary["Warning"]);
        }        
        private void PlayBossPowerUp(object sender, EventArgs eventArgs)
        {
            PlayAudioOnce(_audioDictionary["BossPowerUp"]);
        }       
        private void PlayBossDeath(object sender, EventArgs eventArgs)
        {
            PlayAudioOnce(_audioDictionary["BossDeath"]);
        }
        private void PlayEnemyHit(object sender, TakeDamageEventArgs eventArgs)
        {
            PlayAudioOnceRandomizePitch(_audioDictionary["BossDamaged"], eventArgs.Damage);
        }
        private void PlayPlayerHit(object sender, TakeDamageEventArgs eventArgs)
        {
            PlayAudioOnceRandomizePitch(_audioDictionary["PlayerDeath"], eventArgs.Damage);
        }

        private void PlaySound(Audio sound)
        {
            if (sound.Source.isPlaying)
                return;
            sound.Source.Play();
        }
     
        public void PlayAudioOnce(Audio sound)
        {
            if (sound.Source == null)
                return;
            sound.Source.PlayOneShot(sound.Source.clip);
        }
     
        public void PlayAudioOnceRandomizePitch(Audio sound, int pitchOffset)
        {
            if (sound.Source == null)
                return;
            sound.Source.pitch = sound.Sound.Pitch + pitchOffset;
            sound.Source.PlayOneShot(sound.Source.clip);
            sound.Source.pitch = sound.Sound.Pitch;
        }
     
        public void FadeOutAudio(Audio sound)
        { StartCoroutine(StartFade(sound.Source, 2, 0)); }
     
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
     
        public void StopAudio(Audio sound)
        {
            if (sound.Source == null)
                return;
            sound.Source.Stop();
        }
        
        public List<Sound> SoundEffects => soundEffects;
        public List<Sound> BGMs => bgms;

    }
}