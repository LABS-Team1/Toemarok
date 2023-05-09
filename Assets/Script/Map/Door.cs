using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType
    {
        TOP = 0,
        LEFT,
        BOTTOM,
        RIGHT
    }

    public DoorType doorType;
}
