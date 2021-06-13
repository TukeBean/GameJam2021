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
    public GameObject BottomBunSpritePrefab;
    public GameObject PattySpritePrefab;
    public GameObject LettuceSpritePrefab;
    public GameObject TomatoSpritePrefab;
    public GameObject TopBunSpritePrefab;
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
    private bool sendOrder;

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
    void FixedUpdate()
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
            if (BPMCount == 576)
            {
                BPMCount = 0;

                //Checks for a failed note, or an order being completely sent
                if ((fail && !sendOrder) || noteNum == Day1[orderNum].Count)
                {
                    //If all active notes have been processed, start next order
                    if (ActiveNotes.Count == 0)
                    {
                        GameManager.instance.setPunchBool(true);
                        sendOrder = true;
                        noteNum = 0;
                        orderNum++;
                        delay = 0;
                    }

                }
                else
                {
                    if (!sendOrder)
                    {
                        GameObject note = Instantiate(Day1[orderNum][noteNum], new Vector3(800, 0, 0), new Quaternion(0, 0, 0, 0), BeatHolder) as GameObject;
                        ActiveNotes.Enqueue(note);
                        //Updates to next note
                        noteNum++;
                    } 
                    else if (!GameManager.instance.player.getPunchBool()) 
                    {
                        sendOrder = false;
                        if (!fail) {
                            orderComplete();
                        } else {
                            clearTray();
                        }
                        fail = false;
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
        string name = ActiveNotes.Dequeue().ToString().Split('(')[0];

        GameObject preFab;

        switch (name) 
        {
            case "BottomBun":
                preFab = BottomBunSpritePrefab;
                break;
            case "Patty":
                preFab = PattySpritePrefab;
                break;
            case "Lettuce":
                preFab = LettuceSpritePrefab;
                break;
            case "Tomato":
                preFab = TomatoSpritePrefab;
                break;
            case "TopBun":
                preFab = TopBunSpritePrefab;
                break;
            default:
                preFab = BottomBunSpritePrefab;
                break;
        }

        GameObject hitNote = Instantiate(preFab, new Vector3(0, (-125 + 10 * SuccessNotes.Count), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
        //hitNote.SetActive(true);

        SuccessNotes.Enqueue(hitNote);

        hitNote.GetComponent<SpriteRenderer>().sortingOrder = SuccessNotes.Count;

        Debug.Log("Active Notes: " + ActiveNotes.Count);
        Debug.Log("Success Notes: " + SuccessNotes.Count);
    }

    public void orderComplete() {
        Debug.Log("Order Complete(?)");
        GameManager.instance.player.successfulOrder();

        while (SuccessNotes.Count > 0) {
            SuccessNotes.Dequeue().SetActive(false);
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


    public void clearTray() 
    {
        //Flushes all the notes on the tray
        while (SuccessNotes.Count > 0) 
        {
            SuccessNotes.Dequeue().SetActive(false);
        }
    }

    public void setDay(int day)
    {
        Debug.Log("the current day is: " + day);
    }
}
