using UnityEngine;
using UnityEditor;

public class EditorDeseleectOnPlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#if (UNITY_EDITOR)
        Selection.objects = null;
#endif
    }
}
