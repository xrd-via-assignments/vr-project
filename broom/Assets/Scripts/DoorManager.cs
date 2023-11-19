using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animation Door;
    public AudioSource DoorOpenSound;

    void Update()
    {
        if (PlayerCasting.DistanceFromTarget < 4)
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                GetComponent<BoxCollider>().enabled = false;
                Door.Play();
                DoorOpenSound.Play();
            }
        }
    }
}
