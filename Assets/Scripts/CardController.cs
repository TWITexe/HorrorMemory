using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    // values for our "cards-grid"
    private const int gridRows = 2;
    private const int gridCols = 4;
    private const float offsetX = 2;
    private const float offsetY = 2.5f;
    //Revealed cards during the game
    private MemoryCard firstReveald;
    private MemoryCard secondReveald;

    private Enemy enemy;

    private int score = 0;
    public int lose = 0;

    public bool canReveal
    {
        // return 'false' while second card is revealed
        get { return secondReveald == null; }
    }
    
    void Start()
    {
        // Find game object with name "Enemy" and apply it to the variable enemy
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        // position first card on table
        Vector3 startPos = originalCard.transform.position;
        int[] numbersIdForCard = {0, 0, 1, 1, 2, 2, 3, 3};
        //Shuffle our card
        numbersIdForCard = ShuffleArray(numbersIdForCard);
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                    card = originalCard;
                else
                    card = Instantiate(originalCard) as MemoryCard;

                int index = j * gridCols + i;
                // set id for our card to identify paired cards
                int id = numbersIdForCard[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i * 1.5f) + startPos.x;
                float posY = -(offsetY * j * 2f) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
    private int[] ShuffleArray(int[] numbers)
    {
        // Shuffle the cards using the "Fisher-Yates" algorithm
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int temporaryID = newArray[i];
            int randConstantID = Random.Range(i, newArray.Length);
            newArray[i] = newArray[randConstantID];
            newArray[randConstantID] = temporaryID;
        }
        return newArray;
    }

    public void CardRevealed(MemoryCard card)
    {
        // check the free variable and save the card there
        if (firstReveald == null)
        {
            firstReveald = card;
        }
        else
        {
            secondReveald = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (firstReveald.Id == secondReveald.Id)
        {
            score++;
            enemy.EnemyDamage(2.5f);
        }
        else
        {
            lose++;
            enemy.GetEnemyRage();
            yield return new WaitForSeconds(1f);
            firstReveald.Unreveal();
            secondReveald.Unreveal();
        }
        firstReveald = null;
        secondReveald = null;
    }
    
}
