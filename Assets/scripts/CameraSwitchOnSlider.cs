using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSwitchOnSlider : MonoBehaviour
{
    public Slider progressSlider;

    public Camera camera1;
    public GameObject camera2Object;
    public Animator camera2Animator;
    public string camera2AnimationName = "CameraZoomIn";
    public AudioSource tractorAudio; // 🎧 Tractor engine sound

    public Rigidbody tractorRb;
    public ParticleSystem celebrationFx;
    public AudioSource celebrationSound;  // 🎵 Sound with particles

    public GameObject levelCompletePanel;

    private bool triggered = false;

    void Start()
    {
        if (celebrationFx != null && celebrationFx.isPlaying)
            celebrationFx.Stop();

        if (camera2Object != null)
            camera2Object.SetActive(false);

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);

        if (celebrationSound != null)
            celebrationSound.Stop();
    }

    void Update()
    {
        if (!triggered && progressSlider.value >= 1f)
        {
            triggered = true;

            camera1.enabled = false;
            if (camera2Object != null)
                camera2Object.SetActive(true);

            if (camera2Animator != null)
                camera2Animator.Play(camera2AnimationName, -1, 0f);

            if (tractorRb != null)
                tractorRb.isKinematic = true;

            if (celebrationFx != null)
                celebrationFx.Play();

            if (celebrationSound != null)
                celebrationSound.Play();

            // 🚜 Stop tractor sound
            if (tractorAudio != null && tractorAudio.isPlaying)
                tractorAudio.Stop();

            StartCoroutine(ShowLevelCompletePanelAfterDelay(5f));
        }
        IEnumerator ShowLevelCompletePanelAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);
        }

    }
}

