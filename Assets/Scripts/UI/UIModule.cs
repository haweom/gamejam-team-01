using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIModule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Module;
    private Module _module;

    public GameObject HoverText;
    private TextMeshPro _text;

    void Awake()
    {
        _text = HoverText.GetComponent<TextMeshPro>();
        _module = HoverText.GetComponent<Module>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("feafaef");
        _text.text = $"{100 * (float)_module.Health / _module.MaxHealth}%";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.text = string.Empty;
    }
}
