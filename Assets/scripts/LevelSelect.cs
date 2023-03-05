using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public List<string> levels = new List<string>();
    public GridLayoutGroup gridLayoutGroup;
    // Start is called before the first frame update
    void Start()
    {
        var completedLevels = GameSave._Level;
        for(int i = 0; i < levels.Count; i++)
        {
            var temp = Instantiate(levelButtonPrefab, gridLayoutGroup.transform);
            temp.name = levels[i];
            if (i > completedLevels) {
                temp.GetComponent<Button>().enabled = false;
                temp.GetComponentInChildren<Text>().color = Color.grey;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
