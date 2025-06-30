using UnityEngine;

public class FieldTriggerHandler : MonoBehaviour
{
    public GameObject dustEffect;
    public GameObject greenParticles;
    public Animator cutterAnimator;   

    private ParticleSystem dustPS;
    private bool isInField = false;

    void Start()
    {
        if (greenParticles != null)
            greenParticles.SetActive(false);

        if (dustEffect != null)
            dustPS = dustEffect.GetComponent<ParticleSystem>();

        if (cutterAnimator != null)
            cutterAnimator.Play("CloseCovers"); 
    }

    public void OnCutterAttached()
    {
        if (greenParticles != null)
            greenParticles.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInField || !other.GetComponent<RCC_CarControllerV3>())
            return;

        Debug.Log("Tractor entered field");

        if (dustPS != null && !dustPS.isPlaying)
            dustPS.Play();

        if (greenParticles != null)
            greenParticles.SetActive(false);

        // Play unfolded animation
        if (cutterAnimator != null)
            cutterAnimator.Play("OpenCovers");

        isInField = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isInField || !other.GetComponent<RCC_CarControllerV3>())
            return;

        Debug.Log("Tractor exited field");

        if (dustPS != null && dustPS.isPlaying)
            dustPS.Stop();

        //  Play folding animation
        if (cutterAnimator != null)
            cutterAnimator.Play("CloseCovers");

        isInField = false;
    }
}

