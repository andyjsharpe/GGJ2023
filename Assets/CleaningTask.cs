using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningTask : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject[] smudges;
    [SerializeField] GameObject smudgePrefab;
    [SerializeField] int count;

    [SerializeField] string smudgeSpriteLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Load Smudge Sprites
        Sprite[] smudgeSprites = Resources.LoadAll<Sprite>(smudgeSpriteLocation);

        for (int i = 0; i < count; i ++)
        {
            // Random smudge selection
            Sprite randomSmudge = smudgeSprites[(int) Random.Range(0, smudgeSprites.Length - 1)];

            // Create Smudge Object
            GameObject smudge = Instantiate(smudgePrefab, this.transform);

            // Change Image
            Image img = smudge.GetComponent<Image>();
            img.sprite = randomSmudge;
        }
        
    }

    public void DestorySmudge(GameObject smudge)
    {
        Destroy(smudge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
