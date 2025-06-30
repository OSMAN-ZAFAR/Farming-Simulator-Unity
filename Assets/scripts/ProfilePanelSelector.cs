using UnityEngine;
using UnityEngine.UI;

public class ProfilePanelSelector : MonoBehaviour
{
    public GameObject[] selectedImages;     // Profiles (Selected)
    public GameObject[] unselectedImages;   // Profiles (Unselected)

    public Image previewDisplayImage1;      // 🖼️ First preview panel
    public Image previewDisplayImage2;      // 🖼️ Second preview panel
    public Sprite[] previewSprites;         // Sprites for preview (order matched)

    private int currentSelected = -1;

    public void SelectProfile(int index)
    {
        // Deselect all
        for (int i = 0; i < selectedImages.Length; i++)
        {
            selectedImages[i].SetActive(false);
            unselectedImages[i].SetActive(true);
        }

        // Select clicked one
        selectedImages[index].SetActive(true);
        unselectedImages[index].SetActive(true);
        currentSelected = index;

        // Update both preview displays
        if (index < previewSprites.Length)
        {
            if (previewDisplayImage1 != null)
                previewDisplayImage1.sprite = previewSprites[index];

            if (previewDisplayImage2 != null)
                previewDisplayImage2.sprite = previewSprites[index];
        }

        // Save selection
        PlayerPrefs.SetInt("SelectedProfilePanel", index);
    }

    void Start()
    {
        int saved = PlayerPrefs.GetInt("SelectedProfilePanel", -1);
        if (saved >= 0 && saved < selectedImages.Length)
        {
            SelectProfile(saved);
        }
    }
}
