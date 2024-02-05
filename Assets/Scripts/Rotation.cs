using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 0, 0);
    }
}