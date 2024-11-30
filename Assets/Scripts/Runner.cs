using UnityEngine;
using FontRenderer;
public class Runner : MonoBehaviour
{
    public string relativePathToFont;

    void Start()
    {
        Debug.Log("Start start");

        // Create an instance of FontReader and use it
        FontFileReader fontReader= new FontFileReader(relativePathToFont);
        FontFileParser fontParser = new FontFileParser(fontReader);
        OffsetSubTable offsetTable = fontParser.parseOffestSubTable();
        Debug.Log("Start end");

    }
}