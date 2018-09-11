using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPanel : MonoBehaviour {

    public GameObject saveornot;
    public GameObject optionBar;

    public PanelCenter pc;

    void Start()
    {
        saveornot.SetActive(false);
        optionBar.SetActive(false);
    }
}
