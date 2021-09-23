using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PickUp : MonoBehaviour
    {
        public const string PlayerTag = "Player";

        [SerializeField] private GameObject pickedFx;

        private void Update()
        {
            transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                SpawnFx();
            }
        }

        private void SpawnFx()
        {
            GameObject fx = Instantiate(pickedFx);
            Vector3 thisPos = transform.position;
            fx.transform.position = new Vector3(thisPos.x, fx.transform.position.y, thisPos.z);
            Destroy(fx, 1f);
        }
    }
}