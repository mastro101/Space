using UnityEngine;
using System.Collections;

public interface IPoolManagerItem {

    IPoolManagerItemState MyState { get; set; }
}

public enum IPoolManagerItemState
{
    unused,
    used,
}

public class Class
{
    public delegate void OnDestroy(IPoolManagerItem _iPoolManagerItem);
}