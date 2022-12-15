using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    string playerTag = "Player";
    float disappearTime = 3.0f;
    Animator animator;
    public AudioClip touchSound;

    bool canReset = true;
    float resetTime = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("DisappearTime", 1/disappearTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            AudioSource.PlayClipAtPoint(touchSound, transform.position);
            animator.SetBool("Trigger", true);
        }
    }

    public void TriggerReset()
    {
        if (canReset)
        {
            StartCoroutine(Reset());
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(resetTime);
        animator.SetBool("Trigger", false);
    }
}