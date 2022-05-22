using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticPathFinder : MonoBehaviour
{
    public float creatureSpeed;
    public float pathMultiplier;
    int pathIndex = 0;
    public DNA dna;
    public bool hasFinished = false;
    bool hasBeenInitialized = false;
    Vector2 target;
    Vector2 nextPoint;

    public void InitCreature(DNA newDna, Vector2 _target)
    {
        dna = newDna;
        target = _target;
        nextPoint = transform.position;
        hasBeenInitialized = true;
    }

    private void Update()
    {
        if (hasBeenInitialized && !hasFinished)
        {
            if(pathIndex == dna.genes.Count || Vector2.Distance(transform.position, target) < 0.5f)
            {
                hasFinished = true;
            }

            if ((Vector2)transform.position == nextPoint)
            {
                nextPoint = (Vector2)transform.position + dna.genes[pathIndex] * pathMultiplier;
                pathIndex++;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, nextPoint, creatureSpeed * Time.deltaTime);
            }
        }
    }
    public float fitness
    {
        get
        {
            float dist = Vector2.Distance(transform.position, target);
            if (dist == 0)
            {
                dist = 0.0001f;
            }
            return 60 / dist;
        }
    }
}
