using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject WinUI;
    public TextMeshProUGUI LevelText;

    public GameObject env;



    public void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false; // stops the player from using the exit twice
/*
        FindObjectOfType<XROrigin>().enabled = false; */

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        env.SetActive(false);
        WinUI.SetActive(true);
    }
}
