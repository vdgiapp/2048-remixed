using System.Collections.Generic;
using Remixed2048.Observers;

namespace Remixed2048
{
    public class UpdateManager : MonoSingleton<UpdateManager>
    {
        private readonly HashSet<IUpdateObserver> _observers = new();
        private readonly HashSet<IUpdateObserver> _pendingObservers = new();
        private readonly HashSet<IUpdateObserver> _pendingRemovals = new();
        
        private bool _isUpdating = false;
        
        private void Update()
        {
            _isUpdating = true;
            
            // Enumerate trực tiếp trên HashSet tránh tạo list mới
            foreach (var observer in _observers)
            {
                observer.ObservedUpdate();
            }
            _isUpdating = false;
            
            // Xóa các observer chờ loại bỏ sau khi update
            if (_pendingRemovals.Count > 0)
            {
                foreach (var observer in _pendingRemovals)
                {
                    _observers.Remove(observer);
                }
                _pendingRemovals.Clear();
            }
            
            // Thêm các observer chờ đăng ký
            if (_pendingObservers.Count > 0)
            {
                foreach (var observer in _pendingObservers)
                {
                    _observers.Add(observer);
                }
                _pendingObservers.Clear();
            }
            
        }

        public void RegisterObserver(IUpdateObserver observer)
        {
            if (_pendingRemovals.Contains(observer))
            {
                _pendingRemovals.Remove(observer);
            }
            
            if (!_pendingObservers.Contains(observer) && !_observers.Contains(observer))
            {
                _pendingObservers.Add(observer);
            }
        }

        public void UnregisterObserver(IUpdateObserver observer)
        {
            if (_isUpdating)
            {
                // Nếu đang update, đẩy observer vào danh sách chờ xóa
                _pendingRemovals.Add(observer);
                // Đồng thời loại bỏ khỏi _pendingObservers nếu observer mới được thêm nhưng chưa cập nhật
                _pendingObservers.Remove(observer);
            }
            else
            {
                _observers.Remove(observer);
                _pendingObservers.Remove(observer);
            }
        }
    }
}