using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] interactionPrefabs;
    // Start is called before the first frame update
    public void spawnInteractions(List<Letter> letterList) {
        int letterListIndex = 0;
        for (int i = 0; i < spawnPoints.Length; i++) {
            int randomInteractionIndex = Random.Range(0, interactionPrefabs.Length);
            GameObject interactionPrefab = interactionPrefabs[randomInteractionIndex];
            int numberOfChildren = interactionPrefab.transform.childCount;
            for (int j = 0; j < numberOfChildren; j++) {
                GameObject child = interactionPrefab.transform.GetChild(j).gameObject;
                if (child.tag == "Letter") {
                    TMP_Text letterText = child.GetComponentInChildren<TMP_Text>();
                    if (letterText != null) {
                        letterText.SetText(letterList[letterListIndex].getText().ToString());
                        letterListIndex++;
                        // TODO: Add value
                    }
                }
            }
            Instantiate(interactionPrefab, spawnPoints[i]);
        }
    }
}
