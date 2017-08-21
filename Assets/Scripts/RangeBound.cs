using System;

[Serializable]
public class RangeBound{
	public int min;
	public int max;

	public RangeBound(int min, int max){
		this.min = min;
		this.max = max;
	}
}