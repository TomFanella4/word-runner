using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string letters = "";
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public int numberOfWords = 3;
    public int letterListLength = 25;
    public GameObject completeLevelUI;
    public Transform playerTransform;
    public TextAsset wordsShort;
    public TextAsset wordsMedium;
    public TextAsset wordsLong;
    private List<char> probabilityDist;
    private List<Letter> letterList;
    private Dictionary<char, Letter> letterDict;

    public void generateLetters() {
        letterDict = new Dictionary<char, Letter>();
        letterDict.Add('A', new Letter('A', 9, 1));
        letterDict.Add('B', new Letter('B', 2, 3));
        letterDict.Add('C', new Letter('C', 2, 3));
        letterDict.Add('D', new Letter('D', 4, 2));
        letterDict.Add('E', new Letter('E', 12, 1));
        letterDict.Add('F', new Letter('F', 2, 4));
        letterDict.Add('G', new Letter('G', 3, 2));
        letterDict.Add('H', new Letter('H', 2, 4));
        letterDict.Add('I', new Letter('I', 9, 1));
        letterDict.Add('J', new Letter('J', 1, 8));
        letterDict.Add('K', new Letter('K', 1, 5));
        letterDict.Add('L', new Letter('L', 4, 1));
        letterDict.Add('M', new Letter('M', 2, 3));
        letterDict.Add('N', new Letter('N', 6, 1));
        letterDict.Add('O', new Letter('O', 8, 1));
        letterDict.Add('P', new Letter('P', 2, 3));
        letterDict.Add('Q', new Letter('Q', 1, 10));
        letterDict.Add('R', new Letter('R', 6, 1));
        letterDict.Add('S', new Letter('S', 4, 1));
        letterDict.Add('T', new Letter('T', 6, 1));
        letterDict.Add('U', new Letter('U', 4, 1));
        letterDict.Add('V', new Letter('V', 2, 4));
        letterDict.Add('W', new Letter('W', 2, 4));
        letterDict.Add('X', new Letter('X', 1, 8));
        letterDict.Add('Y', new Letter('Y', 2, 4));
        letterDict.Add('Z', new Letter('Z', 1, 10));
    }

    private void createProbabilityDist() {
        probabilityDist = new List<char>();
        foreach(KeyValuePair<char, Letter> entry in letterDict) {
            Letter currentLetter = entry.Value;
            for (int i = 0; i < currentLetter.getOccurrenceCount(); i++) {
                probabilityDist.Add(currentLetter.getText());
            }
        }
    }

    private void createLetterList() {
        string[] wordList = wordsMedium.text.Split('\n');
        HashSet<Letter> fixedLetters = new HashSet<Letter>();
        for (int i = 0; i < numberOfWords; i++) {
            int randomWordIndex = Random.Range(0, wordList.Length);
            char[] currentWord = wordList[randomWordIndex].ToCharArray();
            for (int j = 0; j < currentWord.Length; j++) {
                if (!char.IsWhiteSpace(currentWord[j])) {
                    fixedLetters.Add(letterDict[char.ToUpper(currentWord[j])]);
                }
            }
        }
        letterList = new List<Letter>(fixedLetters);
        while (letterList.Count < letterListLength) {
            char randomLetter = probabilityDist[Random.Range(0, probabilityDist.Count)];
            probabilityDist.Remove(randomLetter);
            letterList.Add(letterDict[randomLetter]);
        }
    }

    private void addLettersToUI() {
        Letters letters = FindObjectOfType<Letters>();
        for (int i = 0; i < letterListLength; i++) {
            letters.lettersText.text += letterList[i].getText();
        }
    }

    void Start() {
        generateLetters();
        createProbabilityDist();
        createLetterList();
        addLettersToUI();
        FindObjectOfType<InteractionSpawner>().spawnInteractions(letterList);
    }

    public void addLetter(string letter) {
        letters += letter;
        FindObjectOfType<Score>().scoreText.text += letter; // Only 1 object can exist
    }

    public void CompleteLevel() {
        // completeLevelUI.SetActive(true);
        playerTransform.position = new Vector3(playerTransform.position.x,1f,0f);
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
