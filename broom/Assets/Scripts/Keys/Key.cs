using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Tooltip("The name of the key. This corresponds with the key on the door")]
    public string keyName;

    [Header("(Optional)")]
    [Tooltip("(Optional.)")]
    public AudioClip CollectAudio;

    PlayerCasting playerCasting;
    GameObject specificObject;

    public void Start()
    {
        playerCasting = FindObjectOfType<PlayerCasting>();
        specificObject = GameObject.Find("Blue key"); // Replace this with a reference to your specific object
    }

    public void Update()
    {
        PlayerCasting playerCasting = FindObjectOfType<PlayerCasting>();

        if (playerCasting != null &&
            playerCasting.distanceFromTarget <= 5 &&
            IsLookingAtSpecificObject(playerCasting, specificObject)) // Is the player in range?
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                // These events happen when the player is looking at the key, and is in range, and presses E.
                InteractWithKey();
            }
        }
    }

    void InteractWithKey()
    {
        if (CollectAudio != null)
        {
            FindObjectOfType<KeyManager>().GetComponent<AudioSource>().PlayOneShot(CollectAudio); // (Optional.)
        }

        FindObjectOfType<KeyManager>().keysInInventory.Add(keyName);
        Destroy(this.gameObject);
    }

    bool IsLookingAtSpecificObject(PlayerCasting playerCasting, GameObject specificObject)
{
    RaycastHit hit;
    if (Physics.Raycast(playerCasting.transform.position, playerCasting.transform.TransformDirection(Vector3.forward), out hit))
    {
        // Check if the hit object is the specificObject
        return hit.collider.gameObject == specificObject;
    }

    return false;
}
}
