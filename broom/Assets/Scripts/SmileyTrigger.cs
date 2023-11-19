using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyTrigger : MonoBehaviour
{
    public Animation smileyAnimation;

    public AudioSource smileyAudio;

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
        smileyAnimation.Play();

        if (smileyAudio != null)
        {
            smileyAudio.Play();
        }

        // Disable the trigger so it can't be triggered again (no infinite loop)
        this.gameObject.SetActive(false);
    }
}