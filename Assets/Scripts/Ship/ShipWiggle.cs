using UnityEngine;

public class ShipWiggle : MonoBehaviour
{
    [SerializeField] private float wiggleAmount = 0.2f;
    [SerializeField] private float wiggleSpeed = 2f;

    private Vector3 _originalLocalPosition;
    private float _time;

    private void Awake()
    {
        _originalLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        _time += Time.deltaTime * wiggleSpeed;
        
        float offsetX = Mathf.Sin(_time) * wiggleAmount;
        float offsetY = Mathf.Cos(_time) * wiggleAmount * 0.5f;

        transform.localPosition = _originalLocalPosition + new Vector3(offsetX, offsetY, 0f);
        
        float rotationAngle = Mathf.Sin(_time) * wiggleAmount * 10f;
        transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
