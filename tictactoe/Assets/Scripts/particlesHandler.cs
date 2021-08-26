using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesHandler : MonoBehaviour
{
    public ParticleSystem particle;

    public List<AudioClip> audioSounds;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        int value = Random.RandomRange(0,audioSounds.Count);
        audioSource.clip = audioSounds[value];
        audioSource.Play();

        particle.gameObject.transform.position = transform.position;
        particle.Play();
    }
}
