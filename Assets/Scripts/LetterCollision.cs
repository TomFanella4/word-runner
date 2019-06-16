using UnityEngine;
using TMPro;

public class LetterCollision : MonoBehaviour
{
    public TMP_Text letterText;

    void OnTriggerEnter() {
        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().addLetter(letterText.text); // Only 1 object can exist
    }
}
