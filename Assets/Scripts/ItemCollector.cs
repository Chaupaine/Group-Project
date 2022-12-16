using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    //public ParticleSystem collectParticle;
    public static ItemCollector access;
    public int coins;
    public ParticleSystem collectParticle;
    public AudioClip collectSound;
    private AudioSource playerAudio;
    [SerializeField] TextMeshProUGUI coinsText;

    void Start()
    {
        coins = GameControl.control.previousScore;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        coinsText.text = "Mints: " + coins;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("leaf"))
        {
            playerAudio.PlayOneShot(collectSound, 1.0f);
            collectParticle.Play();
            Destroy(other.gameObject);
            coins++;

        }

        if (other.gameObject.CompareTag("cookie"))
        {
            playerAudio.PlayOneShot(collectSound, 1.0f);
            collectParticle.Play();
            Destroy(other.gameObject);
            coins += 3;

        }


    }

}
