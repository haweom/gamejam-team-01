using UnityEngine;
using UnityEngine.UI;

public class UIModule : MonoBehaviour
{
    public GameObject Module;
    private Module _module;

    private Image _image;

    void Awake()
    {
        _module = Module.GetComponent<Module>();
        _image = GetComponent<Image>();
    }

    void Update()
    {
        var ratio = (float)_module.Health / _module.MaxHealth;
        _image.color = Color.Lerp(Color.green, Color.red, 1 - ratio);
    }

    /*    void Update()
        {
            if (_mouseOver) _text.text = $"{100 * (float)_module.Health / _module.MaxHealth}%";
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _mouseOver = false;
            _text.text = string.Empty;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("ehah");
            _mouseOver = true;
        }
    */
}
