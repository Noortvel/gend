using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class PlayerController : MasterOfComponents
{

    
    public CharacterController characterController
    {
        private set;
        get;
    }
    
    private GroundPointer pointerController;

    [SerializeField]
    private Character _controlledCharacter;

    public Character controlledCharacter
    {
        get { return _controlledCharacter; }
    }

    [SerializeField]
    private GameObject cameraObject;
    [SerializeField]
    private GameObject groudPointerPrefab;
    [SerializeField]
    private GameObject characterTargetCirclePrefab;
    [SerializeField]
    private GameObject backlightCirclePrefab;

    private Camera cameraComponent;

    private void RaycastCheck()
    {
        //Cast from cam
        Vector3 screenplane = Input.mousePosition;
        screenplane.z = 10;
        Vector3 point = cameraComponent.ScreenToWorldPoint(screenplane);
        Vector3 sorc = cameraObject.transform.position;
        RaycastHit info;
        Vector3 dir = point - sorc;
        //int layer = 1 << 9; // TerrainLayer
        //Physics.Raycast(sorc, dir, out info, 40, layer)

        if (Physics.Raycast(sorc, dir, out info, 40f))
        {
            if (info.transform.tag == "Ground")
            {
                characterController.MoveTo(info.point);
                pointerController.Click(info);
            }
            if (info.transform.tag == "Character")
            {
                var obj = info.transform.gameObject;
                controlledCharacter.selectedObject = obj.GetComponent<Character>();

                selectedCircle.Targeting(controlledCharacter.selectedObject.gameObject);
            }
           
        }
    }
    private void RayCastUpdater()
    {
        Vector3 screenplane = Input.mousePosition;
        screenplane.z = 10;
        Vector3 point = cameraComponent.ScreenToWorldPoint(screenplane);
        Vector3 sorc = cameraObject.transform.position;
        RaycastHit info;
        Vector3 dir = point - sorc;
        int layer = 1 << 10; // Selectable
        if (Physics.Raycast(sorc, dir, out info, 40, layer))
        {
            backlightCircle.Targeting(info.transform.gameObject);
        } else
        {
            backlightCircle.UnTargeting();
        }
    }
    private SkillsSlots skillsSlots;
    private SelectableCircle selectedCircle;
    private SelectableCircle backlightCircle;
    void Awake()
    {
        _controlledCharacter = GetComponent<Character>();
        cameraComponent = cameraObject.GetComponent<Camera>();
        characterController = _controlledCharacter.GetComponent<CharacterController>();

        skillsSlots = new SkillsSlots(this);
        pointerController = new GroundPointer(this, groudPointerPrefab);
        selectedCircle = new SelectableCircle(this, characterTargetCirclePrefab);
        backlightCircle = new SelectableCircle(this, backlightCirclePrefab);

        //SKILLL Q
        skillsSlots.AddSkill(controlledCharacter.skills[0], KeyCode.Q);


    }
    private void InputCheckUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print(controlledCharacter.isTargetInSeeSector());
            RaycastCheck();
        }
    }
    protected override void UpdateTick()
    {
        InputCheckUpdate();
        RayCastUpdater();
    }
}
