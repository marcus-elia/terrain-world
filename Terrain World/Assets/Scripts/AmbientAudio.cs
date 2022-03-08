using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    public AudioClip ambient1;
    public AudioClip ambient2;
    public AudioSource audioSource;
    private bool clip1 = true;
    public AudioClip majestic;
    public Transform playerTransform;
    public Transform lastTower;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = ambient1;
        audioSource.loop = false;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if(clip1)
            {
                audioSource.clip = ambient2;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = ambient1;
                audioSource.Play();
            }
            clip1 = !clip1;
        }
        if(!gameEnded && Vector3.Distance(playerTransform.position, lastTower.position) < 3)
        {
            audioSource.clip = majestic;
            audioSource.Play();
            gameEnded = true;
        }
    }

    public void Mute()
    {
        audioSource.volume = 0;
    }
    public void UnMute()
    {
        audioSource.volume = 1;
    }
}
