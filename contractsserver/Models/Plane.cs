using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ContractsServer.Models
{
    [DataContract]
    public class Plane : INotifyPropertyChanged
    {
        public Plane(int PlaneID, StatusFly StatusFly)
        {
            this.PlaneID = PlaneID;
            this.StatusFly = StatusFly;
        }

        private int _planeID { get; set; }

        [DataMember]
        public int PlaneID
        {
            get
            {
                return _planeID;
            }
            set
            {
                _planeID = value;
                Notify(nameof(PlaneID));
            }
        }

        [DataMember]
        public StatusFly StatusFly { get; set; }

        [DataMember]
        public DateTime TimeEnterd { get; set; }

        [DataMember]
        public DateTime TimeExist { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}