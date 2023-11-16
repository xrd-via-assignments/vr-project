// Coded by Developer Jake -- https://www.youtube.com/developerjake
// Follow the Backrooms Game Lab (Part 6) to understand what this is for
using UnityEngine;
using UnityEngine.XR;

public class DoorManager : MonoBehaviour // This script should be on the Door Trigger
{
    public GameObject CursorHover; // The hover cursor that should show when the player is looking at the door

    public Animation Door;

    public AudioSource DoorOpenSound;

    private Vector2 inputAxisLeft;
    private Vector2 inputAxisRight;

    public XRNode inputSourceLeft;
    public XRNode inputSourceRight;

    private void OnMouseOver() // Activates when the player looks away from the door
    {

        if (PlayerCasting.DistanceFromTarget < 4) // If the player IS close enough to the door..
        {

            //CursorHover.SetActive(true);

        InputDevice deviceLeft = InputDevices.GetDeviceAtXRNode(inputSourceLeft);
        InputDevice deviceRight = InputDevices.GetDeviceAtXRNode(inputSourceRight);
        deviceLeft.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisLeft);
        deviceRight.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisRight);

            if (deviceRight.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.5f) // If the player presses E..
            {

                GetComponent<BoxCollider>().enabled = false; // Turns off the player's ability to open the door again even though it's already open

                Door.Play(); // Play the door open animation

                DoorOpenSound.Play(); // Play the door open sound

            }

        }

        /*         else // If the player is NOT close enough to the door
                {

                    CursorHover.SetActive(false);

                } */
    }



    private void OnMouseExit() // Activates when the player looks away from the door
    {

        CursorHover.SetActive(false);

    }
}
