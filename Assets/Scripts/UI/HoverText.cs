using UnityEngine;

public class HoverText : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
