using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI AltitudeText; 
    public TextMeshProUGUI SpeedText; 
    public Transform Ship; 

    private Rigidbody2D shipRigidbody;

    void Start()
    {
        if (Ship != null)
        {
            shipRigidbody = Ship.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (Ship != null)
        {
            float altitude = Ship.position.y;
            float speed = shipRigidbody != null ? shipRigidbody.velocity.magnitude : 0;

            // Update the HUD text
            AltitudeText.text = $"ALTIDUDE: {altitude:F1} m";
            SpeedText.text = $"SPEED: {speed:F1} m/s";
        }
    }
}