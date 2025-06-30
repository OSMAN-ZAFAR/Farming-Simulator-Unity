using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public void OnPlayButton()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (nextPanel != null) nextPanel.SetActive(true);
    }

}
