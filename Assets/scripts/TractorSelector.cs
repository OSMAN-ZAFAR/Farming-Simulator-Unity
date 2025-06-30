using UnityEngine;
using UnityEngine.UI;

public class TractorSelection : MonoBehaviour
{
    public GameObject[] tractors;
    public GameObject[] specPanels;
    private int currentIndex = 0;

    public void Start()
    {
        ShowTractor(currentIndex);
    }

    public void ShowTractor(int index)
    {
        // Hide all tractors and panels
        for (int i = 0; i < tractors.Length; i++)
        {
            tractors[i].SetActive(false);
            specPanels[i].SetActive(false);
        }

        // Show selected tractor and panel
        tractors[index].SetActive(true);
        specPanels[index].SetActive(true);

        // it is responsible for the playing animation 
        Animator anim = tractors[index].GetComponent<Animator>();
        if (anim != null)
        {
            anim.Play("AnimationName", -1, 0f); 
        }
    }

    public void OnRightClick()
    {
        currentIndex++;
        if (currentIndex >= tractors.Length)
            currentIndex = 0; // loop to first

        ShowTractor(currentIndex);
    }

    public void OnLeftClick()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = tractors.Length - 1; // loop to last

        ShowTractor(currentIndex);
    }
}
       
    
