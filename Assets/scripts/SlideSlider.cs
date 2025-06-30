using UnityEngine;
using UnityEngine.UI;

public class SlideSlider : MonoBehaviour
{
    public Slider slider;           // Slider to slide
    public float slideDuration = 20f; // Time to fill (in seconds)

    private float timer = 0f;

    void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();  // Auto-detect if not set

        slider.value = 0f; // Start from 0
    }

    void Update()
    {
        if (slider.value < 1f)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / slideDuration);
            slider.value = progress;
        }
    }
}
