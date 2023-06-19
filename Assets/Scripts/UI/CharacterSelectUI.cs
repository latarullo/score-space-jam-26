using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour {

    public static CharacterSelectUI Instance { get; private set; }

    private int characterIndex = 0;
    private int characterCount = 10;
    private float initialPosition = -30f;
    private string[] characterNames = new string[] { "Amy", "Big Vegas", "Doozy", "Michelle", "Mousey", "Mremireh O Desbiens", "Ninja", "Sporty Granny", "The Boss", "Timmy" };

    [SerializeField] private TextMeshProUGUI lblCharacterName;
    [SerializeField] private Camera portraitCamera;
    [SerializeField] private Transform previousButton;
    [SerializeField] private Transform nextButton;
    [SerializeField] private Transform acceptButton;
    [SerializeField] private Transform cancelButton;

    void Start() {
        Instance = this;
        previousButton.GetComponent<Button>().onClick.AddListener(PreviousCharacter);
        nextButton.GetComponent<Button>().onClick.AddListener(NextCharacter);
        acceptButton.GetComponent<Button>().onClick.AddListener(Hide);
        cancelButton.GetComponent<Button>().onClick.AddListener(Hide);
        UpdateCamera();
        Hide();
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void Hide() {
        this.gameObject.SetActive(false);
    }

    private void NextCharacter() {
        characterIndex++;
        if (characterIndex >= characterCount) {
            characterIndex = 0;
        }
        UpdateCamera();
    }

    private void PreviousCharacter() {
        characterIndex--;
        if (characterIndex < 0) {
            characterIndex = characterCount - 1;
        }
        UpdateCamera();
    }

    private void UpdateCamera() {
        portraitCamera.transform.position = new Vector3(initialPosition - characterIndex * 3, portraitCamera.transform.position.y, portraitCamera.transform.position.z);
        lblCharacterName.text = characterNames[characterIndex];
    }

    private void OnDestroy() {
        previousButton.GetComponent<Button>().onClick.RemoveListener(PreviousCharacter);
        nextButton.GetComponent<Button>().onClick.RemoveListener(NextCharacter);
        acceptButton.GetComponent<Button>().onClick.RemoveListener(PreviousCharacter);
        cancelButton.GetComponent<Button>().onClick.RemoveListener(Hide);

    }
}