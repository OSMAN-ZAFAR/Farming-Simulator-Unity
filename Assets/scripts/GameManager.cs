using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("LevelManager")]
    [SerializeField] private GameObject[] levels;
    [SerializeField] private Text text;
    [Header("Slider Progress")]
    public Slider progressSlider;
    float totalGrassAmount = 180f;
    private float currentGrassCut = 0f;
    bool isSteering=false;
    public AudioSource horn;
    [Header("Instruction UI")]
    [SerializeField] private GameObject instructionPanel;
    [SerializeField] private TMP_Text instructionText;

    [SerializeField] private string[] levelInstructions;
    private void Start()
    {
        levels[MenuManager.LevelNo].SetActive(true);

        // Show level number
        text.text = "Level " + (MenuManager.LevelNo + 1);

        // Show instruction text
        if (MenuManager.LevelNo < levelInstructions.Length)
        {
            instructionText.text = levelInstructions[MenuManager.LevelNo];
            instructionPanel.SetActive(true);  // show panel
        }
        else
        {
            instructionPanel.SetActive(false); // no instructions
        }
    }


    public void NextLevel()
    {
        MenuManager.LevelNo++;
        SceneManager.LoadScene(1);
    }
    public void AddGrassCut(float amount)
    {
        currentGrassCut += amount;
        float progress = Mathf.Clamp01(currentGrassCut / totalGrassAmount);
        progressSlider.value = progress;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GoToHome()
    {
        SceneManager.LoadScene(0);
    }
    public void ControllChanges()
    {
        if (isSteering)
        {
            RCC.SetMobileController(RCC_Settings.MobileController.TouchScreen);
            print("working button");
        }
        else
        {
            RCC.SetMobileController(RCC_Settings.MobileController.SteeringWheel);
            print(" working sterring");
        }
        isSteering = !isSteering;

    }
    public void Horn()
    {
        if (!horn. isPlaying)
        {
            horn.Play();
        }

    }
    public void OkayInstruction()
    {
        instructionPanel.SetActive(false);
    }
}
