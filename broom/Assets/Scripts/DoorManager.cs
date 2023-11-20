using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animation door;
    public AudioSource doorOpenSound;

    private bool hasDoorBeenOpened = false;

    void Update()
    {
        PlayerCasting playerCasting = FindObjectOfType<PlayerCasting>();
        if (playerCasting != null && playerCasting.distanceFromTarget <= 5)
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                if (!hasDoorBeenOpened && !door.isPlaying)
                {
                    GetComponent<BoxCollider>().enabled = false;
                    door.Play();
                    doorOpenSound.Play();
                    hasDoorBeenOpened = true; // Set the flag to indicate that the door has been opened
                }
            }
        }
    }
}
