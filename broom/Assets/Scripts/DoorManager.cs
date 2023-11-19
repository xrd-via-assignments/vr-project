using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animation Door;
    public AudioSource DoorOpenSound;

    private bool hasDoorBeenOpened = false;

    void Update()
    {
        if (PlayerCasting.DistanceFromTarget < 4)
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                if (!hasDoorBeenOpened && !Door.isPlaying)
                {
                    GetComponent<BoxCollider>().enabled = false;
                    Door.Play();
                    DoorOpenSound.Play();
                    hasDoorBeenOpened = true; // Set the flag to indicate that the door has been opened
                }
            }
        }
    }
}
