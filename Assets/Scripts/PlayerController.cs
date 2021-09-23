using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace Assets.Scripts
{
    class PlayerController : MonoBehaviour
    {
        public const string PickUpTag = "PickUp";
        public const string ScoreTextUnformatted = "Score: {0}";

        [SerializeField] private PickUpSpawner spawner;
        [SerializeField] private float speed;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject winPanelObj;

        private Rigidbody rb;
        private float inputX;
        private float inputY;
        private int totalScore;
        private int roundScore;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            scoreText.text = string.Format(ScoreTextUnformatted, totalScore);
            RestartGame();
        }

        private void OnMove(InputValue inputValue)
        {
            Vector2 inputVector = inputValue.Get<Vector2>();
            inputX = inputVector.x;
            inputY = inputVector.y;
        }

        private void FixedUpdate()
        {
            Vector3 moveForce = new Vector3(inputX, 0f, inputY) * speed;
            rb.AddForce(moveForce);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PickUpTag))
            {
                other.gameObject.SetActive(false);
                AddScore(1);
            }
        }

        private void AddScore(int offset)
        {
            totalScore += offset;
            roundScore += offset;
            scoreText.text = string.Format(ScoreTextUnformatted, totalScore);
            if (roundScore >= spawner.WinScore)
            {
                EndRound();
            }
        }

        private void EndRound()
        {
            winPanelObj.SetActive(true);
            Cursor.visible = true;
        }

        public void RestartGame()
        {
            roundScore = 0;
            winPanelObj.SetActive(false);
            spawner.RestartGame();
            Cursor.visible = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}