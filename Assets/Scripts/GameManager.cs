using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject endBtn;
    public void StartGame()
    {
        PlayerControler.Instance.SetSpeed(8);
        startBtn.SetActive(false);
    }

    public void EndGame()
    {
        PlayerControler.Instance.SetSpeed(0);
        PlayerControler.Instance.End();
        endBtn.SetActive(true);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }
}
