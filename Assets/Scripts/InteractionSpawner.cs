using UnityEngine;
using TMPro;

public class InteractionSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] interactionPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++) {
            int randomInteractionIndex = Random.Range(0, interactionPrefabs.Length);
            GameObject interactionPrefab = interactionPrefabs[randomInteractionIndex];
            TMP_Text letterText = interactionPrefab.GetComponentInChildren<TMP_Text>();
            if (letterText != null) {
                char randomLetter = (char)(Random.Range(0, 26) + 65);
                letterText.SetText(randomLetter.ToString());
            }
            Instantiate(interactionPrefab, spawnPoints[i]);
        }
    }
}
