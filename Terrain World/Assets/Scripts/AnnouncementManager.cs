using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnnouncementManager : MonoBehaviour
{
    private string currentAnnouncement = null;
    private float timePerAnnouncement = 5f;
    private float triggerDistance = 20f;
    private float announcementTimeStart;

    public TextMeshProUGUI guiText;
    public Transform playerTransform;

    public GameObject movementPromptLoc;
    public GameObject sprintPromptLoc;
    public GameObject goalPromptLoc;
    public GameObject goToTowerPromptLoc;
    public GameObject climbTowerPromptLoc;
    public GameObject firstTowerPromptLoc;
    public GameObject youWinPromptLoc;

    private List<GameObject> promptLocations = new List<GameObject>();
    private List<bool> promptsFound = new List<bool>();
    private List<string> announcements = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        guiText.gameObject.SetActive(false);

        promptLocations.Add(movementPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Use wasd to move and spacebar to jump");

        promptLocations.Add(sprintPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Hold shift or control to sprint");

        promptLocations.Add(goalPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Your goal is to find and get to the castle");

        promptLocations.Add(goToTowerPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Climb the tower to remove the fog from this area");

        promptLocations.Add(climbTowerPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Touch the tower and jump to ascend");

        promptLocations.Add(firstTowerPromptLoc);
        promptsFound.Add(false);
        announcements.Add("Your sprint speed increases when you climb a new tower.\n You need more to get to the castle");

        promptLocations.Add(youWinPromptLoc);
        promptsFound.Add(false);
        announcements.Add("You win. Have a nice day.\n Press Escape or Click to pause and quit.");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 7; i++)
        {
            if(!promptsFound[i] && Vector3.Distance(playerTransform.position, promptLocations[i].transform.position) < triggerDistance)
            {
                promptsFound[i] = true;
                currentAnnouncement = announcements[i];
                announcementTimeStart = Time.time;
                guiText.text = currentAnnouncement;
                guiText.gameObject.SetActive(true);
            }
        }

        if(currentAnnouncement != null)
        {
            if(Time.time - announcementTimeStart > timePerAnnouncement)
            {
                currentAnnouncement = null;
                guiText.gameObject.SetActive(false);
            }
        }
    }
}
