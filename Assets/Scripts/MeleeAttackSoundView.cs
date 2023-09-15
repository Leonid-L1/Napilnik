using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackSoundView : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _attackSounds;

    public void Play()
    {
        AudioSource soundToPlay = _attackSounds[Random.Range(0,_attackSounds.Count)];
        soundToPlay.pitch = Random.Range(StaticFields.MinPitch, StaticFields.MaxPitch);
        soundToPlay.Play();
    }
}
