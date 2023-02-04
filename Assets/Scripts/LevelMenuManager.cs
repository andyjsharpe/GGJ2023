using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuManager : MonoBehaviour
{
    // Misc Variables
    public static Color lvlColor = Color.white;
    public static string LEVEL_REACHED_KEY = "temp";
    int LEVEL_REACHED = 0;


    // Menu Variables
    public GameObject levelPrefab;
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject menuGrid;

    // Fixed Shifting Variables
    [SerializeField] GameObject shiftPrefab;
    [SerializeField] GameObject currentShiftPrefab;

    const int MIN_SHIFTS = 0;
    const int SHIFT_GAP = 75;
    const int SHIFT_SIZE = 800;
    const float LEVELS_PER_SHIFT = 12f;
    const float SHIFT_DURATION = 1f;

    // Changing Shifting Variables
    public int MAX_SHIFTS;
    public bool isShifting;
    int shift;
    int lastShift = -1;


    public int DEBUG_EXTRA_LEVELS = 0;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Level Menu Manager Start");

        // Retrive Farthest Level reached
        LEVEL_REACHED = PlayerPrefs.GetInt(LEVEL_REACHED_KEY, -1);

        if (LEVEL_REACHED < 1)
        {
            // Define FarthestLevel
            LEVEL_REACHED = 1;
            PlayerPrefs.SetInt(LEVEL_REACHED_KEY, LEVEL_REACHED);
        }

        // Load levels
        // TODO: Code to Load Levels!
        int levelCount = DEBUG_EXTRA_LEVELS;
        Debug.Log("Level count:" + levelCount);

        // Create Level Selector Buttons
        for (int i = 1; i <= levelCount; i++)
        {
            Debug.Log("i" + i);
            GameObject lvlBtn = Instantiate(levelPrefab, menuGrid.transform, false);
            lvlBtn.GetComponent<LevelSelector>().ChangeText(i.ToString());

            // Change Color
            //Image lvlImg = lvlBtn.GetComponent<Image>();
            //lvlImg.color = lvlColor;

            // Deactivate button if not yet unlocked
            if (i > LEVEL_REACHED)
            {
                Button btnComponent = lvlBtn.GetComponent<Button>();
                btnComponent.interactable = false;
            }
        }

        MAX_SHIFTS = (int)Mathf.Ceil(levelCount / LEVELS_PER_SHIFT) - 1;
        shift = 0;

        //createIndicator(MAX_SHIFTS, shift);
    }

    // Creates Indicator using only input values
    void createIndicator(int shifts, int currentShiftIndex)
    {
        // Permanently Fix Width first time
        if (lastShift == -1)
        {
            RectTransform transformRect = indicator.GetComponent<RectTransform>();
            transformRect.sizeDelta = new Vector2(SHIFT_GAP * shifts, transformRect.sizeDelta.y);
        }

        GameObject[] shiftObjs = GameObject.FindGameObjectsWithTag("Shift");

        // Destory existing indicator
        foreach (GameObject obj in shiftObjs)
        {
            Destroy(obj);
        }

        // Recreate Indicator
        for (int i = 0; i < shifts + 1; i++)
        {
            if (i == currentShiftIndex)
            {
                Instantiate(currentShiftPrefab, indicator.transform);
            }
            else
            {
                Instantiate(shiftPrefab, indicator.transform);
            }
        }
    }

    // Co-Routine to shift the level menu
    public IEnumerator Shift(bool shiftingRight)
    {    
        if ((shift + 1 <= MAX_SHIFTS && shiftingRight) || (shift - 1 >= MIN_SHIFTS && !shiftingRight))
        {
            // Update shifting status
            isShifting = true;

            // Change the shift number
            shift += (shiftingRight) ? 1 : -1;

            // Find New Transform position
            Vector3 pos = menuGrid.transform.localPosition;
            Vector3 newPos = new Vector3(-1 * shift * SHIFT_SIZE, pos.y, pos.z);

            // Recreate Indicator
            createIndicator(MAX_SHIFTS, shift);

            // Begin Shifting Menu
            float t = 0f;
            while (t <= SHIFT_DURATION)
            {
                t += Time.deltaTime;
                menuGrid.transform.localPosition = Vector3.Lerp(pos, newPos, Mathf.SmoothStep(0f, SHIFT_DURATION, t));
                yield return null;
            }

            isShifting = false;
        }

        yield return null;
    }
}
