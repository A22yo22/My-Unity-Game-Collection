using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationController : MonoBehaviour
{
    List<GeneticPathFinder> population = new List<GeneticPathFinder>();

    public GameObject creaturePrefab;

    public int populationSize = 100;
    public int genomeLength;

    public float cutoff = 0.3f;

    public Transform spawnPoint;
    public Transform end;

    void InitPopulation()
    {
        for(int i = 0; i < populationSize; i++)
        {
            GameObject go = Instantiate(creaturePrefab, spawnPoint.position, Quaternion.identity);
            go.GetComponent<GeneticPathFinder>().InitCreature(new DNA(genomeLength), end.position);
            population.Add(go.GetComponent<GeneticPathFinder>());
        }
    }

    void NextGeneration()
    {
        int survivorCut = Mathf.RoundToInt(populationSize * cutoff);
        List<GeneticPathFinder> survivor = new List<GeneticPathFinder>();

        for(int i = 0; i < survivorCut; i++)
        {
            survivor.Add(GetFittest());
        }

        for(int i = 0; i < population.Count; i++)
        {
            Destroy(population[i].gameObject);
        }
        population.Clear();

        while(population.Count < populationSize)
        {
            for(int i = 0; i < survivor.Count; i++)
            {
                GameObject go = Instantiate(creaturePrefab, spawnPoint.position, Quaternion.identity);
                go.GetComponent<GeneticPathFinder>().InitCreature(new DNA(survivor[i].dna, survivor[Random.Range(0, 10)].dna), end.position);
                population.Add(go.GetComponent<GeneticPathFinder>());

                if (population.Count <= populationSize)
                {
                    break;
                }
            }
        }

        for (int i = 0; i < survivor.Count; i++)
        {
            Destroy(survivor[i].gameObject);
        }
    }

    private void Start()
    {
        InitPopulation();
    }
    private void Update()
    {
        if (!HasActive())
        {
            NextGeneration();
        }
    }

    GeneticPathFinder GetFittest()
    {
        float maxFitness = float.MaxValue;
        int index = 0;

        for(int i = 0; i < population.Count; i++)
        {
            if(population[i].fitness > maxFitness)
            {
                maxFitness = population[i].fitness;
                index = i;
            }
        }

        GeneticPathFinder fittest = population[index];
        population.Remove(fittest);
        return fittest;
    }

    bool HasActive()
    {
        for(int i = 0; i < population.Count; i++)
        {
            if (!population[i].hasFinished)
            {
                return true;
            }
        }
        return false;
    }
}
