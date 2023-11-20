using UnityEngine;

public class KeyDoor : MonoBehaviour // This script should be on the Locked Door Trigger
{
    [Header("Attributes")]
    [Tooltip("The name of the key that is required.")]
    public string keyName = "";

    [Header("References")]
    public Animation door;
    public AudioSource doorOpenSound;

    private KeyManager km;
    private bool hasDoorBeenOpened = false;

    PlayerCasting playerCasting;
    GameObject specificObject;

    private void Start()
    {
        km = FindObjectOfType<KeyManager>(); // Assign

        playerCasting = FindObjectOfType<PlayerCasting>();
        specificObject = GameObject.Find("doorTriggerLocked"); // Replace this with a reference to your specific object
    }

    private void Update()
    {
        PlayerCasting playerCasting = FindObjectOfType<PlayerCasting>();
        if (playerCasting != null &&
            playerCasting.distanceFromTarget <= 5 &&
            IsLookingAtSpecificObject(playerCasting, specificObject))
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                if (!hasDoorBeenOpened && !door.isPlaying)
                {
                    foreach (string key in km.keysInInventory) // Check to see if the player has key
                    {
                        if (key.Trim().ToLower() == keyName.Trim().ToLower())
                        {
                            GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                            door.Play(); // Play the door open animation

                            doorOpenSound.Play(); // Play the door open sound

                            km.keysInInventory.Remove(key); // Removes the key from the inventory

                            hasDoorBeenOpened = true; // Set the flag to indicate that the door has been opened
                        }
                    }
                }
            }
        }
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
