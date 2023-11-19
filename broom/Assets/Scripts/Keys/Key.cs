// Coded by Developer Jake -- https://www.youtube.com/developerjake
// Follow the Backrooms Game Lab (Part 7) to understand what this is for

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Tooltip("The name of the key. This corresponds with the key on the door")] public string keyName;

    [Header("(Optional)")]
    [Tooltip("(Optional.)")] public AudioClip CollectAudio;

    public void Update()
    {
        if (PlayerCasting.DistanceFromTarget <= 2) // Is the player in range?
        {

            if (Input.GetKey(KeyCode.JoystickButton0))
            {  // These events happen when the player is looking at the key, and is in range, and presses E.

                if (CollectAudio != null) FindObjectOfType<KeyManager>().GetComponent<AudioSource>().PlayOneShot(CollectAudio); // (Optional.)

                FindObjectOfType<KeyManager>().keysInInventory.Add(keyName);

                Destroy(this.gameObject);
            }
        }
    }
}
