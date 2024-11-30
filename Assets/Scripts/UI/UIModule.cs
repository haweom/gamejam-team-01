using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIModule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Module;
    private Module _module;

    public GameObject HoverText;
    private TextMeshPro _text;

    private bool _mouseOver = false;

    void Awake()
    {
        _text = HoverText.GetComponent<TextMeshPro>();
        _module = HoverText.GetComponent<Module>();
    }

    void Update()
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
}
