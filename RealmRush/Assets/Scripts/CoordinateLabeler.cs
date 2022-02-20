﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.white;
    [SerializeField] Color blockedColour = Color.gray;
    [SerializeField] Color exploredColour = Color.yellow;
    [SerializeField] Color pathColour = new Color(1.0f, 0.5f, 0.0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        displayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            displayCoordinates();
            UpdateObjectName();
        }

        SetLabelColour();
        ToggleLabels();
    }

    private void SetLabelColour()
    {
        if(gridManager == null)
        {
            return;
        }
        Node node = gridManager.GetNode(coordinates);

        if(node == null)
        {
            return;
        }

        if(!node.isWalkable)
        {
            label.color = blockedColour;
        }
        else if(node.isPath)
        {
            label.color = pathColour;
        }
        else if(node.isExplored)
        {
            label.color = exploredColour;
        }
        else
        {
            label.color = defaultColour;
        }

    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void displayCoordinates()
    {
        if(gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
