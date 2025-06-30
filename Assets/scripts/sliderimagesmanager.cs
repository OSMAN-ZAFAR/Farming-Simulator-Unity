using UnityEngine;
using UnityEngine.UI;

public class sliderimagesmanager: MonoBehaviour
{
    public Slider mySlider;
    public float fillSpeed = 20f; // Adjust speed of fill
    private float targetValue = 1f; // Target (can be 0–1)

    void Update()
    {
        if (mySlider.value < targetValue)
        {
            mySlider.value += fillSpeed * Time.deltaTime;
        }
    }
}
