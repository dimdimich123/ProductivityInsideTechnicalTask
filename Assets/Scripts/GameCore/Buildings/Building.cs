using UnityEngine;
using DG.Tweening;
using UniRx;
using System;
using System.Collections;
using GameCore.CommonLogic;

namespace GameCore.Buildings {
    public class Building : MonoBehaviour
    {
        [SerializeField] private BuildingType _buildingType;
        [SerializeField] private Vector2Int _size;

        public BuildingType BuildingType => _buildingType;
        public Vector2Int Size => _size;

        protected Transform _transform;

        private float _buildDuration;
        private float _destroyDuration = 1.5f;

        public bool IsBuilt { get; protected set; }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void Init(float buildDuration)
        {
            _buildDuration = buildDuration;
        }

        public virtual void StartBuild()
        {
            Sequence buildAnimation = DOTween.Sequence()
                .SetEase(Ease.InOutQuad)
                .Append(_transform.DOShakeScale(0.5f, 0.2f))
                .AppendInterval(0.25f)
                .SetLoops(-1)
                .SetLink(gameObject);

            //Observable.Timer(TimeSpan.FromSeconds(_buildDuration))
            //.Subscribe(_ =>
            //    {
            //        buildAnimation.Kill();
            //        EndBuild();
            //    })
            //.AddTo(this);

            StartCoroutine(BuildTimer(buildAnimation));
        }

        private IEnumerator BuildTimer(Sequence buildAnimation)
        {
            float elapsedTime = 0;
            while(elapsedTime < _buildDuration)
            {
                elapsedTime += Time.deltaTime * BuildingTimer.TimeScale;
                yield return null;
            }

            buildAnimation.Kill();
            EndBuild();
        }

        public virtual void EndBuild() 
        {
            IsBuilt = true;
        }

        public virtual void Breake()
        {
            Sequence destroyAnimation = DOTween.Sequence()
                .SetEase(Ease.InOutQuad)
                .Append(_transform.DOShakeScale(0.5f, 0.2f))
                .AppendInterval(0.25f)
                .SetLoops(-1)
                .SetLink(gameObject);

            Observable.Timer(TimeSpan.FromSeconds(_destroyDuration))
            .Subscribe(_ =>
                {
                    destroyAnimation.Kill();
                    Destroy(gameObject);
                })
            .AddTo(this);
        }
    }
}