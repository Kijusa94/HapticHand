using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesPanelUI : MonoBehaviour
{
    [SerializeField] private Button BasicButton;
    [SerializeField] private Button AdvancedButton;
    [SerializeField] private Button OtherButton;
    [SerializeField] private Button ResetButton;

    void Awake()
    {
        BasicButton.onClick.AddListener(() =>
        {
            //Deactivate All Category UI menu and Activate BasicCategory using Index.
            UIManager.Instance.DeactivateAllCategoryObjectUIAndGO();
            UIManager.Instance.ActivateCategoryObjectUIByIndex(0);
        });

        AdvancedButton.onClick.AddListener(() =>
        {
            //Deactivate All Category UI menu and Activate AdvancedCategory using Index.
            UIManager.Instance.DeactivateAllCategoryObjectUIAndGO();
            UIManager.Instance.ActivateCategoryObjectUIByIndex(1);
        });

        OtherButton.onClick.AddListener(() =>
        {
            //Deactivate All Category UI menu and Activate OtherCategory using Index.
            UIManager.Instance.DeactivateAllCategoryObjectUIAndGO();
            UIManager.Instance.ActivateCategoryObjectUIByIndex(2);
        });

        ResetButton.onClick.AddListener(() =>
        {
            //Deactivate All.
            UIManager.Instance.DeactivateAllCategoryObjectUIAndGO();
            UIManager.Instance.DeactivateAllCategoryObjectGO();
        });
    }
}
