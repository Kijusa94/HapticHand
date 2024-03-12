using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanelIU : MonoBehaviour
{
    [SerializeField] private Button menuButton;

    void Awake()
    {
        menuButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ToggleCategoriesUI();
            UIManager.Instance.ToggleObjectsUI();
        });
    }
}