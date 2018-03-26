using System;

namespace Svelto.ECS.Extension
{
    public class ComponentChangedEvent<T>
    {
        public ComponentChangedEvent(int entityId, T component)
        {
            _entityId = entityId;
            _component = component;
        }

        public void Dispatch()
        {
            if (_subscribers != null)
                _subscribers.Invoke(_entityId, _component);
        }

        public void Notify(Action<int, T> action)
        {
            _subscribers += action;
        }

        public void StopNotify(Action<int, T> action)
        {
            _subscribers -= action;
        }

        readonly int _entityId;
        readonly T _component;

        event Action<int, T> _subscribers;
    }
}
