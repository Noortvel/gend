#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeSpawnerTool))]
[CanEditMultipleObjects]
public class TreeSpawnerToolEditor : Editor {
    private TreeSpawnerTool spawner;
    private string buttonText = "Enable";
    
    private void OnEnable()
    {
        spawner = target as TreeSpawnerTool;
        if (spawner.isActive)
        {
            buttonText = "Disable";
        }
        else
        {
            buttonText = "Enable";
        }
    }
    public override void OnInspectorGUI()
    {
        GUILayout.Label("Ctrl + Right Mouse Button to Instancenate");
        DrawDefaultInspector();
        if (GUILayout.Button(buttonText))
        {
            if (spawner.isActive)
            {
                buttonText = "Enable";
                spawner.isActive = false;
            }
            else
            {
                buttonText = "Disable";
                spawner.isActive = true;
            }
        }
        
    }
    void OnSceneGUI()
    {
        if (spawner.isActive)
        {
            if (Event.current.type == EventType.MouseUp && Event.current.button == 1 && Event.current.control)
            {
                spawner.SpawnTree();
            }
            
        }
    }
}
[ExecuteInEditMode]
public class TreeSpawnerTool : MonoBehaviour
{
    [SerializeField]
    public bool isActive = false;
    [SerializeField]
    private GameObject treeParent;
    [SerializeField]
    private GameObject treeObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        //if (Input.GetMouseButton(0))
        //{
        //    SpawnTree();
        //}
    }
    public void SpawnTree()
    {


        Vector2 screenplane = Event.current.mousePosition;
        var editorCam = SceneView.GetAllSceneCameras()[0];
        
        Ray wray = HandleUtility.GUIPointToWorldRay(screenplane);
        Vector3 dir = wray.direction;
        RaycastHit info;
        int layer = 1 << 9; // TerrainLayer
        if (Physics.Raycast(editorCam.transform.position, dir, out info, 140f, layer))
        {
            var obj = Instantiate(treeObject, treeParent.transform);
            Undo.RegisterCreatedObjectUndo(obj, "CreateTree");
            obj.transform.position = info.point;
            //Debug.DrawRay(info.point, info.normal, Color.yellow, 10f);
            Debug.DrawLine(editorCam.transform.position, info.point, Color.red, 2f);
            //EditorUtility.SetDirty(treeParent);


        }
    }
}
#endif