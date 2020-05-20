using UnityEngine;

namespace ProjectCaravan.Core
{
    public class MasterClock : MonoBehaviour
    {
        [System.Serializable]
        public class TimeEnvironment
        {
            public delegate void UpdateEvent();
            public event UpdateEvent EveryFrame;
            public event UpdateEvent TenTimesPerSecond;
            public event UpdateEvent TwoTimesPerSecond;
            public event UpdateEvent EverySecond;

            [SerializeField] private float speedModifier = 1;
            public float DeltaTime => Time.deltaTime * speedModifier;

            private float timer_tenTimesPerSecond = 0;
            private float timer_twoTimesPerSecond = 0;
            private float timer_everySecond = 0;

            public void SetSpeedModifier(float speedModifier)
            {
                this.speedModifier = speedModifier;
                //Debug.Log($"{nameof(TimeEnvironment)}: Speed Modifier changed ({speedModifier})");
            }

            public void Update(float deltaTime)
            {
                deltaTime *= speedModifier;
                timer_tenTimesPerSecond += deltaTime;
                timer_twoTimesPerSecond += deltaTime;
                timer_everySecond += deltaTime;

                EveryFrame?.Invoke();
                Update(TenTimesPerSecond, ref timer_tenTimesPerSecond, 0.1f);
                Update(TwoTimesPerSecond, ref timer_twoTimesPerSecond, 0.5f);
                Update(EverySecond, ref timer_everySecond, 1.0f);
            }

            private void Update(UpdateEvent update, ref float timer, float interval)
            {
                if (timer >= interval)
                {
                    update?.Invoke();
                    timer -= interval;
                }
            }
        }

        #region Static

        private static MasterClock instance;

        private static TimeEnvironment _inGame_static;
        public static TimeEnvironment InGame
        {
            get
            {
                if (_inGame_static == null)
                    _inGame_static = new TimeEnvironment();

                return _inGame_static;
            }
        }

        private static TimeEnvironment _ui_static;
        public static TimeEnvironment UI
        {
            get
            {
                if (_ui_static == null)
                    _ui_static = new TimeEnvironment();

                return _ui_static;
            }
        }

        #endregion

        [SerializeField] private TimeEnvironment _ui = new TimeEnvironment();
        [SerializeField] private TimeEnvironment _inGame = new TimeEnvironment();

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Debug.LogWarning("Destroyed duplicate MasterClock");
                Destroy(gameObject);
            }

            _ui = UI;
            _inGame = InGame;

            UI.SetSpeedModifier(1);
            InGame.SetSpeedModifier(1);
        }

        //void Update()
        //{
        //    UI.Update(Time.deltaTime);
        //    InGame.Update(Time.deltaTime);
        //}

        private void FixedUpdate()
        {
            UI.Update(Time.fixedDeltaTime);
            InGame.Update(Time.fixedDeltaTime);
        }

    }

}