using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource buttonFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    // Start is called before the first frame update
    public void HoverSound()
    {
        buttonFx.PlayOneShot(hoverFx);
    }
    public void ClickSound()
    {
        buttonFx.PlayOneShot(clickFx);
    }
}