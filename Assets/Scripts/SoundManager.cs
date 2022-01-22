using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource maintheme;
    [SerializeField] private AudioSource endtheme;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        PlayerController.OnDeath += OnDeathHandler;
        PlayerController.OnFinish += OnFinishHandler;
    }

    public void OnDeathHandler()
    {
        maintheme.Stop();
        endtheme.Play();

        PlayerController.OnDeath -= OnDeathHandler;
    }
    public void OnFinishHandler()
    {

        maintheme.Stop();
        PlayerController.OnFinish -= OnFinishHandler;
    }


}
