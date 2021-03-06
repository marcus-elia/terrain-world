using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public Transform playerGroundCheck;
    public Transform topOfTower;
    private float targetRadius = 2f;
    public GameObject targetIndicator;
    public GameObject towerCube1;
    public GameObject towerCube2;
    public PlayerMovement player;

    public AudioSource audioSource;
    public AudioClip towerAchieved;

    public AmbientAudio ambientSource;
    private bool musicHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (musicHasStarted)
        {
            if (!audioSource.isPlaying)
            {
                ambientSource.UnMute();
                musicHasStarted = false;

                gameObject.SetActive(false);
                targetIndicator.SetActive(false);
            }
        }
        else if (Vector2.Distance(playerGroundCheck.position, topOfTower.position) < targetRadius)
        {
            towerCube1.GetComponent<TowerCube>().ChangeMaterial();
            towerCube2.GetComponent<TowerCube>().ChangeMaterial();
            audioSource.clip = towerAchieved;
            ambientSource.Mute();
            audioSource.Play();
            musicHasStarted = true;
            player.IncreaseSprintModifier();
        }
    }
}
