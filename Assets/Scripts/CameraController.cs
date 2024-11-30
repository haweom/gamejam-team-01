using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public class ShakeData
    {
        public float strength;
        public float diminish;
    }

    public float CameraLerp = 0.02f;

    private Transform player;

    private List<ShakeData> shakes = new();
    public void Shake(float strength, float diminish)
    {
        shakes.Add(new ShakeData { strength = strength, diminish = diminish });
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, player.position.x, CameraLerp),
            Mathf.Lerp(transform.position.y, player.position.y, CameraLerp),
            transform.position.z
        );

        shakes.RemoveAll(shake =>
        {
            var rotation = Random.Range(0, 2 * Mathf.PI);

            transform.position += shake.strength * new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0);
            shake.strength *= shake.diminish;

            return shake.strength < 0.001f;
        });
    }
}
