using System.Collections.Generic;
using UnityEngine;

namespace WizardGame.Common.Sounds
{
    public class RandomSoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private List<AudioClip> _sounds;

        [Range(0.7f, 1f)]
        [SerializeField]
        private float _minRandomPitch = 0.9f;
        
        [Range(1f, 1.3f)]
        [SerializeField] 
        private float _maxRandomPitch;

        private void Start()
        {
            if (_audioSource == null)
            {
                var errorMessage = $"Audio Source on {gameObject.name} not found!";
                throw new System.Exception(errorMessage);
            }
        }

        public void PlayRandomSound()
        {
            _audioSource.clip = _sounds[Random.Range(0, _sounds.Count)];
            _audioSource.pitch = Random.Range(_minRandomPitch, _maxRandomPitch);
            _audioSource.Play();
        }
    }
}
