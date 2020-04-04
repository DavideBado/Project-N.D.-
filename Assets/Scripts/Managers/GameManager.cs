using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public UIManager UI_Manager;
    public LevelManager Level_Manager;
    public Animator FlowFSM;
    public PlayerMovController Player;
    public DroneMoveController Drone;
    public string ChangePhaseTrigger, GameOverTrigger, WinTrigger, MainMenuTrigger;

    public bool InFirstPlanning = true;

    public List<KeySpot> AllPossiblekey;
    public KeySpot Key;
    public Capsulo Treasure;
    //public KeyCode ChangePhaseKey;

    public Action PlayerCaught;
    public Action PlayerGoal;
    public Action OnExePhaseAction;
    public Action PostObjective;
    public Action CheckEnemiesStateNPosition;

    [HideInInspector]
    public bool OnExePhase = false;
    [HideInInspector]
    public bool OnPlanPhase = false;


    public SpawnSpot CurrentStartSpot;
    public EscapeSpot CurrentEscapeSpot;

    public List<EnemyNavController> EnemiesInResearch = new List<EnemyNavController>();
    public List<EnemyNavController> EnemiesInPursue = new List<EnemyNavController>();

    public bool InCommandsScreen = false;
    private void OnEnable()
    {
        PlayerCaught += GameOver;
        PlayerGoal += Win;
        PostObjective += ChangePhase;
    }

    private void OnDisable()
    {
        PlayerCaught -= GameOver;
        PlayerGoal -= Win;
        PostObjective -= ChangePhase;
    }


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ChangePhase()
    {
        FlowFSM.SetTrigger(ChangePhaseTrigger);
    }

    private void GameOver()
    {
        FlowFSM.SetTrigger(GameOverTrigger);
    }

    private void Win()
    {
        FlowFSM.SetTrigger(WinTrigger);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("ChangePhase") != 0 && OnPlanPhase && !InCommandsScreen) CheckPlanning();
    }

    public void Setup()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (InFirstPlanning) Level_Manager.EnemiesAI.Clear();
            if (!Player) Player = FindObjectOfType<PlayerMovController>();
            if (!Drone) Drone = FindObjectOfType<DroneMoveController>();
            if (InFirstPlanning) Level_Manager.EnemiesAI = FindObjectsOfType<EnemyAI>().ToList();

            if (InFirstPlanning) Level_Manager.spawnSpots = FindObjectsOfType<SpawnSpot>().ToList();
            for (int i = 0; i < Level_Manager.spawnSpots.Count; i++)
            {
                Level_Manager.spawnSpots[i].gameObject.SetActive(InFirstPlanning);
            }

            if (InFirstPlanning && (Level_Manager.escapeSpots.Count == 0 || !Level_Manager.escapeSpots[0])) Level_Manager.escapeSpots = FindObjectsOfType<EscapeSpot>().ToList();
            for (int i = 0; i < Level_Manager.escapeSpots.Count; i++)
            {
                Level_Manager.escapeSpots[i].gameObject.SetActive(!InFirstPlanning);
            }

            if (!Level_Manager.Level) Level_Manager.Level = FindObjectOfType<PezzaMissingLevel>().gameObject;

            if (AllPossiblekey.Count == 0 || !AllPossiblekey[0]) AllPossiblekey = FindObjectsOfType<KeySpot>().ToList();
            if (!Key)
            {
                int _keyIndex = UnityEngine.Random.Range(0, AllPossiblekey.Count);
                for (int i = 0; i < AllPossiblekey.Count; i++)
                {
                    if (i == _keyIndex)
                    {
                        Key = AllPossiblekey[i];
                        Key.gameObject.SetActive(true);
                    }
                    else AllPossiblekey[i].gameObject.SetActive(false);
                }
            }
            if (!Treasure) Treasure = FindObjectOfType<Capsulo>();
        }
    }

    private void CheckPlanning()
    {
        Drone.SetupPopupsCamera(true);
        Drone.DroneCamera.enabled = false;
        Drone.enabled = false;
        if (/*CurrentEscapeSpot == null ||*/ CurrentStartSpot == null) UI_Manager.PopupEscapeSpwan.SetActive(true);
        else if (!CheckHidingCams()) UI_Manager.PopupHidingCam.SetActive(true);
        else UI_Manager.PopupUltimate.SetActive(true);
    }

    private bool CheckHidingCams()
    {
        List<HidingSpot> _hidingSpots = FindObjectsOfType<HidingSpot>().ToList();
        List<CamSpot> _camSpots = FindObjectsOfType<CamSpot>().ToList();
        return _hidingSpots.Count != 0 || _camSpots.Count != 0;
    }
}

