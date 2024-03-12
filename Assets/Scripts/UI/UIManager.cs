using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject categoriesUI;
    [SerializeField] private GameObject objectsUI;

    [SerializeField] private List<GameObject> categoryObjectsUIList;
    [SerializeField] private List<GameObject> categoryObjectsGOList;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //Hide Category and Object UI Menu.
        ToggleCategoriesUI();
        ToggleObjectsUI();

        //Deactivate all GO related to UI and GO.
        DeactivateAllCategoryObjectGO();
        DeactivateAllCategoryObjectUIAndGO();

        //Set first category to avoid button overlapping in Object Menu.
        ActivateCategoryObjectUIByIndex(0);
    }

    public void ToggleCategoriesUI()
    {
        categoriesUI.SetActive(!categoriesUI.activeInHierarchy);
    }

    public void ToggleObjectsUI()
    {
        objectsUI.SetActive(!objectsUI.activeInHierarchy);
    }

    public void DeactivateAllCategoryObjectUIAndGO()
    {
        foreach (GameObject categoryObjectUI in categoryObjectsUIList)
        {
            categoryObjectUI.SetActive(false);
        }
        foreach (GameObject categoryObjectGO in categoryObjectsGOList)
        {
            categoryObjectGO.SetActive(false);
        }
    }

    public void ActivateCategoryObjectUIByIndex(int cIndex)
    {
        categoryObjectsUIList[cIndex].SetActive(true);
        categoryObjectsGOList[cIndex].SetActive(true);
    }

    public void DeactivateAllCategoryObjectGO()
    {
        foreach (GameObject categoryObjectGO in categoryObjectsGOList)
        {
            foreach(Transform child in categoryObjectGO.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ActivateCategoryObjectGOByIndex(int oIndex)
    {
        foreach (GameObject categoryObjectGO in categoryObjectsGOList)
        {
            if (categoryObjectGO.activeInHierarchy)
            {
                categoryObjectGO.transform.GetChild(oIndex).gameObject.SetActive(true);
            }
        }
    }
}
