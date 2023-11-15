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
    public float speed = 1;

    private XROrigin rig;
    private Vector2 inputAxisLeft;
    private Vector2 inputAxisRight;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice deviceLeft = InputDevices.GetDeviceAtXRNode(inputSourceLeft);
        InputDevice deviceRight = InputDevices.GetDeviceAtXRNode(inputSourceRight);

        deviceLeft.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisLeft);
        deviceRight.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxisRight);
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);

        Vector3 directionLeft = headYaw * new Vector3(inputAxisLeft.x, 0, inputAxisLeft.y);
        Vector3 directionRight = headYaw * new Vector3(inputAxisRight.x, 0, inputAxisRight.y);

        character.Move((directionLeft + directionRight) * Time.fixedDeltaTime * speed);
    }
}
