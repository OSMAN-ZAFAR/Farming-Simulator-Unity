using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int LevelNo;
   public void OpenLevel(int index)
    {
        LevelNo = index;
        SceneManager.LoadScene(1);
    }
    
}
