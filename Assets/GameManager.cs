using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMoivement movement;
    public float levelRestart = 2f;

    public void EndGame()
    {
        movement.enabled = false;

        Invoke("RestartLevel", levelRestart);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
