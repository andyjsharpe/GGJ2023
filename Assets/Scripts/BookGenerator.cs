using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject leftPage;
    [SerializeField] GameObject rightPage;
    [SerializeField] GameObject linePrefab;

    public const int LETTERS_PER_LINE = 27;
    public const int LINES_PER_PAGE = 13;

    public int READING_LIMIT;
    public static int READING_COUNT;

    bool complete = false;

    private TaskCompleter taskCompleter;

    // Start is called before the first frame update
    void Start()
    {

        taskCompleter = GetComponent<TaskCompleter>();

        List<string> lines = generateLines(Book.day1);
        Debug.Log("# of Lines: " + lines.Count);

        // Add line to left page
        for (int i = 0; i < LINES_PER_PAGE; i++)
        {
            if (i < lines.Count)
            {
                GameObject line = Instantiate(linePrefab, leftPage.transform);
                TextMeshProUGUI text = line.GetComponent<TextMeshProUGUI>();
                text.SetText(lines[i]);
                if (lines[i].Equals(""))
                {
                    text.color = LineClick.clicked;
                }
                else
                {
                    READING_LIMIT++;
                }
            } else
            {
                GameObject line = Instantiate(linePrefab, leftPage.transform);
                TextMeshProUGUI text = line.GetComponent<TextMeshProUGUI>();
                text.SetText("");
                text.color = LineClick.clicked;
            }
        }

        // Add line to right page
        for (int i = LINES_PER_PAGE; i < 2 * LINES_PER_PAGE; i++)
        {
            if (i < lines.Count)
            {
                GameObject line = Instantiate(linePrefab, rightPage.transform);
                TextMeshProUGUI text = line.GetComponent<TextMeshProUGUI>();
                text.SetText(lines[i]);
                if (lines[i].Equals(""))
                {
                    text.color = LineClick.clicked;
                } else
                {
                    READING_LIMIT++;
                }
            }
            else
            {
                GameObject line = Instantiate(linePrefab, leftPage.transform);
                TextMeshProUGUI text = line.GetComponent<TextMeshProUGUI>();
                text.SetText("");
                text.color = LineClick.clicked;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!complete && READING_COUNT == READING_LIMIT)
        {
            complete = true;
            Debug.Log("TASK COMPLETED!");
            taskCompleter.completeTask(taskManager.TaskOptions.Read); //This completes the "Read" task
        }
    }

    private List<string> generateLines(string day)
    {
        // Create new ArrayList
        List<string> lines = new List<string> ();
        string[] paragraphs = day.Split("\r\n");
        Debug.Log("Paragraphs: " + paragraphs.Length);

        foreach (string par in paragraphs)
        {
            for (int i = 0; i < par.Length; i+= LETTERS_PER_LINE)
            {
                if (i + LETTERS_PER_LINE < par.Length)
                {
                    string line = par.Substring(i, LETTERS_PER_LINE);                    
                    if (line.IndexOf(" ") == 0){
                        line.Remove(0, 1);
                    }
                    lines.Add(line);

                }
                else
                {
                    string line = par.Substring(i);
                    if (line.IndexOf(" ") == 0)
                    {
                        line.Remove(0, 1);
                    }
                    lines.Add(line);
                }
            }

            // Add Empty Line
            lines.Add("");
        }

        return lines;
    }
}
