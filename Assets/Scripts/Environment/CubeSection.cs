using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSection : SectionGenerator {

    private const int MIN_COLUMN_SPACING = 15;
    private const int MAX_COLUMN_SPACING = 30;

    private const int MIN_NUMBER_ROWS_TO_SPAWN = 1;
    private const int MAX_NUMBER_ROWS_TO_SPAWN = 3;

    private const int FLOOR_LEVEL = 3;
    private const int NUMBER_OF_COLUMNS_TO_SPAWN = 10;
    private const int ROW_DISTANCE = 30;

    public override void Init(int ZPosition) {
        this.ZPosition = ZPosition;
        this.EnvObject = Resources.Load("Prefabs/Environment/EnvCube");
        this.SingleRowDistance = ROW_DISTANCE;
    }

    /// <summary>
    /// Spawn a section of cubes
    /// </summary>
    public override void CreateSection() {
        int ColumnSpaces = Random.Range(MIN_COLUMN_SPACING, MAX_COLUMN_SPACING);
        int NumberOfRowsToSpawn = Random.Range(MIN_NUMBER_ROWS_TO_SPAWN, MAX_NUMBER_ROWS_TO_SPAWN);

        for (var i = 0; i < NumberOfRowsToSpawn; i++) {
            for (var j = 0; j < NUMBER_OF_COLUMNS_TO_SPAWN; j++) {
                var x = ColumnSpaces * j;
                Vector3 position = new Vector3(x, FLOOR_LEVEL, this.ZPosition);
                Instantiate(this.EnvObject, position, Quaternion.identity);
            }
            this.IncreaseDistanceUsed();
        }
    }
}
