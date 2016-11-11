using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Annotations;
using EventMaker.Persistency;
using EventMaker.ViewModel;

namespace EventMaker.Model
{

     public class EventCatalogSingleton
    {

        //singlton: first make an instance of the class private and static
        //then make a private contructor
        //get access to the instance of class
        //outside the class we access Eventcatalog by" EventCatalogSingleton.EInstance.Event
        private static EventCatalogSingleton _instance = null;

        public static ObservableCollection<Event> Events { get; set; }

        // Another way: private static EventCatalogSingleton eInstance { get;}=new EventCatalogSingleton();
        public static EventCatalogSingleton Instance => _instance ?? (_instance = new EventCatalogSingleton());

         private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            Event e1 = new Event(1," Software Design ", "Room 202", new DateTime(2016, 08, 31, 11, 30, 0, 0),
                " Mandatory assignment1 should be handed");
            Event e2 = new Event(2," Software Construction", "Room 202", new DateTime(2016, 09, 3, 11, 30, 0, 0),
                " Mandatory assignment2");
            Events.Add(e1);
            Events.Add(e2);

            //another way to deserialize************************
             //var events = PersistencyService.LoadEventsFromJson().Result;
             //if (events !=null)
             //{
             //    Events=new ObservableCollection<Event>(events);
             //}
        }


        public async Task Add(Event newEvent)
        {

            Events.Add(newEvent);
            await PersistencyService.SaveEventsAsJson(Events);

        }

        public async Task Remove(Event removedEvent)
        {
            Events.Remove(removedEvent);
            await PersistencyService.SaveEventsAsJson(Events);
        }


        //public void Edit(Event oldEvent, Event newEvent)
        //{
        //    var index = Events.First(e => e == oldEvent).Id;
        //    Events.RemoveAt(index);
        //    Events.Insert(index, newEvent);
        //    PersistencyService.SaveEventsAsJson(Events);
        //}
        public async void LoadEventsAsync()
        {
            var eventslist = await PersistencyService.LoadEventsFromJson();

            if (eventslist != null)
            {
                Events.Clear();
                foreach (var e in eventslist)
                {
                    Events.Add(e);
                }
            }


        }
    }
}
