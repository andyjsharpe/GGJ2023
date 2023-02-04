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


        for (int i = 0; i < count; i++)
        {
            // Random smudge selection
            Sprite randomSmudge = smudgeSprites[(int) Random.Range(0, smudgeSprites.Length - 1)];

            // Randomize Spawn Location
            RectTransform parent = (RectTransform)this.transform.transform;
            Vector2 randomPos = new Vector2();
            randomPos.x = Random.Range(0, parent.rect.width) - parent.rect.width / 2;
            randomPos.y = Random.Range(0, parent.rect.height) - parent.rect.height / 2;

            // Create Smudge Object
            GameObject smudge = Instantiate(smudgePrefab, this.transform);

            // Change Image
            Image img = smudge.GetComponent<Image>();
            img.sprite = randomSmudge;

            // Change Position
            smudge.transform.localPosition = new Vector3(randomPos.x, randomPos.y, 0);
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
