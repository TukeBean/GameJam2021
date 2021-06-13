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
    private List<List<GameObject>> Day1 = new List<List<GameObject>>();
    private List<GameObject> ClassicPrefab = new List<GameObject>();
    private List<GameObject> MeatyPrefab = new List<GameObject>();
    private List<GameObject> SaladPrefab = new List<GameObject>();
    public Queue<GameObject> ActiveNotes = new Queue<GameObject>();
    public Queue<GameObject> SuccessNotes = new Queue<GameObject>();
    public Transform BeatHolder;
    public int BPMCount = 0;
    public bool hasStarted;
    private int orderNum;
    private int noteNum;
    private int delay;
    private bool fail;

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

        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                orderNum = 0;
                noteNum = 0;
                delay = 0;
            }
        }
        else
        {
            BPMCount++;
            if (BPMCount == 288)
            {
                BPMCount = 0;

                //Checks for a failed note, or an order being completely sent
                if (fail || noteNum == Day1[orderNum].Count)
                {
                    //If all active notes have been processed, start next order
                    if (ActiveNotes.Count == 0)
                    {
                        GameManager.instance.setPunchBool(true);
                        noteNum = 0;
                        orderNum++;
                        delay = 0;
                        fail = false;
                    }

                }
                else
                {
                    //Checks if there's a delay
                    if (delay == 0 && !GameManager.instance.player.getPunchBool())
                    {

                        //If no delays, sends the next note
                        GameObject note = Instantiate(Day1[orderNum][noteNum], new Vector3(800, 0, 0), new Quaternion(0, 0, 0, 0), BeatHolder) as GameObject;
                        ActiveNotes.Enqueue(note);
                        //Updates to next note
                        noteNum++;
                    }
                    else
                    {
                        //If there is a delay, decrements the delay
                        if (!GameManager.instance.player.getPunchBool())
                            delay--;
                    }
                }
            }


        }
    }

    public void hitNote()
    {
        //Dequeues the note that was hit
        // ActiveNotes.Dequeue();

        // pop from active into the success queue
        SuccessNotes.Enqueue(ActiveNotes.Dequeue());
        Debug.Log("Active Notes: " + ActiveNotes.Count);
        Debug.Log("Success Notes: " + SuccessNotes.Count);

        if (ActiveNotes.Count == 0)
        {
            Debug.Log("Order Complete(?)");
        }
    }

    public void failedNote()
    {
        fail = true;
        //Flushes all the notes of the failed order
        while (ActiveNotes.Count > 0)
        {
            ActiveNotes.Dequeue().SetActive(false);
        }
    }
}
