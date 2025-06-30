using UnityEngine;


public class GrassCutter : MonoBehaviour
{
    public GameManager gameManager; // set in inspector

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            Debug.Log("Grass Cut");
            other.gameObject.SetActive(false); // It Hide grass
                                               // then:
            gameManager.AddGrassCut(1);
        }
    }
}
