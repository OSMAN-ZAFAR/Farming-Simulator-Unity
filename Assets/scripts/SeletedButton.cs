using UnityEngine;

public class SelectedButton : MonoBehaviour
{
    public GameObject selected1;
    public GameObject selected2;
    public GameObject selected3;
    public GameObject selected4;
    public GameObject selectedPanel;

    public void OnSelectButton()
    {
       
        if (selectedPanel != null) selectedPanel.SetActive(true);
        if (selected1 != null) selected1.SetActive(false);
        if(selected2 != null) selected2.SetActive(false);
        if( selected3  != null) selected3.SetActive(false);
        if(selected4 != null) selected4.SetActive(false);
    }
}