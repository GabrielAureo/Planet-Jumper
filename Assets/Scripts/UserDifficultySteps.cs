using System;

[Serializable]
public class RangeBoundDifficulty : DifficultySteps<RangeBound>{}

[Serializable]
public class IntDifficulty : DifficultySteps<int>{}

[Serializable]
public class FloatDifficulty : DifficultySteps<float>{}