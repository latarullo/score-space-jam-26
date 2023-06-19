using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    [SerializeField] private Transform settingsButton;

    // Start is called before the first frame update
    void Start() {
        settingsButton.GetComponent<Button>().onClick.AddListener(ShowCharacterSelectUI);
    }

    private void ShowCharacterSelectUI() {
        CharacterSelectUI.Instance.Show();
    }

    private void OnDestroy() {
        settingsButton.GetComponent<Button>().onClick.RemoveListener(ShowCharacterSelectUI);
    }
}
