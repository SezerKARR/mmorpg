using UnityEngine;

public interface IStatAble
{
    string GetStatName();
    float GetStatValue();
    void SetStatValue();

    void Outline(Material material);
    void Update();
}
