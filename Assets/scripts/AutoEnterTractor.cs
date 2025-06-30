using UnityEngine;
using System.Collections;


public class AutoEnterTractor : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCamera;
    public GameObject tractor;
    public GameObject rccCamera;
    public GameObject rccCanvas;
    public ParticleSystem entryParticles;
    public GameObject dummyDriver;
    public GameObject directionalArrow;
    public GameObject joystickcanvas;

    private bool hasEntered = false;

    void Start()
    {
        
        if (player != null) player.SetActive(true);
        if (playerCamera != null) playerCamera.SetActive(true);
        if (directionalArrow != null)
            directionalArrow.SetActive(false); // direction Arrows off at start

        // Disable tractor functionalty at the start
        var car = tractor.GetComponent<RCC_CarControllerV3>();
        if (car != null) car.enabled = false;

        // To Turn off RCC camera and canvas
        if (rccCamera != null) rccCamera.SetActive(false);
        if (rccCanvas != null) rccCanvas.SetActive(false);
        if (dummyDriver != null) dummyDriver.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (hasEntered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone");
            if (directionalArrow != null)
                directionalArrow.SetActive(true); //for directional Arrows turn ON

            // To Turn off TPC
            if (player != null) player.SetActive(false);
            if (playerCamera != null) playerCamera.SetActive(false);
            // To Turn off joystick canvas 
            if(joystickcanvas != null) joystickcanvas.SetActive(false);

            // For Enable tractor's functions
            var car = tractor.GetComponent<RCC_CarControllerV3>();
            car.enabled = true;

            if (rccCamera != null)
            {
                rccCamera.SetActive(true);
                
            }

            if (rccCanvas != null)
                rccCanvas.SetActive(true);

            if (RCC_SceneManager.Instance != null)
            {
                Debug.Log("Player sitting in the tractor");
                RCC_SceneManager.Instance.RegisterPlayer(car);
            }
            

            if (entryParticles != null)
            {
                // For Hide the tractor entry particles
                var particleRenderer = entryParticles.GetComponent<Renderer>();
                if (particleRenderer != null)
                    particleRenderer.enabled = false;

                StartCoroutine(DisableParticlesAfterDelay());
            }

            IEnumerator DisableParticlesAfterDelay()
            {
                yield return new WaitForSeconds(0.2f);
                entryParticles.gameObject.SetActive(false);
            }
            if (dummyDriver != null) // For Driver activation
            {
                dummyDriver.SetActive(true);
                Debug.Log("driver activated.");
            }



            hasEntered = true;
            gameObject.SetActive(false);

        }
    }
    
}
