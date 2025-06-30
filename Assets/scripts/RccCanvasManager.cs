using UnityEngine;
using UnityEngine.UI;

public class RccCanvasManager : MonoBehaviour
{
    public Slider grassSlider;          // Assign your grass-cut slider
    public GameObject rccCanvas;        // RCC canvas to control
    private bool done = false;

    void Update()
    {
        if (!done && grassSlider.value >= 1f)
        {
            done = true;
            if (rccCanvas != null)
                rccCanvas.SetActive(false);  // ✅ RCC canvas off when slider full
        }
    }
}
