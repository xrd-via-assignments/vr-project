// Coded by Developer Jake -- https://www.youtube.com/developerjake
// Follow the Backrooms Game Lab (Part 7) to understand what this is for

using UnityEngine;

public class KeyDoor : MonoBehaviour // This script should be on the Locked Door Trigger
{
    [Header("Attributes")]

    [Tooltip("The name of the key that is required.")] public string keyName = "";

    [Header("References")]


    public Animation Door;

    public AudioSource DoorOpenSound;

    private KeyManager km;

    private bool hasDoorBeenOpened = false;

    private void Start()
    {
        km = FindObjectOfType<KeyManager>(); // Assign
    }

    private void Update()
    {

        if ( PlayerCasting.DistanceFromTarget <= 4 )
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                if (!hasDoorBeenOpened && !Door.isPlaying)
                {

                    foreach (string key in km.keysInInventory) // Check to see if the player has key
                    {
                        if (key.Trim().ToLower() == keyName.Trim().ToLower())
                        {
                            GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                            Door.Play(); // Play the door open animation

                            DoorOpenSound.Play(); // Play the door open sound

                            km.keysInInventory.Remove(key); // Removes the key from the inventory

                            hasDoorBeenOpened = true; // Set the flag to indicate that the door has been opened
                        }
                    }
                }
            }
        }
    }
}
