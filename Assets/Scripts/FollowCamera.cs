using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    Vector3 offset;

    void Start()
    {
        offset = Player.transform.position - Camera.transform.position;
    }

    void Update()
    {
        Camera.transform.position = Player.transform.position - offset;
    }
}