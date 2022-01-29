using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] NoDragScrollRect scrollRect;
    [SerializeField] Button playAgainButton;

    private float yPos = 1f;
    private float speed;
    private bool startCredits = false;

    private void OnEnable()
    {
        this.yPos = 1f;
        this.speed = 0.05f;
        this.playAgainButton.gameObject.SetActive(false);
        this.scrollRect.normalizedPosition = new Vector2(0, 1);
        StartCoroutine(DelayCredits());
    }

    private void Update()
    {
        if (this.startCredits)
        {
            this.yPos -= speed * Time.deltaTime;
            this.scrollRect.normalizedPosition = new Vector2(0, yPos);
        }

        if (yPos < 0)
        {
            this.startCredits = false;
            StartCoroutine(DelayShowPlayAgain());
        }
    }

    private IEnumerator DelayCredits()
    {
        yield return new WaitForSeconds(2f);
        this.startCredits = true;
    }

    private IEnumerator DelayShowPlayAgain()
    {
        yield return new WaitForSeconds(2f);
        ShowPlayAgainButton();
    }

    private void ShowPlayAgainButton()
    {
        this.playAgainButton.gameObject.SetActive(true);
    }

    #region Unity Button Events
    public void PlayAgainButtonClicked()
    {
        GameManager.Instance.InitializeGame(1);
    }
    #endregion
}
