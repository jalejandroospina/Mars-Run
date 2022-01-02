using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    [SerializeField] protected AudioClip[] sounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void SelectSound(int indice, float volume)
    {
        audioSource.PlayOneShot(sounds[indice], volume);
    }

}
