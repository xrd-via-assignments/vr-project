using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorManager : MonoBehaviour
{
    public Animation Door;
    public AudioSource DoorOpenSound;

    private InputAction buttonAction;
    private bool isButtonPressed = false;

    void Start()
    {
        // Set up the input action for the A button
        buttonAction = new InputAction(binding: "<XRController>/buttonSouth", type: InputActionType.Button);
        buttonAction.started += context => isButtonPressed = true;
        buttonAction.canceled += context => isButtonPressed = false;

        // Ensure that buttonAction is not null before enabling
        if (buttonAction != null)
            buttonAction.Enable();
    }

    void OnEnable()
    {
        // Ensure that buttonAction is not null before enabling
        if (buttonAction != null)
            buttonAction.Enable();
    }

    void OnDisable()
    {
        // Ensure that buttonAction is not null before disabling
        if (buttonAction != null)
            buttonAction.Disable();
    }

    void Update()
    {
        if (PlayerCasting.DistanceFromTarget < 4)
        {
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                Debug.Log("yaybal");
                GetComponent<BoxCollider>().enabled = false;
                Door.Play();
                DoorOpenSound.Play();
            }
        }
    }
}
