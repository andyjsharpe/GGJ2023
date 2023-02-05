using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingTask : MonoBehaviour
{

    // Variables
    public static int REMOVING_COUNT = 0;

    [SerializeField] GameObject weedPrefab;
    [SerializeField] int count;
    [SerializeField] RectTransform spawnArea;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            // Randomize Spawn Location
            Vector2 randomPos = new Vector2();
            randomPos.x = Random.Range(0, spawnArea.rect.width) - spawnArea.rect.width / 2;
            randomPos.y = Random.Range(0, spawnArea.rect.height) - spawnArea.rect.height / 2;

            // Instantiate Weed Object
            GameObject weed = Instantiate(weedPrefab, this.transform);

            // Set randomized position
            weed.transform.localPosition = randomPos;
            weed.GetComponent<RemoveME>().START_POS = randomPos;
        }
    }

    void Update()
    {
        if (!complete && count == REMOVING_COUNT)
        {
            complete = true;
            Debug.Log("TASK COMPLETE!");
        }
    }
}
