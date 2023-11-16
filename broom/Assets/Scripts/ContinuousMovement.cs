using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour
{
    public XRNode inputSourceLeft;
    public XRNode inputSourceRight;

    public AudioClip[] footstepSounds;
    public float soundVolume = 3.0f;
    private AudioSource audioSource;

    public float speed;
    public float normalSpeed = 1;
    public float sprintSpeed = 3;

    public float rotationSpeed = 45f;

    private XROrigin rig;
    private Vector2 inputAxisLeft;
    private Vector2 inputAxisRight;
    private CharacterController character;

    // Sprint button configuration
    // public Button sprintButton = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.volume = soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice deviceLeft = InputDevices.GetDeviceAtXRNode(inputSourceLeft);
        InputDevice deviceRight = InputDevices.GetDeviceAtXRNode(inputSourceRight);

        deviceLeft.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisLeft);
        deviceRight.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisRight);

        // Check for sprint trigger input
        if (deviceLeft.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.5f)
        {
            speed = sprintSpeed;
            PlayWalkingFootstepSound();
        }
        else
        {
            speed = normalSpeed;
        }
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);

        // Swap inputAxisLeft and inputAxisRight for forward/backward and left/right mapping
        Vector3 directionRight = headYaw * new Vector3(inputAxisRight.x, 0, inputAxisRight.y);
        Vector3 directionLeft = headYaw * new Vector3(inputAxisLeft.x, 0, inputAxisLeft.y);

        character.Move((directionLeft) * Time.fixedDeltaTime * speed);

        // Rotation
        float rotationAmount = inputAxisRight.x * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void PlayWalkingFootstepSound()
    {
        if (footstepSounds.Length > 0 && !audioSource.isPlaying)
        {
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepSound, soundVolume);
        }
    }
}