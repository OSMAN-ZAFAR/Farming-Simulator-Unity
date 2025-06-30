using UnityEngine;

public class ContinuousPopup : MonoBehaviour
{
    public float popupSpeed = 0.6f; 
    public float scaleMultiplier = 1.2f; 

    private Vector3 originalScale;
    private bool keepPopping = true;

    void OnEnable()
    {
        originalScale = transform.localScale;
        keepPopping = true;
        StartCoroutine(PopupLoop());
    }

    System.Collections.IEnumerator PopupLoop()
    {
        while (keepPopping)
        {
            // Zoom In
            float timer = 0f;
            while (timer < popupSpeed / 2f)
            {
                timer += Time.deltaTime;
                float t = timer / (popupSpeed / 2f);
                transform.localScale = Vector3.Lerp(originalScale, originalScale * scaleMultiplier, t);
                yield return null;
            }

            // Zoom Out
            timer = 0f;
            while (timer < popupSpeed / 2f)
            {
                timer += Time.deltaTime;
                float t = timer / (popupSpeed / 2f);
                transform.localScale = Vector3.Lerp(originalScale * scaleMultiplier, originalScale, t);
                yield return null;
            }
        }
    }

    //// Call this method when you want to stop the popup (e.g. on click)
    //public void StopPopup()
    //{
    //    keepPopping = false;
    //    transform.localScale = originalScale;
    //}
}

