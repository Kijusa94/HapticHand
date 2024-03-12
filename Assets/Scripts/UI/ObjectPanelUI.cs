using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelUI : MonoBehaviour
{
    [SerializeField] private Button figure1Button;
    [SerializeField] private Button figure2Button;
    [SerializeField] private Button figure3Button;

    void Awake()
    {
        figure1Button.onClick.AddListener(() =>
        {
            UIManager.Instance.DeactivateAllCategoryObjectGO();
            UIManager.Instance.ActivateCategoryObjectGOByIndex(0);
        });

        figure2Button.onClick.AddListener(() =>
        {
            UIManager.Instance.DeactivateAllCategoryObjectGO();
            UIManager.Instance.ActivateCategoryObjectGOByIndex(1);
        });

        figure3Button.onClick.AddListener(() =>
        {
            UIManager.Instance.DeactivateAllCategoryObjectGO();
            UIManager.Instance.ActivateCategoryObjectGOByIndex(2);
        });
    }
}
