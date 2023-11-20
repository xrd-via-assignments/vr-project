using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public Animation jumpscareAnimation;

    public AudioSource jumpscareAudio;

    // If you're using 3D physics, you might need to use Physics.
    // Raycast to detect the mouse position. 
    // The OnMouseOver method is primarily used in 2D scenarios. 
    // If you're working in a 3D environment, you may need to use raycasting instead.
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            OnMouseOver();
        }
    }

    // This is called when the player enters the trigger
    public void OnMouseOver()
    {
        Debug.Log("Mouse is over GameObject.");

        // Play the animation
        if (jumpscareAnimation != null)
        {
            jumpscareAnimation.wrapMode = WrapMode.Once;
            jumpscareAnimation.Play();
        }

        // If jumpscareAudio exists, play it
        if (jumpscareAudio != null)
        {
            jumpscareAudio.Play();
        }

        // Disable the trigger so it can't be triggered again (no infinite loop)
        this.gameObject.SetActive(false);

        Debug.Log("MouseOver finished");
    }
}
