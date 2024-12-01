using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UIModule : MonoBehaviour
{
    public GameObject Module;
    private IModule _module;

    private Image _image;

    void Awake()
    {
        _module = Module.GetComponent<IModule>();
        _image = GetComponent<Image>();
    }

    void Update()
    {
        var ratio = _module.GetHealthPercent();
        _image.color = Color.Lerp(Color.green, Color.red, 1 - ratio);
    }
}
