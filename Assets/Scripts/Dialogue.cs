using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue: MonoBehaviour{
    //shows the sentences in the inspector
    public string name;
    [TextArea(3,10)]
    public string[] sentences;

}
