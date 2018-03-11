using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using ContractsServer.Models;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Collections.ObjectModel;
using UI.ServiceHostWCF;
using System.Windows.Threading;
using System;
using System.Windows;

namespace UI.ViewModel
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged,
    IDALServiceCallback, IWaitingListServiceCallback
    {
        #region Private stations
        private string _station1 { get; set; }
        private string _station2 { get; set; }
        private string _station3 { get; set; }
        private string _station4 { get; set; }
        private string _station5 { get; set; }
        private string _station6 { get; set; }
        private string _station7 { get; set; }
        private string _station8 { get; set; }
        private ObservableCollection<Plane> _Waiting = new ObservableCollection<Plane>();
        private DALServiceClient client;
        private WaitingListServiceClient clientWaitingList;
        static bool runAlways = true;
        private static List<StationModel> list;
        private static List<Plane> waitingListUI;
        InstanceContext instanceContext;

        #endregion
        #region Public stations
        public string Station1
        {
            get { return _station1; }
            set
            {
                if (_station1 != value)
                {
                    _station1 = value;
                    OnPropertyChanged("Station1");
                }
            }
        }
        public string Station2
        {
            get { return _station2; }
            set
            {
                if (_station2 != value)
                {
                    _station2 = value;
                    OnPropertyChanged("Station2");
                }
            }
        }
        public string Station3
        {
            get { return _station3; }
            set
            {
                if (_station3 != value)
                {
                    _station3 = value;
                    OnPropertyChanged("Station3");
                }
            }
        }
        public string Station4
        {
            get { return _station4; }
            set
            {
                if (_station4 != value)
                {
                    _station4 = value;
                    OnPropertyChanged("Station4");
                }
            }
        }
        public string Station5
        {
            get { return _station5; }
            set
            {
                if (_station5 != value)
                {
                    _station5 = value;
                    OnPropertyChanged("Station5");
                }
            }
        }
        public string Station6
        {
            get { return _station6; }
            set
            {
                if (_station6 != value)
                {
                    _station6 = value;
                    OnPropertyChanged("Station6");
                }
            }
        }
        public string Station7
        {
            get { return _station7; }
            set
            {
                if (_station7 != value)
                {
                    _station7 = value;
                    OnPropertyChanged("Station7");
                }
            }
        }
        public string Station8
        {
            get { return _station8; }
            set
            {
                if (_station8 != value)
                {
                    _station8 = value;
                    OnPropertyChanged("Station8");
                }
            }
        }
        public CollectionViewSource ViewList { get; set; }

        public ReadOnlyObservableCollection<Plane> Waiting
        {
            get
            {
                return new ReadOnlyObservableCollection<Plane>(_Waiting);
            }
        }

        #endregion

        public MainViewModel()
        {
            MainViewModel DataContext = this;
            list = new List<StationModel>();
            waitingListUI = new List<Plane>();
            instanceContext = new InstanceContext(this);
            client = new DALServiceClient(instanceContext);
            clientWaitingList = new WaitingListServiceClient(instanceContext);
            UpdateStationsGui();
            ViewList = new CollectionViewSource();
            ViewList.Source = Waiting;

        }

        public async void UpdateStationsGui()
        {
            while (runAlways)
            {
                await Task.Delay(200);
                client.GetListPlanes();
                clientWaitingList.GetWatingList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void GetPlane(StationModel[] listModel)
        {
            list = listModel.ToList();
            UpdateStationUi();
        }

        private void UpdateStationUi()
        {
            Station1 = StationChecker(1);
            Station2 = StationChecker(2);
            Station3 = StationChecker(3);
            Station4 = StationChecker(4);
            Station5 = StationChecker(5);
            Station6 = StationChecker(6);
            Station7 = StationChecker(7);
            Station8 = StationChecker(8);
        }

        private string StationChecker(int numberStation)
        {
            var item = list.FirstOrDefault(x => x.StationId == numberStation);
            if (item != null && item.Plane != null)
            {
                return list.FirstOrDefault(x => x.StationId == numberStation).Plane.PlaneID.ToString();
            }
            else
                return "null";
        }

        public void GetWatingListCallBack(Plane[] listPlanes)
        {
            waitingListUI = listPlanes.ToList();
            if (waitingListUI.Count > 0)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    UpdateWaitingList();
                }));
            }
        }

        private void UpdateWaitingList()
        {
            _Waiting.Clear();
            foreach (var item in waitingListUI)
            {
                _Waiting.Add(item);


            }
        }
    }
}