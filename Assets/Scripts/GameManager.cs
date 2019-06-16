using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string letters = "";
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void addLetter(string letter) {
        letters += letter;
        FindObjectOfType<Score>().scoreText.text += letter; // Only 1 object can exist
    }

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
