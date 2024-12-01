using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThunderStruck : MonoBehaviour
{
    [SerializeField] private Light2D thunderLight;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 5f;
    [SerializeField] private float minBlinkDuration = 0.05f;
    [SerializeField] private float maxBlinkDuration = 0.2f;
    [SerializeField] private float thunderInterval = 5f;

    private void Start()
    {
        StartCoroutine(ThunderCoroutine());
    }

    private IEnumerator ThunderCoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(thunderInterval * 0.5f, thunderInterval * 1.5f);
            yield return new WaitForSeconds(waitTime);
            
            int blinkCount = Random.Range(2, 5);
            for (int i = 0; i < blinkCount; i++)
            {
                thunderLight.intensity = Random.Range(maxIntensity * 0.8f, maxIntensity);
                yield return new WaitForSeconds(Random.Range(minBlinkDuration, maxBlinkDuration));
                
                thunderLight.intensity = minIntensity;
                yield return new WaitForSeconds(Random.Range(minBlinkDuration * 0.5f, maxBlinkDuration * 0.5f));
            }
            thunderLight.intensity = 0.25f;
        }
    }
}