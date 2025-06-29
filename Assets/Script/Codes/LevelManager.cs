using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        if (PlayerPrefs.GetInt("LevelUnlocked", 1) >=level)
        {
            SceneManager.LoadScene("Level" + level);
        }
    }
}
