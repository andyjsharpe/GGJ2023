using UnityEngine;
using UnityEngine.UI;

public class CleaningTask : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject[] smudges;
    [SerializeField] GameObject smudgePrefab;
    [SerializeField] int count;
    [SerializeField] float innerDist;
    [SerializeField] float outerDist;

    [SerializeField] string smudgeSpriteLocation;

    private TaskCompleter taskCompleter;

    // Start is called before the first frame update
    void Start()
    {
        taskCompleter = GetComponent<TaskCompleter>();
        
        // Load Smudge Sprites
        Sprite[] smudgeSprites = Resources.LoadAll<Sprite>(smudgeSpriteLocation);


        for (int i = 0; i < count; i++)
        {
            // Random smudge selection
            Sprite randomSmudge = smudgeSprites[(int) Random.Range(0, smudgeSprites.Length - 1)];

            // Randomize Spawn Location

            Vector2 randomVector = Random.insideUnitCircle;
            Vector2 randomPos = randomVector * (outerDist - innerDist) + randomVector.normalized * innerDist;

            // Create Smudge Object
            GameObject smudge = Instantiate(smudgePrefab, this.transform);

            // Change Image
            Image img = smudge.GetComponent<Image>();
            img.sprite = randomSmudge;

            // Change Position
            smudge.transform.position = new Vector3(randomPos.x, randomPos.y, 0) + transform.position;

            // Change rotation
            smudge.transform.rotation = Quaternion.FromToRotation(Vector3.right, randomPos);
        }
        
    }

    public void DestorySmudge(GameObject smudge)
    {
        Destroy(smudge);
    }

    // Update is called once per frame
    void Update()
    {
        //I assumed that this is how you would check completion, but be sure to change if that is not the case
        if (FindObjectsOfType<Destory>().Length == 0)   //since all smudge objects have a destroy script, we can assume that if the num = 0, they have been all cleaned
        {
            Debug.Log("TASK COMPLETE");
            taskCompleter.completeTask(taskManager.TaskOptions.CleanPlants); //This completes the "CleanPlants" task
        }
    }
}
