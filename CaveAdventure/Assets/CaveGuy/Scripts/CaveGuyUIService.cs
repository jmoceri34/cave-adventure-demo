namespace CaveAdventure.CaveGuy
{
    using APPack;
    using UnityEngine;

    public class CaveGuyUIService : MonoBehaviour
    {
        public Transform UITempSpawnPoint;
        public GameObject UITempScoreTextPrefab;

        public void OnAwake()
        {

        }

        public void OnStart()
        {

        }

        public void SpawnUIScoreText()
        {
            var go = Instantiate(UITempScoreTextPrefab);
            go.transform.parent = UITempSpawnPoint.transform;
            go.transform.localPosition = Vector3.zero;
        }
    }
}