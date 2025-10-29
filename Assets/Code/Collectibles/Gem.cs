using System;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    [Header("Particles")]
    public GameObject splashParticle;

    [Header("Audio")]
    public AudioClip collectSound;
    private AudioSource audioSource;

    public static event Action OnGemCollected;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if (OnGemCollected != null)
        {
            OnGemCollected.Invoke();
        }
        else
        {
            Debug.LogWarning("OnGemCollected event is null! Ensure it's subscribed.");
        }

        if (splashParticle != null)
        {
            Instantiate(splashParticle, transform.position, Quaternion.identity);
        }

        if (collectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collectSound);
        }

        Debug.Log("Gem collected!");
        Destroy(gameObject);
    }
}