using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public Animation jumpscareAnimation;

    public AudioSource jumpscareAudio;

    // This is called when the player enters the trigger
    public void OnMouseOver() {

        // Play the animation
        jumpscareAnimation.Play();

        // If jumpscareAudio exists, play it
        if (jumpscareAudio != null) {
            jumpscareAudio.Play();
        }

        // Disable the trigger so it can't be triggered again (no infinite loop)
        this.gameObject.SetActive(false);
    }
}
