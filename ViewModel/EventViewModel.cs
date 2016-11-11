using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.Persistency;

namespace EventMaker.ViewModel
{
    public class EventViewModel:INotifyPropertyChanged
    {
        public EventCatalogSingleton EventCatalogSingleton { get; set; }
        public Handler.EventHandler EventHandler { get; set; }

        public Event SelectedEvent { get; set; }

         //public Event ChangedEvent
         //{
         //    get { return _changedEvent; }
         //    set
         //    {
         //       OnPropertyChanged(nameof(ChangedEvent));
         //        _changedEvent = value;
         //    }
         //}


         private ICommand _createEventCommand=null;
        public ICommand CreateEventCommand
        {
            get
            {
                _createEventCommand = new RelayCommand(EventHandler.CreateEvent);

                return _createEventCommand;
            }
            set { _createEventCommand = value; }
        }
       

        private ICommand _deletEventCommand;
        public ICommand DeletEventCommand
        {
            get
            {
                _deletEventCommand = new RelayCommand(EventHandler.DeleteEvent);

                return _deletEventCommand;
            }
            set { _deletEventCommand = value; }
        }
        private int id;
        private string name;
        private string place;
        private string description;
        private DateTimeOffset date;
        private TimeSpan time;
         //private Event _changedEvent;

         public int Id
        {
            get { return id; }
            set { id = value;OnPropertyChanged(); }
        }
        public string  Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public string Place
        {
            get { return place; }
            set { place = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }
        public DateTimeOffset Date
        {
            get { return date; }
            set { date = value;OnPropertyChanged(); }
        }
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged();}
        }
        public EventViewModel() {
            EventCatalogSingleton = EventCatalogSingleton.Instance;
            EventHandler = new Handler.EventHandler(this);
            DateTime dt = System.DateTime.Now;
            date =new DateTimeOffset(dt.Year , dt.Month , dt.Day , 0, 0, 0, 0, new TimeSpan());
            time =new TimeSpan(dt.Hour , dt.Minute , dt.Second );
            EventCatalogSingleton.LoadEventsAsync ();

        }

        public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
}
