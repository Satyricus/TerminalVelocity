using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SectionGenerator : ScriptableObject {

    protected int ZPosition;

    protected int SectionLength;

    protected int SingleRowDistance;

    protected Object EnvObject;

    ///<section>
    /// Initiate a row (simulates a constructor for the ScriptableObject)
    ///</section>
    abstract public void Init(int ZPosition);

    ///<section>
    /// Create a section
    ///</section>
    abstract public void CreateSection();

    ///<section>
    /// Get the distance (z axis) that this section has used
    ///</section>
    public int getSectionLength() {
        return this.SectionLength;
    }

    public void IncreaseDistanceUsed() {
        this.ZPosition += this.SingleRowDistance;
        this.SectionLength += this.SingleRowDistance;
    }
}
