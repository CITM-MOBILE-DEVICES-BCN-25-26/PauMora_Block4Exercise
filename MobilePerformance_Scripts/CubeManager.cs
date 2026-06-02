using System;
using System.Text;
using UnityEngine;

namespace MobilePerformance
{
    public class CubeManager : MonoBehaviour
    {
        [SerializeField] UnoptimizedDistanceCubeSpawner cubeSpawner;

        [SerializeField] float distanceUpdateInterval = 3f;
        DateTime lastUpdateTime = DateTime.Now;

        StringBuilder stringBuilder = new StringBuilder();

        private void Update()
        {
            if ((DateTime.Now - lastUpdateTime).TotalSeconds >= distanceUpdateInterval)
            {
                lastUpdateTime = DateTime.Now;
            }
            else
            {
                return;
            }

            stringBuilder.Clear();

            if (cubeSpawner == null || cubeSpawner.cubeList.Count == 0)
            {
                return;
            }

            foreach (GameObject cube in cubeSpawner.cubeList)
            {
                foreach (GameObject otherCube in cubeSpawner.cubeList)
                {
                    if (otherCube == cube)
                    {
                        continue;
                    }
                    float distance = Vector3.Distance(cube.transform.position, otherCube.transform.position);
                    stringBuilder.AppendLine($"Distance cube {cube.gameObject.name} to {otherCube.gameObject.name}: {distance}");
                }
            }
            Debug.Log(stringBuilder.ToString());
        }
    }
}
