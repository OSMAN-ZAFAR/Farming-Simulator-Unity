using UnityEngine;

public class BackButon : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject previousPanel;

    public void OnBackButton()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (previousPanel != null) previousPanel.SetActive(true);
    }
}

