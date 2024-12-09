using UnityEngine;

public interface IOutlineAble
{
    void Clicked(Material material);
    Material GetMaterial();
    void ResetClicked();
    

}
