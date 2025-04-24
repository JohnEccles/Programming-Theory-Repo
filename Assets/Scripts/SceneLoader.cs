using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string level;

    public void LoadLevel() 
    {
        SceneManager.LoadScene(level);
    }

    private void OnLoad()
    {
        Debug.Log("Load Level: " + level);  
    }




}
