using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSection : SectionGenerator {

    private const int MIN_COLUMN_SPACING = 20;
    private const int MAX_COLUMN_SPACING = 50;

    private const int MIN_NUMBER_ROWS_TO_SPAWN = 5;
    private const int MAX_NUMBER_ROWS_TO_SPAWN = 10;

    private const int MIN_WIDTH = 5;
    private const int MAX_WIDTH = 15;

    private const int MIN_LENGTH = 20;
    private const int MAX_LENGTH = 50;

    private const int MIN_HEIGHT = 10;
    private const int MAX_HEIGHT = 50;

    private const int FLOOR_LEVEL = 3;
    private const int NUMBER_OF_COLUMNS_TO_SPAWN = 20;
    private const int ROW_GAP_DISTANCE = 50;

    public override void Init(int ZPosition) {
        this.ZPosition = ZPosition;
        this.EnvObject = (GameObject) Resources.Load("Prefabs/Environment/EnvCube");
        this.SingleRowDistance = ROW_GAP_DISTANCE;
    }

    /// <summary>
    /// Spawn a section of cubes
    /// </summary>
    public override void CreateSection() {
        int NumberOfRowsToSpawn = Random.Range(MIN_NUMBER_ROWS_TO_SPAWN, MAX_NUMBER_ROWS_TO_SPAWN);

        for (var i = 0; i < NumberOfRowsToSpawn; i++) {
            int ColumnSpaces = Random.Range(MIN_COLUMN_SPACING, MAX_COLUMN_SPACING);
            var LongestCube = MIN_LENGTH;
            for (var ColumnSlot = 0; ColumnSlot < NUMBER_OF_COLUMNS_TO_SPAWN; ColumnSlot++) {
                var x = ColumnSpaces * ColumnSlot;
                var RowLength = CreateCube(x);
                if (RowLength > LongestCube) {
                    LongestCube = RowLength;
                }
            }
            this.SingleRowDistance = LongestCube + ROW_GAP_DISTANCE;
            this.IncreaseDistanceUsed();
        }
    }

    /// <summary>
    /// Create an instance of the cube prefab with random x, y and z scales
    /// </summary>
    private int CreateCube(int XPosition) {
        Vector3 position = new Vector3(XPosition, FLOOR_LEVEL, this.ZPosition);
        GameObject cube = Instantiate(this.EnvObject, position, Quaternion.identity);
        int RowLength = Random.Range(MIN_LENGTH, MAX_LENGTH);
        cube.transform.localScale = new Vector3(
            Random.Range(MIN_WIDTH, MAX_WIDTH),
            Random.Range(MIN_HEIGHT, MAX_HEIGHT),
            RowLength);
        return RowLength;

    }
}
