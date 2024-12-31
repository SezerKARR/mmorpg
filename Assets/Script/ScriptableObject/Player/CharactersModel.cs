using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Script.ScriptableObject.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/Player/CharactersModel")]
    public class CharactersModel: UnityEngine.ScriptableObject
    {
        [SerializeField] private List<CharacterModel> characters = new List<CharacterModel>();

        public CharacterModel GetCharacterModel(string characterId)
        {
            CharacterModel characterModel = FindCharacterByName(characterId);
            
            return characterModel ? characterModel : SetCharacterModelForGet(characterId);
        }
        public CharacterModel SetCharacterModelForGet(string characterId)
        {
            CharacterModel characterModel = UnityEngine.ScriptableObject.CreateInstance<CharacterModel>();
            string path = "Assets/Resources/CharacterModel";
            AssetDatabase.CreateAsset(characterModel, $"{path}/{characterId}.asset");
            AssetDatabase.SaveAssets();
            characterModel.characterName = characterId;//burası character name olacak
            characters.Add(characterModel);
            return characterModel;
        }
        
        public void SetCharacterModel( CharacterModel character)
        {
            characters.Add(character);
        }
        public CharacterModel FindCharacterByName(string characterName)
        {
            // Belirtilen isme sahip bir CharacterModel bul
            return characters.Find(character => character.name == characterName);
        }
    }
}