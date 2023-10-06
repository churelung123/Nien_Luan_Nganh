using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NPCMovement : MonoBehaviour
{
    public Animator myAnim;
    [HideInInspector] public bool isMove;
    [HideInInspector] public float moveSpeed;
    [HideInInspector] public bool isWalking;
    [HideInInspector] public float waitTime;
    private float waitCounter;
    private int WalkDirection = 0;
    [HideInInspector] [SerializeField] public List<GameObject> waypoints;
    
    
    public GameObject dialogue;
    public DialogueTrigger dialogueTriggerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
        ChooseDirection();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            if(isWalking)
            {
                Move();
                Came();
                dialogueFollow();
            }
            
            else
            {
                waitCounter -= Time.deltaTime;
                if(waitCounter < 0)
                {
                    ChooseDirection();
                }
            }            
        }
    }

    public void dialogueFollow()
    {
        dialogue.transform.position = new Vector3(gameObject.transform.position.x, dialogue.transform.position.y, dialogue.transform.position.z);
    }
    public void Move()
    {
        if(transform.position != waypoints[WalkDirection].transform.position && dialogueTriggerScript.isTalk == false)
            {
                myAnim.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, waypoints[WalkDirection].transform.position, moveSpeed * Time.deltaTime);
            }
    }

    public void Came()
    {
        if(transform.position == waypoints[WalkDirection].transform.position || dialogueTriggerScript.isTalk == true)
            {
                myAnim.SetBool("isRunning", false);
                isWalking = false;
                waitCounter = waitTime;
            }
    }

    public void ChooseDirection()
    {
        WalkDirection++;
        if (WalkDirection >= waypoints.Count)
        {
            WalkDirection = 0;
        }
        if (!dialogueTriggerScript.isTalk)
        {
            if (WalkDirection == 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            if (WalkDirection == 1)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
        }
        isWalking = true;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NPCMovement))]
public class NPCMovement_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        NPCMovement script = (NPCMovement)target;
        script.isMove = EditorGUILayout.Toggle("isMove", script.isMove);
        if(script.isMove)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("MoveSpeed", GUILayout.MaxWidth(70));
            script.moveSpeed = EditorGUILayout.FloatField(script.moveSpeed);

            EditorGUILayout.LabelField("WaitTime", GUILayout.MaxWidth(60));
            script.waitTime = EditorGUILayout.FloatField(script.waitTime);
            
            EditorGUILayout.EndHorizontal();

            script.isWalking = EditorGUILayout.Toggle("Is Walking", script.isWalking);

            for (int i = 0; i < script.waypoints.Count; i++)
            {
                script.waypoints[i] = EditorGUILayout.ObjectField("Waypoints", script.waypoints[i], typeof(GameObject), true) as GameObject;
            }
        }
    }
}
#endif