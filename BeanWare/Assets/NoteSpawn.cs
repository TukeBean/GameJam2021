using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{

    public GameObject BottomBunPrefab;
    public GameObject PattyPrefab;
    public GameObject LettucePrefab;
    public GameObject TomatoPrefab;
    public GameObject TopBunPrefab;
    private List<List<GameObject>> Day1 = new List<List<GameObject>> ();
    private List<GameObject> ClassicPrefab = new List<GameObject>();
    private List<GameObject> MeatyPrefab = new List<GameObject>();
    private List<GameObject> SaladPrefab = new List<GameObject>();
    public Transform BeatHolder;
    public int BPMCount = 0;
    public bool hasStarted;
    private int orderNum;
    private int noteNum;
    private int delay;

    // Start is called before the first frame update
    void Start()
    {
        ClassicPrefab.Add(BottomBunPrefab);
        ClassicPrefab.Add(PattyPrefab);
        ClassicPrefab.Add(LettucePrefab);
        ClassicPrefab.Add(TomatoPrefab);
        ClassicPrefab.Add(TopBunPrefab);

        MeatyPrefab.Add(BottomBunPrefab);
        MeatyPrefab.Add(PattyPrefab);
        MeatyPrefab.Add(PattyPrefab);
        MeatyPrefab.Add(PattyPrefab);
        MeatyPrefab.Add(TopBunPrefab);

        SaladPrefab.Add(LettucePrefab);
        SaladPrefab.Add(LettucePrefab);
        SaladPrefab.Add(TomatoPrefab);

        Day1.Add(ClassicPrefab);
        Day1.Add(ClassicPrefab);
        Day1.Add(MeatyPrefab);
        Day1.Add(SaladPrefab);
        Day1.Add(MeatyPrefab);
        Day1.Add(SaladPrefab);
        Day1.Add(MeatyPrefab);
        Day1.Add(SaladPrefab);
        Day1.Add(ClassicPrefab);
        Day1.Add(MeatyPrefab);
        Day1.Add(SaladPrefab);

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted) {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                orderNum = 0;
                noteNum = 0;
                delay = 0;
            }
        } else {
            BPMCount++;
            if (BPMCount == 288) {
                BPMCount = 0;

                //Checks if there's a delay
                if (delay == 0) {
                    //If no delays, sends the next note
                    GameObject L = Instantiate(Day1[orderNum][noteNum], new Vector3(800, 0, 0), new Quaternion(0, 0, 0, 0), BeatHolder) as GameObject;
                    //Updates to next note
                    noteNum++;
                } else {
                    //If there is a delay, decrements the delay
                    delay--;
                }

                //Checks if the full order has been sent (Currently is hard coded to 1 order)
                if(noteNum == Day1[orderNum].Count) {
                    //Resets the note count
                    noteNum = 0;
                    //Moves to next order
                    orderNum++;
                    //adds a delay
                    delay = 8;
                }
            }


        }
    }
}
