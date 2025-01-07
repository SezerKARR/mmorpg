using System;
using System.Collections.Generic;
using Script.Anim;
using Script.Damage;
using Script.Interface;
using Script.ObjectInstances;
using TMPro;
using UnityEngine;
using Script.Player.Character;
using UnityEditor.Animations;

namespace Script.Enemy
{   

    public class EnemySkeleton : MonoBehaviour, IDamageAble, IOutlineAble,IPool
    {
        private CharacterAnims _characterAnims;
        public TextMeshPro enemyName;
        private EnemyHealth _enemyHealth;
        public CreaturesGroup creaturesGroup;
        private Material _normalMaterial;

       [SerializeField] private MonsterSO enemySo;
        private IDamager _lastDamager;
        private readonly Dictionary<IDamager,float> _damagers = new Dictionary<IDamager, float>();
        
        private Vector3 _startPosition;
        public void Initialize(MonsterSO monsterSo, AnimatorController animatorController)
        {
            this.transform.position = _startPosition;
            this.enemySo = monsterSo;
            this.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        }
        public void Awake()
        {
            _startPosition = transform.position;
            _characterAnims = new CharacterAnims(GetComponent<Animator>());
            _enemyHealth = new EnemyHealth(enemySo.health);
            this._enemyHealth.OnDeath += Death;
            _normalMaterial = GetComponent<SpriteRenderer>().material;
            
            enemyName.SetText($"<color=yellow> Lv. {enemySo.level}</color><color=red> {enemySo.monsterName}</color>");
        }


        public void Update()
        {
            transform.position += new Vector3(0.1f, 0.1f, 0f) * Time.deltaTime;
            _characterAnims.UpdateAnim(AnimationEnum.Idle, DirectionHelper.GetDirection(Vector2.left));
            
            
        }

        /*public virtual void Outline(Color color)
        {
            if (color == Color.red)
            {
                this.GetComponent<SpriteRenderer>().material = outlineRed;
            }
            else if (color == Color.gray)
            {

                this.GetComponent<SpriteRenderer>().material = normalMaterial;
            }
        }*/
        public void TakeDamage(float damage,IDamager damager)
        {
            
            // todo: belirli bir cana kadar vuran oyunculara drop atacak bu drop i�in rastgele aralar�ndan bir playerController se�ilecek
            //todo: iki kat e�ya i�in droplar ayarlanacak her playerController i�in ayr� ayr�
            if (_damagers.ContainsKey(damager))
            {
                _damagers[damager] += damage;
            }
            else
            {
                _damagers.Add(damager, damage);
            }
            
            
            _lastDamager = damager;
            _enemyHealth.TakeDamage(damage);

        }

        public CharacterNormalDefenderData GetNormalDefenderData()
        {
            return enemySo.GetNormalDefenderData();
        }

        public CharacterSkillDefenderData GetSkillDefenderData()
        {
            throw new NotImplementedException();
        }

        public void Death()
        {
            _lastDamager.onEnemyKilled?.Invoke(enemySo.levelint,enemySo.expint);
                
            //EnemyEvent.OnFinishTextTime?.Invoke((_lastDamager.GetName(),enemySo));
            creaturesGroup.OnEnemyDeath();
            DropItem(_lastDamager.GetName());
            Destroy(gameObject);

        }

        public void DropItem(string player)
        {  
            foreach (var canDrop in enemySo.canDrops)
            {
                
                GameEvent.OnItemDroppedWithPlayer?.Invoke(transform.position, ObjectInstanceCreator.ObjectInstance(canDrop), player);


            }
            /*foreach (var item in itemToDrops)
            {
                float random = Random.Range(0f, 1f);
                //print(random);


            }*/
        }



        public virtual void Clicked(Material material)
        {
            this.GetComponent<SpriteRenderer>().material = material;
        }

        public void ResetClicked()
        {
            this.GetComponent<SpriteRenderer>().material = _normalMaterial;
        }


        public Vector2 GetPosition()
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }


        public string GetPoolType()
        {
            return enemySo.monsterName;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}