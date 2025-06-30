using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingPanelManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingSlider;
    public GameObject privacyPanel;
    public GameObject letterOpenPanel;
    public float loadDuration = 3f;
    public float unfoldSpeed = 2f;
    public AudioSource backgroundMusic;
    public GameObject ExitPanel;
  

    private bool popupStopped = false;
    void Start()
    {
        StartCoroutine(LoadingSequence());
    }
    IEnumerator LoadingSequence()
    {
        loadingPanel.SetActive(true);
        float timer = 0f;

        while (timer < loadDuration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / loadDuration);
            loadingSlider.value = progress;
            yield return null;
        }
        loadingPanel.SetActive(false);
        privacyPanel.SetActive(true);
        backgroundMusic.Play();
        yield return StartCoroutine(UnfoldPanelFromCenter());
    }
    IEnumerator UnfoldPanelFromCenter()
    {
        letterOpenPanel.SetActive(true);
        letterOpenPanel.transform.localScale = new Vector3(0f, 1f, 1f);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * unfoldSpeed;
            float scaleX = Mathf.Lerp(0f, 1f, t);
            letterOpenPanel.transform.localScale = new Vector3(scaleX, 1f, 1f);
            yield return null;
        }
    }
    IEnumerator ScaleTo(Transform target, Vector3 targetScale, float duration)
    {
        Vector3 startScale = target.localScale;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            target.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }
    } 
    public void OnPrivacyButton()
    {
        Application.OpenURL("https://sites.google.com/view/yourgameprivacypolicy");
    }
    public void OnExitButton()
    {
        if (ExitPanel != null) ExitPanel.SetActive(true);
    }
    public void OnNoButton()
    {
        ExitPanel.SetActive(false);
    }
    public void OnYesButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
   


}

