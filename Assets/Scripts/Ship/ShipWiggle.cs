using UnityEngine;

public class ShipWiggle : MonoBehaviour
{
    [SerializeField] private float wiggleAmount = 0.015f; // How much the ship wobbles
    [SerializeField] private float wiggleSpeed = 15f; // How fast the wobble occurs

    private Vector3 _originalLocalPosition;
    private float _time;

    private void Awake()
    {
        // Store the original local position of the ship
        _originalLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Increment time
        _time += Time.deltaTime * wiggleSpeed;

        // Calculate the local position offset using a sine wave
        float offsetX = Mathf.Sin(_time) * wiggleAmount;
        float offsetY = Mathf.Cos(_time) * wiggleAmount * 0.5f; // Optional asymmetry

        // Apply the local position offset
        transform.localPosition = _originalLocalPosition + new Vector3(offsetX, offsetY, 0f);

        // Optional: Add a small rotation wiggle
        float rotationAngle = Mathf.Sin(_time) * wiggleAmount * 10f; // Adjust multiplier for effect strength
        transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
