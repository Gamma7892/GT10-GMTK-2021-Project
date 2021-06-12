using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode switchChar = KeyCode.E;

    [Header("Controllers")]
    public GameObject roundyObj;
    public GameObject pointyObj;
    CharacterController2D Roundy;
    CharacterController2D Pointy;
    public CameraFollow Camera;

    public enum ActiveChar { roundy, pointy }
    public ActiveChar currentCharacter = ActiveChar.roundy;

    void Awake()
    {
        Roundy = roundyObj.GetComponent<CharacterController2D>();
        Pointy = pointyObj.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchChar))
        {
            switch (currentCharacter)
            {
                case ActiveChar.roundy:
                    Roundy.enabled = false;
                    Pointy.enabled = true;
                    Camera.followedPlayer = pointyObj.transform;
                    currentCharacter = ActiveChar.pointy;
                    break;
                case ActiveChar.pointy:
                    Pointy.enabled = false;
                    Roundy.enabled = true;
                    Camera.followedPlayer = roundyObj.transform;
                    currentCharacter = ActiveChar.roundy;
                    break;
            }
        }
    }
}
