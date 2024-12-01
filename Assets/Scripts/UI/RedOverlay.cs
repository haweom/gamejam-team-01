using UnityEngine;
using UnityEngine.UI;

public class RedOverlay : MonoBehaviour
{
    Image _image;

    public void Flash()
    {
        var color = _image.color;
        color.a = 0.1f;

        _image.color = color;
    }

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        var color = _image.color;
        color.a = Mathf.Lerp(_image.color.a, 0, 0.15f);

        _image.color = color;
    }
}
