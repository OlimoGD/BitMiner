using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContextMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuItemPrefab;

    public List<Button> CreateItems(string[] itemNames)
    {
        List<Button> createdButtons = new List<Button>();
        for (int i = 0; i < itemNames.Length; i++)
        {
            GameObject menuItemGo = Instantiate(menuItemPrefab, Vector3.zero, Quaternion.identity, this.transform);
            menuItemGo.GetComponentInChildren<TextMeshProUGUI>().text = itemNames[i];
            Button btn = menuItemGo.GetComponent<Button>();
            createdButtons.Add(btn);
        }
        //hack to make it look right
        GetComponent<RectTransform>().position += new Vector3(0.001f, 0, 0);
        return createdButtons;
    }
}
